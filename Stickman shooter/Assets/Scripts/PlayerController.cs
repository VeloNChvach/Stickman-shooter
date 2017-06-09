using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stickman_shooter
{
    public class PlayerController : BaseController
    {
        private float fixedTime = 0;
        private float timeStep = 1;
        private Vector3 startPosPlayer = new Vector3(-7.5f, 0, 0);
        private float shiftBulletX = 0.84f;

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

            // Instantiate bullet
            Vector3 startPosBul = new Vector3(transform.position.x + shiftBulletX, transform.position.y, transform.position.z); // start pos Bullet
            Instantiate(Resources.Load("Prefabs/Bullet", typeof(GameObject)), startPosBul, Quaternion.identity);
        }
    }
}