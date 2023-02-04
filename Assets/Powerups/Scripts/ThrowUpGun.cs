using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowUpGun : MonoBehaviour
{
    [SerializeField] float duration = 2f;
   
    [SerializeField] private GameObject hand;
    private AudioSource audioData;
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            StartCoroutine(Picked(collider));
             audioData = GetComponent<AudioSource>();
             audioData.Play();
            Debug.Log("started");
        }
    }
    
    IEnumerator Picked(Collider collider)
    {
        collider.gameObject.GetComponent<ShootBullet>().enabled = true;
        GetComponent<Collider>().enabled = false;
        

        yield return new WaitForSeconds(duration);

        collider.gameObject.GetComponent<ShootBullet>().enabled = false;

        Destroy(gameObject);
    }
}
