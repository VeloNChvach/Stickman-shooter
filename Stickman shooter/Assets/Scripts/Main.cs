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
        private GameObject player;
        private GameObject bot;
        private bool preRestart = true;

        private void Awake()
        {
            // init components
            canvasGame = GameObject.Find("Canvas_game");
            canvasMenu = GameObject.Find("Canvas_menu");
            canvasRestart = GameObject.Find("Canvas_restart");
            player = GameObject.FindGameObjectWithTag("Player");
            //player = Resources.Load("Prefabs/Player", typeof(GameObject)) as GameObject;

            canvasGame.SetActive(false);
            canvasRestart.SetActive(false);
            player.SetActive(false);// disable Player
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

            player.SetActive(true); // Enabled Player
            //Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject))); // Enabled Player
            bot = Instantiate(Resources.Load("Prefabs/Bot", typeof(GameObject))) as GameObject; // Enabled Bot
        }

        public void PreRestart(GameObject looser)
        {
            canvasGame.SetActive(false);
            canvasRestart.SetActive(true);
            
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
                    player.SetActive(false);
                }
                    
                preRestart = false; // without 2 winners
            }
            
        }

        public void Restart()
        {
            canvasGame.SetActive(true);
            canvasRestart.SetActive(false);
            preRestart = true;

            GoAI();
        }
    }
}