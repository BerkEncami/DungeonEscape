using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    IHealth _playerHealth;
    [SerializeField]
    GameObject GameOverPanel;
 
    private void OnEnable()
    {
        GameOverPanel.SetActive(false);
       
    }

    private void HandleOnDead()
    {
        GameOverPanel.SetActive(true);
        _playerHealth.OnDead -= HandleOnDead;
        _playerHealth = null;
    }

    public void SetPlayerHealth(IHealth playerHealth)
    {
        _playerHealth = playerHealth;
        _playerHealth.OnDead += HandleOnDead;
    }
}
