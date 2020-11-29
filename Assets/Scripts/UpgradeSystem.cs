using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{

    public MoneySystem moneySystem;
    

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        moneySystem.m_fUpgradeMoneyText = moneySystem.m_fUpgradeMoney.ToString("N0"); // 머니 업그레이드 텍스트 출력 (소숫점 안보이게)
        GetComponent<UnityEngine.UI.Text>().text = moneySystem.m_fUpgradeMoneyText;
        //  moneySystem =  GameObject.Find("MoneyText").GetComponent<MoneySystem>();
    }

    public void Upgrade()
    {
        if ((moneySystem.m_fCurrentMoney - moneySystem.m_fUpgradeMoney) <= 0)
        {
            return;
            
        }
        if (moneySystem.m_fCurrentMoney >= moneySystem.m_fUpgradeMoney)
        {
            moneySystem.m_fUpgradeMoney = moneySystem.m_fUpgradeMoney * 1;   // 업그레이드 비용 증가의 증가
            moneySystem.m_fCurrentMoney -= moneySystem.m_fUpgradeMoney;   // 업그레이드 비용 소모
            //moneySystem.m_fUpgradeMoney += moneySystem.m_fUpgradeMoney ; // 업그레이드 비용 증가
        }

    }
}

