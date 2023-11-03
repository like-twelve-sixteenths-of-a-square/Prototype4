using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class BurstingEnemy : MonoBehaviour
{
    public float speed;
    private bool allowedToMove;
    private Rigidbody rb;
    private GameObject player;
    public Light ballLightPrep;
    public Light ballLightBurst;
    public ParticleSystem ballBurstParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        StartCoroutine(Repeating());
    }

    void Update()
    {
        if (allowedToMove == true)
        {

        }
        if (transform.position.y < -10) { Destroy(gameObject); }
    }

    IEnumerator Repeating()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);

            //Prepare charge
            ballLightPrep.enabled = true;

            yield return new WaitForSeconds(2);

            allowedToMove = false;

            yield return new WaitForSeconds(1);

            ballLightPrep.enabled = false;
            ballLightBurst.enabled = true;
            ballBurstParticles.Play();

            yield return new WaitForSeconds(0.5f);

            ballLightBurst.enabled = false;
            ballBurstParticles.Stop();
            allowedToMove = true;
        }
    }
}
