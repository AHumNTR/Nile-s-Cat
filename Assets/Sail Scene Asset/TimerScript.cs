using System;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public bool gameOverCalled = false;
    private TextMeshProUGUI timer;
    public GameObject gemi;

    public float time = 15f;
    private String baseText = "Time left: ";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        timer.text = baseText + "15";
    }

    void Update()
    {
        if (gemi.GetComponent<GemiScript>().startTimer)
        {
            time -= Time.deltaTime;
            timer.text = Convert.ToString(Mathf.Round(time*10f) / 10f);

            if (time <= 0)
            {
                if (!gameOverCalled)
                {
                    gemi.GetComponent<GemiScript>().StopShip();
                    gameOverCalled = true;
                    Debug.Log("game over called by timer class");
                }

                timer.text = "0";
            }
        }
    }

}
