using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject BoxGo;
    public RectTransform ShopTransform;
    // Start is called before the first frame update
    private void Awake()
    {

    }

    private void Start()
    {
        for (int i = 0; i < ShopTransform.childCount; i++)
        {
            ShopTransform.GetChild(i).gameObject.SetActive(false); ;
        }
        for (int i = 0; i < DataBaseManager.I.CoinData.Count; i++)
        {
            GameObject coinGo = Instantiate(BoxGo, ShopTransform);
            coinGo.SetActive(true);
            coinGo.transform.SetParent(ShopTransform,false);
            coinGo.name = "CoinData_" + i;
            SetBoxAmount(coinGo, i, DataBaseManager.I.CoinData);
        }
    }

    private void SetBoxAmount(GameObject gameCurrencyTypeGO ,int index, List<CurrencyRateData> data) 
    {
        PurchaseBoxManager box = gameCurrencyTypeGO.GetComponent<PurchaseBoxManager>();
        box.m_Data = data[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
