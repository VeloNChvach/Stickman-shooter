using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("Canvas_game").SetActive(false); // Close UI arrow
    }

    public void GoMultiplayer()
    {
        //Multiplayer

        GameObject.Find("Canvas_menu").SetActive(false); // Close UI menu
    }

    public void GoAI()
    {
        //AI
        GameObject.Find("Canvas_menu").SetActive(false); // Close UI menu

        gameObject.AddComponent(typeof(PlayGame));
    }
}
