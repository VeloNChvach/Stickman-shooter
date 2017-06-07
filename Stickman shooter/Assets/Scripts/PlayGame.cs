using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    private void Start()
    {
        GameObject player = (GameObject)Resources.Load("Prefabs/Player", typeof(GameObject));
        if (player == null)
            Debug.Log("null");
        //Debug.Log(player.name);
        //Instantiate(player, new Vector2(-7.48f, 0), Quaternion.identity);
    }
}
