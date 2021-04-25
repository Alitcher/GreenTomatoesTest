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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetThisBoxData(CurrencyRateData dataIndex) 
    {
        string[] getindex = this.gameObject.name.Split('_');

        AmountText.text = dataIndex.Amount.ToString();
        PriceText.text = dataIndex.Price + " USD";
        DoubleExpText.text = int.Parse(getindex[1])+1 + "h of Double EXP";
        FullPriceText.gameObject.SetActive(m_Data.DiscountPercent<=0);
    }
}
