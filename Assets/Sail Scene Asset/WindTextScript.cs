using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindTextScript : MonoBehaviour
{

    TextMeshProUGUI textArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textArea = GetComponent<TextMeshProUGUI>();
        textArea.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText(float amount)
    {
        textArea.text = Convert.ToString(amount) + "km/h";
    }
}
