﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager I { get { return DB; } }
    private static DataBaseManager DB;
    public List<CurrencyRateData> CoinData, CrystalData;
    public AnimationCurve[] AnimCurve;

    public float DiscountPercent;

    private void Awake()
    {
        if (DB == null) DB = this;
        else if (DB != null && DB != this)
        {
            Destroy(gameObject);
        }
    }
}
public enum SoundName 
{
    Purchased,
    Click,
    Toggle
}

public enum GameCurrencyType
{
    Coin,
    Crystal,
}

public enum RealCurrencyType
{
    Bath,
    USD,
    EURO
}

[System.Serializable]
public struct CurrencyRateData 
{
    public GameCurrencyType Type;
    public Sprite CurrencySprite;
    public Sprite Icon;
    public float Amount;
    public float Price;
    public float DiscountPercent;
}

