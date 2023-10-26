using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        InvokeRepeating("Lunge", 5, 5);
    }

    void Lunge()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        Debug.Log("Lunging");
        rb.AddForce(lookDirection * speed, ForceMode.Impulse);
    }
}
