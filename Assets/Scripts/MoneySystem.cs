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
}
