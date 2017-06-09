using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stickman_shooter
{
    public abstract class BaseController : MonoBehaviour
    {
        private float upLimit = 4f;
        private float downLimit = -4f;
        private float step = 1f;

        public virtual void MoveUp()
        {
            if (transform.position.y < upLimit)
                transform.position += new Vector3(0, step, 0);
            else
                transform.position = new Vector3(transform.position.x, upLimit, transform.position.z);
        }

        public virtual void MoveDown()
        {
            if (transform.position.y > downLimit)
                transform.position += new Vector3(0, -step, 0);
            else
                transform.position = new Vector3(transform.position.x, downLimit, transform.position.z);
        }
    }
}