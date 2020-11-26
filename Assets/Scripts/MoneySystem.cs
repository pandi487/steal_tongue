using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public float m_fCurrentMoney = 0f; //현재 머니
    public float m_fIncreaseMoneyAmount = 10f; // 증가 머니
    public string m_fCurrentMoneyText; // 현재 머니 텍스트

    private EarnMoney earnMoney = null;

    [SerializeField] private float Division = 0;// 속도

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
        StartCoroutine(NeglectRoutine());
    }

    IEnumerator NeglectRoutine()
    {
        while(true)
        {
            m_fCurrentMoney += 1;
            yield return new WaitForSeconds(10f / Division); // + Division 감소 // - Division 증가 
        }
    }
    
    void Update()
    {
        m_fCurrentMoneyText = m_fCurrentMoney.ToString("N0");
        GetComponent<UnityEngine.UI.Text>().text = m_fCurrentMoneyText;
       // m_fUpgradeMoneyText = UpgradeSystem.m_fUpgradeMoney.ToString("NO");
    }

}
