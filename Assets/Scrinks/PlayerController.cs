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
    public bool hasPowerup;
    public float powerupStrength;
    public float powerupLength;
    public GameObject powerIndicator;
    public GameObject heavyCrown;

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
        if (Input.GetKey(KeyCode.Space) && onFloor)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            onFloor = false;
        }

        //Powerup ring follows the player with this script
        powerIndicator.transform.position = transform.position;
        //Heavy crown follows the top of the player with this script
        heavyCrown.transform.position = transform.position + new Vector3 (0, 0.125f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Just checks if you can jump again lol :3
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If you collide with a powerup, delete the powerup and become powered up
        if(other.CompareTag("Powerup"))
        {
            //Says that you have a powerup and indicates it
            hasPowerup = true;
            powerIndicator.gameObject.SetActive(true);
            heavyCrown.SetActive(true);

            //Makes the player heavy and retains speed
            gameObject.GetComponent<Rigidbody>().mass *= 3;
            speed *= 3;
            jump *= 3;

            //removes the powerup item
            Destroy(other.gameObject);

            //starts powerdown routine
            StartCoroutine(PowerupCDR());
        }
    }

    IEnumerator PowerupCDR()
    {
        //When powered up, wait for a set time, then stop being powered up
        yield return new WaitForSeconds(powerupLength);
        hasPowerup = false;
        powerIndicator.gameObject.SetActive(false);
        heavyCrown.gameObject.SetActive(false);

        //Returns normal mass and variables
        gameObject.GetComponent<Rigidbody>().mass /= 3;
        speed /= 3;
        jump /= 3;
    }
}
