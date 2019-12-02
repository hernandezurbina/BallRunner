using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public void reStartGame() {
        SceneManager.LoadScene("MainScene");
    }

    public void exitGame() {
        Debug.Log("Exit button pressed!");
        Application.Quit();
    }
}
