using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUp : MonoBehaviour
{
    [SerializeField] float duration = 10f;
    [SerializeField] float speedUp = 15f;
    
    [SerializeField] private Animator _animator;
    
    [SerializeField] GameObject[] mesh;

    void OnTriggerEnter(Collider collider)
    {
        int randomNumber = Random.Range(0, 2);
        if(collider.gameObject.tag == "Player")
        {
            if(randomNumber == 0)
            {
                StartCoroutine(Gun(collider));
                _animator.SetBool("isShooting", true);
                Debug.Log("pium pium");
                
            }
            else if(randomNumber == 1)
            {
                StartCoroutine(Shoes(collider));
                Debug.Log("Fiuuuuuuuuuuuuuuuuuuuuuuuuum");
            }
        }
    }

    IEnumerator Gun(Collider collider)
    {
        collider.gameObject.GetComponent<ShootBullet>().enabled = true;

        
        GetComponent<BoxCollider>().enabled = false;

        for(int i = 0; i < 2; i++)
        {
            mesh[i].GetComponent<MeshRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(duration);

        collider.gameObject.GetComponent<ShootBullet>().enabled = false;

        Destroy(gameObject);
        _animator.SetBool("isShooting", false);
    }

    IEnumerator Shoes(Collider collider)
    {
        collider.gameObject.GetComponent<PlayerController>().speed = speedUp;
        
        for(int i = 0; i < 2; i++)
        {
            mesh[i].GetComponent<MeshRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(5);

        collider.gameObject.GetComponent<PlayerController>().speed = 12f;
        Destroy(gameObject);
    }
}
