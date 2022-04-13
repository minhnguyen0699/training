using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    public int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        updateScore(5);
        Destroy(other.gameObject);
    }

    public void updateScore(int value)
    {
        Count += value;
        CounterText.text = "Score : " + Count;
    }
}
