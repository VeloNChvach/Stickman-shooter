using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stickman_shooter
{
    public class PlayerController : BaseController
    {
        private float fixedTime = 0;
        private float timeStep = 1;
        private Vector3 startPosPlayer = new Vector3(-7.5f, 0, 0);
        private float shiftBulletX = 0.84f;

        private void Awake()
        {
            AddEventOnCanvasGame();
        }

        private void AddEventOnCanvasGame()
        {
            Button[] button = FindObjectsOfType<Button>();
            for (int i = 0; i < button.Length; i++)
            {
                if (button[i].name == "Btn_up")
                    button[i].onClick.AddListener(MoveUp);
                if (button[i].name == "Btn_down")
                    button[i].onClick.AddListener(MoveDown);
                if (button[i].name == "Btn_shot")
                    button[i].onClick.AddListener(Shot);
            }
        }

        private void Start()
        {
            transform.position = startPosPlayer; // Set Player start position
        }

        public void Shot()
        {
            // Shoot evere 'timeStep' seconds
            if (Time.time - fixedTime < timeStep)
                return;
            fixedTime = Time.time;

            base.Shot(shiftBulletX);
        }
    }
}