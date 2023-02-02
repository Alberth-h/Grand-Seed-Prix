using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] float speedUp = 15f;
    [SerializeField] GameObject[] meshes = new GameObject[6];

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            StartCoroutine(Picked(collider));
        }
    }

    IEnumerator Picked(Collider collider)
    {
        collider.gameObject.GetComponent<PlayerController>().speed = speedUp;
        
        for(int i = 0; i < 6; i++)
        {
            meshes[i].GetComponent<MeshRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(5);

        collider.gameObject.GetComponent<PlayerController>().speed = 12f;
        Destroy(gameObject);
    }
}
