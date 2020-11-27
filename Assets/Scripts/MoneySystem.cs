using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public float m_fCurrentMoney = 0f; //현재 머니
    public float m_fIncreaseMoneyAmount = 10f; // 증가 머니
    public string m_sCurrentMoneyText; // 현재 머니 텍스트

    private EarnMoney earnMoney = null;

    public int m_fUpgradeMoney = 0; // 머니 업그레이드 비용
    public string m_fUpgradeMoneyText; // 머니 업그레이드 텍스트
    
    private void Awake()
    {
        earnMoney = new EarnMoney();
        
    }

    private void OnEnable()
    {
        TouchSystem.GetAction += EarnMoney;
        StartCoroutine(SystemLoop());
    }
    private void OnDisable()
    {
        TouchSystem.GetAction -= EarnMoney;
    }

    public void EarnMoney(TouchPhase touchPhase) => m_fCurrentMoney = earnMoney.Earn(m_fCurrentMoney, m_fIncreaseMoneyAmount);
    IEnumerator SystemLoop()
    {
        while (gameObject.activeInHierarchy)
        {
            //Debug.Log(m_fCurrentMoney);
            yield return null;
        }
    }
   //  ---10초마다 머니 생성 실패
    void Start() 
    {

    }
    
    void Update()
    {
        m_sCurrentMoneyText = m_fCurrentMoney.ToString("N0");
        GetComponent<UnityEngine.UI.Text>().text = m_sCurrentMoneyText;
       // m_fUpgradeMoneyText = UpgradeSystem.m_fUpgradeMoney.ToString("NO");
    }

}
