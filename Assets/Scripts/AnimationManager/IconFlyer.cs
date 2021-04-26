using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconFlyer : MonoBehaviour
{
    private Transform SpawnPointPos,TargetPos;
    [SerializeField] private float m_Duration = 1f, m_percentage;
    [SerializeField] private Sprite[] Icon;
    private float m_current= 0f;

    public GameCurrencyType IconType;

    private void Start()
    {
        if (SpawnPointPos == null) SpawnPointPos = this.transform;
        TargetPos = (IconType == GameCurrencyType.Coin) ? DataBaseManager.I.Target[0] : DataBaseManager.I.Target[1];
        this.gameObject.GetComponent<SpriteRenderer>().sprite = (IconType == GameCurrencyType.Coin)? Icon[0]: Icon[1];
    }

    void FixedUpdate()
    {
        m_percentage = m_current / m_Duration;
        if (m_percentage < 0.9f)
        {
            m_current += Time.deltaTime;
            this.transform.position = Vector3.Lerp(SpawnPointPos.position, TargetPos.position, m_percentage);
        }
        else
            Destroy(gameObject);
    }
}
