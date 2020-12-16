using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSystem : MonoBehaviour
{
    public GameObject Button;

    private bool pause = false;

    public void On(string changeOn)
    {
        
        if (pause)
        {
            Button.SetActive(true);
            Time.timeScale = 0;
        }

    }
    public void Off(string changeOff)
    {
        
        if (!pause)
        {
            Button.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
