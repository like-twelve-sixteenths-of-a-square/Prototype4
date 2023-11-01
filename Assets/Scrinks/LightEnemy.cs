using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;
    public Light ballLightPrep;
    public Light ballLightLunge;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        StartCoroutine(Repeating());
    }


    IEnumerator Repeating()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.5f);

            //Prepare charge
            ballLightPrep.enabled = true;

            yield return new WaitForSeconds(1);

            //Warn charge
            ballLightPrep.enabled = false;
            ballLightLunge.enabled = true;

            yield return new WaitForSeconds(1);

            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            rb.AddForce(lookDirection * speed, ForceMode.Impulse);
            rb.AddForce(Vector3.up, ForceMode.Impulse);

            yield return new WaitForSeconds(0.5f);

            ballLightLunge.enabled = false;
        }
    }
}
