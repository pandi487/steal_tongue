using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSystem : MonoBehaviour
{
    public MoneySystem moneySystem;
    [SerializeField] private float Division = 0;//머니 들어오는 시간 (방치)
    public int IdleMoneyUpgrade =0;
    public string IdleMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Idle());
    }

    // Update is called once per frame
    void Update()
    {
        IdleMoneyText = IdleMoneyUpgrade.ToString("N0"); // 머니 업그레이드 텍스트 출력 (소숫점 안보이게)
        GetComponent<UnityEngine.UI.Text>().text = IdleMoneyText;
    }

    IEnumerator Idle()
    {
        while (true)
        {
            moneySystem.m_fCurrentMoney += 10;

            yield return new WaitForSecondsRealtime(Division); // + Division 감소 // - Division이 1이면 10초 2면 5초   
        }
    }
    public void IdleUpgrade()
    {
        if ((moneySystem.m_fCurrentMoney - IdleMoneyUpgrade) <= 0)
        {
            return;
        }
        if (moneySystem.m_fCurrentMoney >= IdleMoneyUpgrade)
        {
            IdleMoneyUpgrade = IdleMoneyUpgrade * 2;   // 업그레이드 비용 증가의 증가
            moneySystem.m_fCurrentMoney -= IdleMoneyUpgrade;   // 업그레이드 비용 소모
            Division -= 0.1f;
        }
    }

}
