using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TopPanelContainer : MonoBehaviour
{
    public static TopPanelContainer I { get { return top; } }
    private static TopPanelContainer top;
    public Text CoinText, CrystalText;
    public TimeSpan span;

    private float CoinAmount, CrystalAmount;

    private void Awake()
    {
        if (top == null) top = this;
        else if (top != null && top != this)
        {
            Destroy(gameObject);
        }
        SetCurrency();
    }

    public void SetCurrency() 
    {
        CoinText.text = CoinAmount.ToString();
        CrystalText.text = CrystalAmount.ToString();
    }
    // Update is called once per frame
    public void UpdateCurrency(GameCurrencyType type,float amount)
    {
        switch (type)
        {
            case GameCurrencyType.Coin:
                CoinAmount += amount;
                break;
            case GameCurrencyType.Crystal:
                CrystalAmount += amount;
                break;
            default:
                break;
        }
        SetCurrency();
    }
}
