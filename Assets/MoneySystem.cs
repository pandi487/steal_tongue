using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] float m_fCurrentMoney = 0f;
    [SerializeField] float m_fIncreaseMoneyAmount = 10f;

    private EarnMoney earnMoney = null;

    private void Awake()
    {
        earnMoney = Activator.CreateInstance(typeof(EarnMoney)) as EarnMoney;
        
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
            Debug.Log(m_fCurrentMoney);
            yield return null;
        }
    }
}
