using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballGo : MonoBehaviour
{
    private Rigidbody rb;
    public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
    }
}
