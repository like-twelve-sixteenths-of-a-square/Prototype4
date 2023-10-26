using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public float jump;
    private GameObject focalPoint;

    private bool onFloor;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        onFloor = true;
    }

    void Update()
    {
        //Vertical Movement

        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        //Horizontal Movement
        playerRb.AddForce(focalPoint.transform.right * speed * horizontalInput);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            onFloor = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }
}
