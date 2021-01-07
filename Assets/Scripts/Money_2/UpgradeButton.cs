using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    //Cost = 비용
    //Gold = 증가
    public Text upgradeDisplayer_Cost;
    public Text upgradeDisplayer_Level;
    public Text upgradeDisplayer_NextGold;

    public string upgradeName;

    [HideInInspector]
    public int goldByUpgrade;           // 업그레이드 될 때마다 증가될 골드량
    public int startGoldByUpgrade = 1;

    [HideInInspector]
    public int currentCost = 1;        // 지불해야 될 골드 비용
    public int startCurrentCost = 1;

    [HideInInspector]
    public int level = 1;

    public float upgradePow = 1.07f;

    public float costPow = 3.14f;

    private void Start()
    {
        DataController.GetInstance().LoadUpgradeButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        if (DataController.GetInstance().GetGold() >= currentCost)
        {
            DataController.GetInstance().SubGold(currentCost);
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);

            UpdateUpgrade();
            UpdateUI();
            DataController.GetInstance().SaveUpgradeButton(this);
        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);

        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        upgradeDisplayer_Cost.text = " ";
        upgradeDisplayer_Level.text =  "Lv." + level;
        upgradeDisplayer_NextGold.text =  "골드증가 + " + goldByUpgrade;
    }

    [ContextMenu("RESET_UPGRADE_BUTTON_DATA")]  
    public void ResetUpgradeButtonData()
    {
        DataController.GetInstance().ResetUpgradeButtonData(this);
    }
}
