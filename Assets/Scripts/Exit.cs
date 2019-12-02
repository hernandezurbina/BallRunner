using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void exitGame() {
        Debug.Log("You pressed the exit button!");
        Application.Quit();
    }
}
