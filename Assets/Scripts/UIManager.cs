using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]  private Text _coins;

    void Start()
    {
        _coins.text = "Coins " + 0;
    }

    public void UpdateCoinsUI(int currentCoins)
    {
        _coins.text = "Coins " + currentCoins;
    }

}
