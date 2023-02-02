using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CamaraController : NetworkBehaviour
{
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private Vector3 offset;

    public void Update()
    {
        if (!IsOwner) return;
        cameraHolder.SetActive(true);
        cameraHolder.transform.position = transform.position + offset;
    }
}
