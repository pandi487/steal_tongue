using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steal_Tongue.Adapter;
using Random = UnityEngine.Random;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] float m_fCurrentMoney = 0f;
    [SerializeField] float m_fIncreaseMoneyAmount = 10f;
    public string m_fCurrentMoneyText; // 현재 머니 텍스트

    private EarnMoney earnMoney = null;

    [SerializeField] private float Division = 0;// 속도

    public int m_fUpgradeMoney = 0; // 머니 업그레이드 비용
    public string m_fUpgradeMoneyText; // 머니 업그레이드 텍스트
    
    private EarnMoney earnMoney = null;
    private UIAdapter uiAdapter = null;

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