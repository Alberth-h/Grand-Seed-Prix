using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] Camera player1Cam;
    [SerializeField] Camera player2Cam;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    void Awake()
    {
        player2Cam.enabled = false;
        player1Cam.enabled = true;

        player1.GetComponent<PlayerController>().enabled = true;
        player2.GetComponent<PlayerController>().enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            player2Cam.enabled = !player2Cam.enabled;
            player1Cam.enabled = !player1Cam.enabled;
            
            player1.GetComponent<PlayerController>().enabled = !player1.GetComponent<PlayerController>().enabled;
            player2.GetComponent<PlayerController>().enabled = !player2.GetComponent<PlayerController>().enabled;
        }
    }
}
