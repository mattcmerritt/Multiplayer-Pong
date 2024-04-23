using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class IPSelectInterface : MonoBehaviour
{
    [SerializeField] private TMP_InputField ipAddress;

    public void CreateClient()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = ipAddress.text.Trim();
        NetworkManager.Singleton.StartClient();
    }

    public void CreateClientAndServer()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = ipAddress.text.Trim();
        NetworkManager.Singleton.StartHost();
    }
}
