using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoCamora : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * -1);
        }
    }
}
