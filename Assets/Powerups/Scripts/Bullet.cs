using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float life = 5f;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collider)
    {
        //Debug.Log(collider.gameObject.tag);
        Destroy(gameObject); 
    }
}
