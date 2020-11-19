using System;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    public Action<TouchPhase> GetAction;

    private void OnEnable()
    {
        GetAction += (state) =>
        {
            if (state == TouchPhase.Began)
            {
                Debug.Log("Start");
            }
        };
    }


    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
        }
#endif
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            switch (touch.phase)
            {
                // 터치가 처음 시작했을 때
                case TouchPhase.Began:
                    break;
                // 터치가 처음 시작되고 움직일 때
                case TouchPhase.Moved:
                    break;
                // 터치가 Moved 상태였다가 멈췄을 때
                case TouchPhase.Stationary:
                    break;
                // 화면에서 손을 땠을 때
                case TouchPhase.Ended:
                    break;
                // 시스템에 의해서 손을 땠을 때 (전화가 오거나..)
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }
            GetAction?.Invoke(touch.phase);
        }
    }
}
