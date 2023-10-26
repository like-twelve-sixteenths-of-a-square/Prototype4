using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungingEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            rb.AddForce(lookDirection * speed * 50, ForceMode.Impulse);
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        }
    }
}
