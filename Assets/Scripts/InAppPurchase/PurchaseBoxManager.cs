using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PurchaseBoxManager : MonoBehaviour
{
    public Text AmountText, PriceText, DoubleExpText;
    public TextMeshProUGUI FullPriceText;
    public Image CurrencyImage, CurrencyIcon;
    public GameObject BoostGO, FlyingGo;
    public CurrencyRateData m_Data;
    public Action OnDiscountOver;
    [SerializeField] private float AmountF, PriceF, DoubleExpF, FullPriceF;

    // Start is called before the first frame update
    void Start()
    {
        SetThisBoxData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NormalizeInfo() 
    {
        FullPriceText.gameObject.SetActive(false);
        PriceText.text = m_Data.Price.ToString();
        PriceText.text += " " + RealCurrencyType.USD.ToString();

    }
    private void SetThisBoxData() 
    {
        if (this.name == "ShopBox") return;
        string[] getindex = this.gameObject.name.Split('_');

        AmountText.text = m_Data.Amount.ToString();
        PriceText.text = (DataBaseManager.I.DiscountPercent > 0) ? (m_Data.Price * ((100 - DataBaseManager.I.DiscountPercent) / 100)).ToString() : m_Data.Price.ToString();
        PriceText.text += " "+RealCurrencyType.USD.ToString();
        FullPriceText.gameObject.SetActive(DataBaseManager.I.DiscountPercent > 0);
        FullPriceText.text = m_Data.Price + " " + RealCurrencyType.USD.ToString();
        DoubleExpText.text = int.Parse(getindex[1])+1 + "h of Double EXP";

        CurrencyImage.sprite = m_Data.CurrencySprite;
        CurrencyIcon.sprite = m_Data.Icon;
    }

    public void PurchaseItemInThisBox() 
    {
        TopPanelContainer.I.UpdateCurrency(m_Data.Type,m_Data.Amount);
        UserData.PurchaseCount++;
        if (DataBaseManager.I.IsPromotionOff())
        {
            DataBaseManager.I.OnDiscountOver.Invoke();
            SetThisBoxData();
        }
        StartCoroutine(FlyToTarget());
    }

    IEnumerator FlyToTarget() 
    {
        for (int i = 0; i < m_Data.IconToFlyAmount; i++)
        {
            GameObject spawnObject = Instantiate(FlyingGo, CurrencyImage.GetComponent<RectTransform>().transform);
            spawnObject.GetComponent<IconFlyer>().IconType = m_Data.Type;
            spawnObject.transform.SetParent(DataBaseManager.I.transform);
            spawnObject.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(0.1f);
        }
    }


}
