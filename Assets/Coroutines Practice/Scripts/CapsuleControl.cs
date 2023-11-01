using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControl : MonoBehaviour
{
    //VARIABLES

    [Header("Movement")]
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    public bool isOnGround = true;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rb;

    [Header("Shooting")]
    public GameObject projectile;
    public float shootDelay;
    public GameObject spawnPoint;
    private bool canShoot;


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Forward and Backward Movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveSpeed * verticalInput * Time.deltaTime);



        //Clockwise and counterclockwise Rotation
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);


        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }


        
        //Shooting
        if (Input.GetKeyDown(KeyCode.Q) && canShoot)
        {
            Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
            StartCoroutine(Schuute());
        }
    }

    IEnumerator Schuute()
    {
        canShoot = false;

        //Wait
        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
