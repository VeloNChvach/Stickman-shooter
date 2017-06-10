using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stickman_shooter
{
    public class Main : MonoBehaviour
    {
        private GameObject canvasGame;
        private GameObject canvasMenu;
        private GameObject canvasRestart;
        private GameObject canvasMultiplayer;
        private GameObject player;
        private GameObject bot;
        private bool preRestart = true;

        private void Awake()
        {
            // init components
            canvasGame = GameObject.Find("Canvas_game");
            canvasMenu = GameObject.Find("Canvas_menu");
            canvasRestart = GameObject.Find("Canvas_restart");
            canvasMultiplayer = GameObject.Find("Canvas_multiplayer");

            AddEventOnCanvasMenu();

            canvasGame.SetActive(false);
            canvasRestart.SetActive(false);
            canvasMultiplayer.SetActive(false);
        }

        private void AddEventOnCanvasMenu()
        {
            Button[] button = FindObjectsOfType<Button>();
            for (int i = 0; i < button.Length; i++)
            {
                if (button[i].name == "Btn_Multiplayer")
                    button[i].onClick.AddListener(GoMultiplayer);
                if (button[i].name == "Btn_AI")
                    button[i].onClick.AddListener(GoAI);
            }
        }

        private void GoMultiplayer()
        {
            //Multiplayer
            canvasMenu.SetActive(false); // Close UI menu
            canvasMultiplayer.SetActive(true); // Open canvas Multiplayer
            gameObject.AddComponent(typeof(Server)); // Add script Server on Main
        }

        private void GoAI()
        {
            //AI
            canvasMenu.SetActive(false); // Close UI menu
            canvasGame.SetActive(true);
            canvasMultiplayer.SetActive(false);

            player = Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject)) as GameObject); // Init player
            bot = Instantiate(Resources.Load("Prefabs/Bot", typeof(GameObject))) as GameObject; // Init bot
        }

        public void PreRestart(GameObject looser)
        {
            canvasGame.SetActive(false);
            canvasRestart.SetActive(true);
            canvasMultiplayer.SetActive(false);

            if (preRestart)
            {
                if (looser.tag == "Player")
                {
                    canvasRestart.transform.GetComponentInChildren<Text>().text = "Enemy win!";
                    Destroy(bot);
                }
                else if (looser.tag == "Enemy")
                {
                    canvasRestart.transform.GetComponentInChildren<Text>().text = "Player win!";
                    Destroy(player);
                }
                    
                preRestart = false; // without 2 winners
            }
            
        }

        public void Restart()
        {
            canvasGame.SetActive(true);
            canvasRestart.SetActive(false);
            canvasMultiplayer.SetActive(false);
            preRestart = true;

            GoAI();
        }
    }
}