using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stickman_shooter
{
    public class BulletController : MonoBehaviour
    {
        private float speed = 0.3f;
        private bool isPlayer;

        private void Start()
        {
            Destroy(gameObject, 3);
            // Who shoot
            if (transform.position.x < 0)
                isPlayer = true;
            else isPlayer = false;
        }

        private void FixedUpdate()
        {
            Vector3 position = transform.position;
            if (isPlayer)
                position.x += speed;
            else position.x -= speed;
            transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject); // Destroy bullet
            //Destroy(collision.gameObject); // Destroy Enemy
            collision.gameObject.SetActive(false);

            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
                GameObject.Find("Main").GetComponent<Main>().PreRestart(collision.gameObject);
        }
    }
}