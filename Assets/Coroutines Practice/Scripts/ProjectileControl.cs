using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    public float moveSpeed;
    public float destroyDelay;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pew :3");
    }

    // Update is called once per frame
    void Update()
    {
        //Move Forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyable"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
