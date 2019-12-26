using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]    private Text _coins;
    [SerializeField]    private Text _lives;

    void Start()
    {
        _coins.text = "Coins: " + 0;
        //_lives.text = "Lives: " + 3;
    }

    public void UpdateCoinsUI(int currentCoins)
    {
        _coins.text = "Coins: " + currentCoins;
    }

    public void UpdateLivesUI(int currentLives)
    {
        _lives.text = "Lives: " + currentLives.ToString();
    }
}
