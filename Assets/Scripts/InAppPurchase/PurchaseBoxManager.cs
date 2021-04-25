using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseBoxManager : MonoBehaviour
{
    public Text AmountText, PriceText, DoubleExpText;
    public TextMeshProUGUI FullPriceText;
    public Image CurrencyImage, CurrencyIcon;
    public GameObject BoostGO;
    public CurrencyRateData m_Data;

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

    private void SetThisBoxData() 
    {
        if (this.name == "ShopBox") return;
        string[] getindex = this.gameObject.name.Split('_');

        AmountText.text = m_Data.Amount.ToString();
        PriceText.text = m_Data.Price + " "+RealCurrencyType.USD.ToString();
        DoubleExpText.text = int.Parse(getindex[1])+1 + "h of Double EXP";
        FullPriceText.gameObject.SetActive(m_Data.DiscountPercent> 0);

        CurrencyImage.sprite = m_Data.CurrencySprite;
        CurrencyIcon.sprite = m_Data.Icon;
    }

    public void PurchaseItemInThisBox() 
    {
        TopPanelContainer.I.UpdateCurrency(m_Data.Type,m_Data.Amount);
    }
}
