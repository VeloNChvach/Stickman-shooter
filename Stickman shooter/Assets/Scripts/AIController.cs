using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stickman_shooter
{
    public class AIController : BaseController
    {
        private float fixedTime = 0;
        private float timeStep = 1;
        private Vector3 startPosEnemy = new Vector3(7.5f, 0, 0);
        private float shiftBulletX = -0.84f;
        private float moveTimeDelay = 0.5f;

        private void Start()
        {
            transform.position = startPosEnemy; // Set Enemy start position

            StartCoroutine(RndMoveAI()); // Periodical Enemy move
        }

        private IEnumerator RndMoveAI()
        {
            while (true)
            {
                if (Random.Range(0, 100) >= 50)
                {
                    MoveDown();
                    Shot();
                }
                else
                {
                    MoveUp();
                    Shot();
                }
                yield return new WaitForSeconds(moveTimeDelay);
            }
        }

        public void Shot()
        {
            // Shoot evere 'timeStep' seconds
            if (Time.time - fixedTime < timeStep)
                return;
            fixedTime = Time.time;

            // Instantiate bullet
            Vector3 startPosBul = new Vector3(transform.position.x + shiftBulletX, transform.position.y, transform.position.z); // start pos Bullet
            Instantiate(Resources.Load("Prefabs/Bullet", typeof(GameObject)), startPosBul, Quaternion.identity); // Instantiate bullet
        }
    }
}