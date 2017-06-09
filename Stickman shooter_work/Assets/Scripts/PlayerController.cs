using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Awake()
    {
        //player.transform.position = new Vector3(5, 0, 25);
    }

    public void MoveUp()
    {
        Debug.Log("MoveUp");
        //gameObject.transform.Translate(-5, 0, 0);
    }

}
