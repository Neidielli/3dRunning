using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float countRotY = 0;
    private Quaternion rotationInicial; // Rotação do obj

    public float speed = 5f;
    public float rotSpeed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotationInicial = transform.localRotation;
        Cursor.lockState = CursorLockMode.Locked; // Prende o mouse no meio e some
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MouseMoveY();
    }

    private void Move()
    {
        float frente = Input.GetAxis("Vertical");
        float lado = Input.GetAxis("Vertical");

        Vector3 direcao = transform.TransformDirection(new Vector3(lado * speed, rb.velocity.y, frente * speed));

        rb.velocity = direcao;
    }

    private void MouseMoveY()
    {
        countRotY += Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotSpeed; // Pega o movimento do mouse na horizontal e multiplica pela velocidade

        Quaternion rotY = Quaternion.AngleAxis(countRotY * rotSpeed, Vector3.up); // calcula o angulo da camera

        transform.localRotation = rotationInicial * rotY; // seta o angulo
    }
}
