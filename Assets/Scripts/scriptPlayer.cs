using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rbd;
    public float vel = 5;
    public float velRot = 75;
    private Quaternion rotOriginal;
    private float rotMouseX = 0;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
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

        // Rotação usando Mouse
        rotMouseX += Input.GetAxis("Mouse X");
        Quaternion lado = Quaternion.AngleAxis(rotMouseX, Vector3.up);
        transform.localRotation = rotOriginal * lado;
        
        // Rotação usando Teclado
        rbd.velocity = velo;

        int rot = 0;
        if (Input.GetKey(KeyCode.Q))
            rot = -1;
        else if (Input.GetKey(KeyCode.E)) 
            rot = 1;

        transform.Rotate(new Vector3(0, rot * Time.deltaTime * velRot, 0));
    }
}
