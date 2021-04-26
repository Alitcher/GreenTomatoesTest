using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PromotionManager : MonoBehaviour
{
    [SerializeField] private GameObject PromotionBar;
    [SerializeField] private TextMeshProUGUI m_HeaderText, m_DetailText;

    // Start is called before the first frame update
    void Start()
    {
        SetPromotion();
        DataBaseManager.I.OnDiscountOver = DisablePromotion;
    }

    private void SetPromotion() 
    {
        m_DetailText.text = $"-{DataBaseManager.I.DiscountPercent}% OFF";
    }

    public void DisablePromotion()
    {
        DataBaseManager.I.DiscountPercent = 0;
        foreach (GameObject item in DataBaseManager.I.CoinBoxes)
        {
            item.GetComponent<PurchaseBoxManager>().NormalizeInfo();
        }
        foreach (GameObject item in DataBaseManager.I.CrystalBoxes)
        {
            item.GetComponent<PurchaseBoxManager>().NormalizeInfo();
        }
        PromotionBar.SetActive(false);
    }
}
