using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] float m_fCurrentMoney = 0f; //현재 머니
    [SerializeField] float m_fIncreaseMoneyAmount = 10f; // 증가 머니

    private EarnMoney earnMoney = null;

    [SerializeField] private int multiple = 0;// 속도
    string m_fCurrentMoneyText; // 현재 머니 텍스트

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
    /* ---10초마다 머니 생성 실패
    void Start() 
    {
        StartCoroutine("testCoroutine"); 
    }
    IEnumerator testCoroutine()
    {
        while(true)
        {

            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
    */
    void Update()
    {
        m_fCurrentMoney += Time.deltaTime * multiple;
        m_fCurrentMoneyText = m_fCurrentMoney.ToString("N0");
        GetComponent<UnityEngine.UI.Text>().text = m_fCurrentMoneyText;
    }

}
