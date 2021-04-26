using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData I { get { return DB; } }
    private static UserData DB;
    public float CoinAmount, CrystalAmount;
    public int Level = 1;
    public static int PurchaseCount;
    // Start is called before the first frame update

    private void Awake()
    {
        if (DB == null) DB = this;
        else if (DB != null && DB != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
    }



}
