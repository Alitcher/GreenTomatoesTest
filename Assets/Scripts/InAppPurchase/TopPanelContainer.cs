using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TopPanelContainer : UserData
{
    public static TopPanelContainer I { get { return top; } }
    private static TopPanelContainer top;
    [SerializeField] private Text CoinText, CrystalText, LevelText;
    [SerializeField] private TextMeshProUGUI TimeRemainingText;
    [SerializeField] private Image CoinIcon, CrystalIcon;
    [SerializeField] private TimeSpan span;

    private DateTime destination;
    private void Awake()
    {
        if (top == null) top = this;
        else if (top != null && top != this)
        {
            Destroy(gameObject);
        }
        SetInfo();
    }

    private void Update()
    {
        span = destination - DateTime.Now;
        TimeRemainingText.text = String.Format("{0}:{1}:{2}", span.Hours.ToString("D2"), span.Minutes.ToString("D2"), span.Seconds.ToString("D2"));
    }

    public void SetInfo() 
    {
        destination = DateTime.Now.AddDays(1);

        CoinText.text = CoinAmount.ToString();
        CrystalText.text = CrystalAmount.ToString();
        LevelText.text = Level.ToString(); //"1";//
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
        SetInfo();
    }
}
