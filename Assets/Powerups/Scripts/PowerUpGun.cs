using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGun : MonoBehaviour
{
    [SerializeField] float duration = 10f;
    [SerializeField] private Animator _animator;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            StartCoroutine(Picked(collider));
            _animator.SetBool("isShooting", true);
        }
    }

    IEnumerator Picked(Collider collider)
    {
        collider.gameObject.GetComponent<ShootBullet>().enabled = true;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        collider.gameObject.GetComponent<ShootBullet>().enabled = false;

        Destroy(gameObject);
        _animator.SetBool("isShooting", false);
    }
}
