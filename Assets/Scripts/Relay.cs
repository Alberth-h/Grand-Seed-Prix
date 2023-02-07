using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using TMPro;

public class Relay : MonoBehaviour
{
    [SerializeField] private Text txtJoinCode;
    [SerializeField] private TMP_InputField codeInput;
    [SerializeField] private Button btnJoinRelay;
    [SerializeField] private GameObject uiMenu;
    [SerializeField] private GameObject uiLoading;
    [SerializeField] private GameObject uiBackground;
    [SerializeField] private GameObject menuCamera;
    [SerializeField] private GameObject pnlCode;
    
    private async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        btnJoinRelay.onClick.AddListener(() => JoinRelay(codeInput.text));
    }

    public async void CreateRelay()
    {
        try
        {
            Destroy(uiMenu);
            uiLoading.SetActive(true);
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(3);
        
            string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            Debug.Log(joinCode);

            RelayServerData relayServerData = new RelayServerData (allocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();

            Destroy(uiLoading);
            Destroy(uiBackground);
            Destroy(menuCamera);
            pnlCode.SetActive(true);
            txtJoinCode.text = joinCode;
        }
        catch(RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    public async void JoinRelay(string joinCode)
    {
        try
        {
            Destroy(uiMenu);
            uiLoading.SetActive(true);
            Debug.Log("Joining Relay with " + joinCode);
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);
            RelayServerData relayServerData = new RelayServerData (joinAllocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
            NetworkManager.Singleton.StartClient();

            Destroy(uiLoading);
            Destroy(uiBackground);
            Destroy(menuCamera);
            pnlCode.SetActive(true);
            txtJoinCode.text = joinCode;
        }
        catch(RelayServiceException e)
        {
            Debug.Log(e);
        }
    }
}