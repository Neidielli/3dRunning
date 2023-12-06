using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private Rigidbody rbd;
    public float vel = 5;
    public float velRot = 75;
    private Quaternion rotOriginal;
    private float rotMouseX = 0;
    private float rotTecladoX = 0;
    public LayerMask alvo;
    public AudioSource som;
    public SceneController sceneController;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rbd = GetComponent<Rigidbody>();
        som = GetComponent<AudioSource>();
        rotOriginal = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimento do PC
        float moveFrente = Input.GetAxis("Vertical");
        float moveLado = Input.GetAxis("Horizontal");

        Vector3 velo = transform.TransformDirection(
                                    new Vector3(moveLado * vel,
                                                rbd.velocity.y,
                                                moveFrente * vel));
        rbd.velocity = velo;

        // Rotação usando Mouse
        rotMouseX += Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.Q))
        {
            rotTecladoX -= 1;
        }
        else if (Input.GetKey(KeyCode.E))
            rotTecladoX += 1;
        Quaternion lado = Quaternion.AngleAxis(rotMouseX + rotTecladoX, Vector3.up);

        transform.localRotation = rotOriginal * lado;
        
        // Rotação usando Teclado
        rbd.velocity = velo;

        int rot = 0;
        if (Input.GetKey(KeyCode.Q))
            rot = -1;
        else if (Input.GetKey(KeyCode.E)) 
            rot = 1;

        transform.Rotate(new Vector3(0, rot * Time.deltaTime * velRot, 0));

        // tiro
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) 
        {
            som.Play();
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100, alvo))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(
                                                    transform.forward * 500);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            sceneController.EndGame();
        }
    }
}
