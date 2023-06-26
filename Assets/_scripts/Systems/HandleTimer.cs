using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTimer : MonoBehaviour
{
    public delegate void TimeReference(float currentTime);
    public static event TimeReference OnTimeReference;

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        OnTimeReference?.Invoke(elapsedTime);
    }
}
