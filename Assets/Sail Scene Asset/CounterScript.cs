using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    private TextMeshProUGUI counter;
    private String baseText = "Number of collisions: ";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = GetComponent<TextMeshProUGUI>();
        counter.text = baseText + "0";
        //counter.enabled = false;
    }

    void Update()
    {
        
    }

    public void updateCount(int n)
    {
        String number = Convert.ToString(n);
        counter.text = baseText + number;
    }
}
