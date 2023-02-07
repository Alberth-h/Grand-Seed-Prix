using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] float speedUp = 25f;
    [SerializeField] GameObject[] meshes = new GameObject[6];
    [SerializeField] private GameObject right_feet;
    [SerializeField] private GameObject left_feet;
    [SerializeField] private GameObject right_shoe;
    [SerializeField] private GameObject left_shoe;
    private Transform trans2;
    private AudioSource audioData;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            StartCoroutine(Picked(collider));
            audioData = GetComponent<AudioSource>();
            audioData.Play();
        }
    }

    IEnumerator Picked(Collider collider)
    {
        collider.gameObject.GetComponent<PlayerController>().speed = speedUp;
        
        //for(int i = 0; i < 6; i++)
        //{
            //meshes[i].GetComponent<MeshRenderer>().enabled = false;
        //}

        trans2 = collider.transform;

        Transform Right_feet = trans2.transform.Find("Man_Mesh/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Thigh/Bip001 R Calf/Bip001 R Foot/");
        Transform left_feet = trans2.transform.Find("Man_Mesh/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 L Thigh/Bip001 L Calf/Bip001 L Foot/");
        //right_shoe.transform.Find("Right_Shoe");  
        

        right_shoe.transform.SetParent(Right_feet, true);
        right_shoe.transform.position = Right_feet.position;
        right_shoe.transform.rotation = Right_feet.rotation;
        right_shoe.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

        left_shoe.transform.SetParent(left_feet, true);
        left_shoe.transform.position = left_feet.position;
        left_shoe.transform.rotation = left_feet.rotation;
        left_shoe.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(10);

        collider.gameObject.GetComponent<PlayerController>().speed = 20f;
        Destroy(gameObject);
        Destroy(right_shoe);
        Destroy(left_shoe);
    }
}
