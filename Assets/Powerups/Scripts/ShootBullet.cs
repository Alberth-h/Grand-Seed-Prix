using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 500f;
    bool CanShoot = true;
    //[SerializeField] float waitingTime = 1f;
    //float timer =0f;
    
    void Update()
    {
        //timer +=Time.deltaTime;
        if(CanShoot == true){
             var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
             bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            CanShoot = false;
            StartCoroutine(Reload());
        } 
    }

    IEnumerator Reload(){
        yield return new WaitForSeconds(0.2f);
        CanShoot = true;
    }
    
}
