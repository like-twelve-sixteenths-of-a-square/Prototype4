using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangePickUp : MonoBehaviour
{
    [Header("Materials")]
    public Material defaultMaterial;
    public Material newMaterial;

    [Header("Duration")]
    public float duration;

    //Components

    private MeshRenderer myMr;
    private MeshRenderer playerMr;
    private Collider myCollider;


    // Start is called before the first frame update
    void Start()
    {
        myMr = GetComponent<MeshRenderer>();
        myCollider = GetComponent<Collider>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Is ploer?
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ploer :}");

            //Get the ploer mesh remder
            playerMr = other.GetComponent<MeshRenderer>();

            //Croter start
            StartCoroutine(ColorChange());
        }
    }

    IEnumerator ColorChange()
    {
        //Make the player(ploer) a new color
        playerMr.material = newMaterial;

        //Dloy
        yield return new WaitForSeconds(duration);

        //Back to normal:33333333333333333333333}
        playerMr.material = defaultMaterial;
    }
}
