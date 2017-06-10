using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Server : MonoBehaviour
{
    private string ip = "127.0.0.1"; // Game IP
    private int port = 5300;    // Port

    private void Awake()
    {
        AddEventOnCanvasMultiplayer();
    }

    private void AddEventOnCanvasMultiplayer()
    {
        Button[] button = FindObjectsOfType<Button>();
        for (int i = 0; i < button.Length; i++)
        {
            if (button[i].name == "Btn_create")
                button[i].onClick.AddListener(Create);
            if (button[i].name == "Btn_connected")
                button[i].onClick.AddListener(Connect);
            if (button[i].name == "Btn_back")
                button[i].onClick.AddListener(Back);
        }
    }

    private void Create()
    {
        Network.InitializeServer(2, port, false);
    }

    private void Connect()
    {
        Network.Connect(ip, port);
    }

    private void Back()
    {
        // Back to main menu
    }

    // When we create server
    void OnServerInitialized()
    {
        GameObject player = Network.Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject)) as GameObject, transform.position, Quaternion.identity, 1) as GameObject;
        player.AddComponent(typeof(Client));
        player.gameObject.SetActive(false); // Wait for other player


    }

    // When we connected to server
    void OnConnectedToServer()
    {
        
    }

    // When we disconnecter from server
    void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        Application.Quit();
    }

    // When other player disconnected from server
    void OnPlayerDisconnected(NetworkPlayer pl)
    {
        Network.DestroyPlayerObjects(pl);
    }

}
