using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public GameObject cannon;
    public GameObject ball;
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            shoot(2);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            shoot(7);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(SteadyShot(Random.Range(1, 76), 0.5f));
        }
    }

    public void shoot(int numberOfBalls)
    {
        for(int i = 0; i < numberOfBalls; i++)
        {
            Instantiate(ball, cannon.transform.position, cannon.transform.rotation);
        }
    }

    IEnumerator SteadyShot(int numberOfBalls, float delay)
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            Instantiate(ball, cannon.transform.position, cannon.transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }
}
