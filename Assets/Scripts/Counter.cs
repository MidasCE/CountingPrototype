using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    
    private int _count = 0;

    public void EnableCounter()
    {
        _count = 0;
        CounterText.text = "Score: 0";
        CounterText.gameObject.SetActive(true);
    }

    public void DisableCounter()
    {
        Reset();
        CounterText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            other.gameObject.tag = "Bad";
            _count += 1;
            CounterText.text = "Score: " + _count;
        }
    }

    public void Reset()
    {
        _count = 0;
    }
}
