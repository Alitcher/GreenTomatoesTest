using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject BoxGo;
    public RectTransform CoinTransform, CrystalTransform;
    // Start is called before the first frame update
    private void Awake()
    {

    }

    private void Start()
    {
        SpawnCurrencyBox();
    }

    private void SpawnCurrencyBox() 
    {
        for (int i = 0; i < CoinTransform.childCount; i++)
        {
            CoinTransform.GetChild(i).gameObject.SetActive(false); ;
        }
        for (int i = 0; i < DataBaseManager.I.CoinData.Count; i++)
        {
            GameObject coinGo = Instantiate(BoxGo, CoinTransform);
            coinGo.SetActive(true);
            coinGo.transform.SetParent(CoinTransform, false);
            coinGo.name = "CoinData_" + i;
            SetBoxAmount(coinGo, i, DataBaseManager.I.CoinData);
            DataBaseManager.I.CoinBoxes.Add(coinGo);
        }

        for (int i = 0; i < CrystalTransform.childCount; i++)
        {
            CrystalTransform.GetChild(i).gameObject.SetActive(false); ;
        }
        for (int i = 0; i < DataBaseManager.I.CrystalData.Count; i++)
        {
            GameObject crystalGo = Instantiate(BoxGo, CrystalTransform);
            crystalGo.SetActive(true);
            crystalGo.transform.SetParent(CrystalTransform, false);
            crystalGo.name = "CrystalData_" + i;
            SetBoxAmount(crystalGo, i, DataBaseManager.I.CrystalData);
            DataBaseManager.I.CrystalBoxes.Add(crystalGo);

        }
    }
    private void SetBoxAmount(GameObject gameCurrencyTypeGO ,int index, List<CurrencyRateData> data) 
    {
        PurchaseBoxManager box = gameCurrencyTypeGO.GetComponent<PurchaseBoxManager>();
        box.OnDiscountOver = DataBaseManager.I.OnDiscountOver;
        box.m_Data = data[index];
    }

    // Update is called once per frame



}
