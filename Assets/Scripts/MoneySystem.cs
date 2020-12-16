using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steal_Tongue.Adapter;
using Random = UnityEngine.Random;

public class MoneySystem : MonoBehaviour
{

    public float m_fCurrentMoney = 0f; //현재 머니
    public float m_fIncreaseMoneyAmount = 10f; // 증가 머니
    public string m_sCurrentMoneyText; // 현재 머니 텍스트

    public string m_fCurrentMoneyText; // 현재 머니 텍스트


    private EarnMoney earnMoney = null;

    public int m_fUpgradeMoney = 0; // 머니 업그레이드 비용
    public string m_fUpgradeMoneyText; // 머니 업그레이드 텍스트
    
    private UIAdapter uiAdapter = null;

    public float Division { get; private set; } = 1;

    private void Awake()
    {
        earnMoney = Activator.CreateInstance(typeof(EarnMoney)) as EarnMoney;

        uiAdapter = FindObjectOfType<UIAdapter>();
    }

    private void Start()
    {
        Debug.Assert(uiAdapter != null);
    }

    private void OnEnable()
    {
        TouchSystem.GetAction += EarnMoney;
        StartCoroutine(SystemLoop());
        StartCoroutine(NeglectRoutine());
    }
    private void OnDisable()
    {
        TouchSystem.GetAction -= EarnMoney;
    }

    public void EarnMoney(TouchPhase touchPhase) => m_fCurrentMoney = earnMoney.Earn(m_fCurrentMoney, m_fIncreaseMoneyAmount);
    public void EarnMoney(float _increaseAmount) => m_fCurrentMoney = earnMoney.Earn(m_fCurrentMoney, _increaseAmount);

    IEnumerator SystemLoop()
    {
        while (gameObject.activeInHierarchy)
        {
            uiAdapter.m_MoneyText.text = m_fCurrentMoney.ToString();
            yield return null;
        }

    }
   //  ---10초마다 머니 생성 실패
    
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
        m_sCurrentMoneyText = m_fCurrentMoney.ToString("N0");
       // m_fUpgradeMoneyText = UpgradeSystem.m_fUpgradeMoney.ToString("NO");
    }
}