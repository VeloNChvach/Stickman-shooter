using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public void MoveUp()
    {
        Debug.Log("Up");
        Main.Instance.PlayerController.MoveUp();
    }

    public void MoveDown()
    {
        Debug.Log("Down");
    }
}
