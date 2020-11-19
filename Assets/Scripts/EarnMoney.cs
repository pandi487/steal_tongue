using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnMoney
{
    public float Earn(float currentMoney = 0f, float increaseAmount = 1f)
    {
        return currentMoney + increaseAmount;
    }

}
