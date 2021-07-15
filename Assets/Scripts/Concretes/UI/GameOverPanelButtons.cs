using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanelButtons : MonoBehaviour
{
    public void YesButton()
    {
        GameManager.Instance.SplashScreen(SceneType.Game);
        
    }
    public void NoButton()
    {
        GameManager.Instance.SplashScreen(SceneType.Menu);
    }
}
