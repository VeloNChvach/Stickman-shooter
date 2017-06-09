using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private GameObject canvasGame;
    private GameObject canvasMenu;
    private GameObject player;

    public static Main Instance { get; private set; }

    private void Awake()
    {
        // init components
        canvasGame = GameObject.Find("Canvas_game");
        canvasMenu = GameObject.Find("Canvas_menu");
        player = GameObject.FindGameObjectWithTag("Player");

        canvasGame.SetActive(false);
        player.SetActive(false);// disable Player
    }

    public GameObject Player
    {
        get { return player; }
    }

    public PlayerController PlayerController
    {
        get { return player.GetComponent<PlayerController>(); }
    }

    public void GoMultiplayer()
    {
        //Multiplayer
        canvasMenu.SetActive(false); // Close UI menu
    }

    public void GoAI()
    {
        //AI
        canvasMenu.SetActive(false); // Close UI menu
        canvasGame.SetActive(true);

        player.SetActive(true);
    }
}
