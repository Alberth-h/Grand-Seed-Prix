using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CamaraController : NetworkBehaviour
{
    [SerializeField] private GameObject cameraHolder;
    //[SerializeField] private GameObject buttonsHolder;
    [SerializeField] private Vector3 offset;

    public void Update()
    {
        if (!IsOwner) return;
        //buttonsHolder.SetActive(true);
        cameraHolder.SetActive(true);
        cameraHolder.transform.position = transform.position + offset;
    }
}
