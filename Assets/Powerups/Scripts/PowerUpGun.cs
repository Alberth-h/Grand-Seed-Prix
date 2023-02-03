using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGun : MonoBehaviour
{
    [SerializeField] float duration = 15f;
    private Animator _animator;
    [SerializeField] private GameObject hand;
    private Transform trans2;
    private Transform mesh;
    private AudioSource audioData;

    void Start()
    {
       
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            StartCoroutine(Picked(collider));
            _animator.SetBool("isShooting", true);
             audioData = GetComponent<AudioSource>();
             audioData.Play();
            Debug.Log("started");
        }
    }
    
        

    
    IEnumerator Picked(Collider collider)
    {
        
        trans2 = collider.transform;
        mesh = trans2.transform.Find("Man_Mesh") ;
        
        _animator = mesh.GetComponent<Animator>();
        
        Transform hand = trans2.transform.Find("Man_Mesh/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Spine2/Bip001 Neck/Bip001 L Clavicle/Bip001 L UpperArm/Bip001 L Forearm/Bip001 L Hand/GunPosition");
        
        transform.SetParent(hand, true);
        this.gameObject.transform.position = hand.position;
        this.gameObject.transform.rotation = hand.rotation;
        this.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

        collider.gameObject.GetComponent<ShootBullet>().enabled = true;
        GetComponent<Collider>().enabled = false;
        

        yield return new WaitForSeconds(duration);

        collider.gameObject.GetComponent<ShootBullet>().enabled = false;

        Destroy(gameObject);
        _animator.SetBool("isShooting", false);
    }
}
