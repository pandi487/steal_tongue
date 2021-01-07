using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer;

    public Text goldPerClickDisplayer;

    public Text goldPerSecDisplayer;

    private void Update()
    {
        goldDisplayer.text = " " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "클릭당 골드: " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisplayer.text = "초당 골드: " + DataController.GetInstance().GetGoldPerSec();
    }
}
