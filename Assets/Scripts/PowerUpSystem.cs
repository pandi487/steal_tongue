using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    public float Timer;
   // UnityEngine.UI.Text TextTimer;
    public string TextTimer; // 머니 업그레이드 텍스트

    bool OnTimer;
    public MoneySystem moneySystem;

    IEnumerator _ETimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextTimer = Timer.ToString("N0");
        GetComponent<UnityEngine.UI.Text>().text = TextTimer;
    }
    public void Power()
    {
        if (_ETimer == null)
        {
            _ETimer = _Timer();
            StartCoroutine(_ETimer);   
        }
        
    }
    IEnumerator _Timer()
    {
        moneySystem.m_fIncreaseMoneyAmount *= 10;
        while (Timer > 0)
        {
            Timer -= Time.deltaTime;

            yield return null;
        }
        moneySystem.m_fIncreaseMoneyAmount /= 10;
        Timer = 10;

        for (float i = 0; i < 10f; i += Time.deltaTime)
        {
            Timer -= Time.deltaTime;

            yield return null;
        }
        Timer = 5;
        _ETimer = null;
    }
}
