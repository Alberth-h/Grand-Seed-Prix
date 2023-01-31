using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float life = 3f;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    /*void OnCollisionEnter(Collision collider)
    {
        Destroy(collider.gameObject);
        Destroy(gameObject);
    }*/
}
