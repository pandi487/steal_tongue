using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Text itemDisplayer_Level;
    public Text itemDisplayer_Cost;
    public Text itemDisplayer_Sec;
    public Text itemDisplayer_ispurchased;

    public string itemName;

    public int level;

    [HideInInspector]
    public int currentCost;
    public int startCurrentCost = 1;

    [HideInInspector]
    public int goldPerSec;
    public int startGoldPerSec = 1;

    public float costPow = 3.14f;

    public float upgradePow = 1.07f;

    [HideInInspector]
    public bool isPurchased = false;

    private void Start()
    {
        DataController.GetInstance().LoadItemButton(this);

        StartCoroutine(AddGoldLoop());

        UpdateUI();
    }

    public void PurchaseItem()
    {
        if (DataController.GetInstance().GetGold() >= currentCost)
        {
            isPurchased = true;
            DataController.GetInstance().SubGold(currentCost);
            
            // level = level + 1
            level++;
            UpdateItem();
            UpdateUI();

            DataController.GetInstance().SaveItemButton(this);
        }
    }

    IEnumerator AddGoldLoop()
    {
        while (true)
        {
            if (isPurchased)
            {
                DataController.GetInstance().AddGold(goldPerSec);
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisplayer_Level.text =  "Lv. " + level;
        itemDisplayer_Cost.text =  "CurrentCost: " + currentCost;
        itemDisplayer_Sec.text =  "Gold Per Sec: " + goldPerSec;
        itemDisplayer_ispurchased.text =  "isPurchased: " + isPurchased;
    }


}
