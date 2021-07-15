using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.SplashScreen(SceneType.Game);
    }
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
