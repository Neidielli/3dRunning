using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMirror : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Mirror"))
        {
            Camera cam = other.gameObject.GetComponentInChildren<Camera>();
            transform.position = new Vector3(cam.gameObject.transform.position.x, transform.position.y, cam.gameObject.transform.position.z);
        }
    }
}
