using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float countRotX = 0;
    private Quaternion rotationInicial; // Rotação do obj
   
    public float rotSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rotationInicial = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        MouseMoveX();
    }

    private void MouseMoveX()
    {
        countRotX += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotSpeed; // Pega o movimento do mouse na vertical e multiplica pela velocidade

        countRotX = Mathf.Clamp(countRotX, -60, 60);

        Quaternion rotY = Quaternion.AngleAxis(countRotX, Vector3.left); // calcula o angulo da camera

        transform.localRotation = rotationInicial * rotY; // seta o angulo
    }
}
