using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TopPanelContainer : MonoBehaviour
{
    public Text CoinText, CrystalText;
    public float CoinAmount, CrystalAmount;
    public TimeSpan span;
    // Start is called before the first frame update
    void Start()
    {
        SetCurrency();
    }

    public void SetCurrency() 
    {
        CoinText.text = CoinAmount.ToString();
        CrystalText.text = CrystalAmount.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
