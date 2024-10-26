using UnityEngine;
using System.Collections;
using System;

public class WindScript : MonoBehaviour
{

    public GameObject gemi;
    public GameObject Timer;

    public GameObject WindText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("StartWind", 7f);
        
    }

    // Update is called once per frame
    void StartWind()
    {
        Debug.Log("wind start");
        StartCoroutine(CallMyMethodEveryNSeconds(2.5f));
    }

    private IEnumerator CallMyMethodEveryNSeconds(float seconds)
    {
        while (true)
        {
            Wind();
            yield return new WaitForSeconds(seconds);
        }
    }

    void Wind()
    {   
        if (Timer.GetComponent<TimerScript>().gameOverCalled)
        {
            return;
        }

        if (gemi.GetComponent<GemiScript>().nextLevelCalled)
        {
            return;
        }

        float decision = UnityEngine.Random.Range(0f, 1f);

        if (decision > 0.5)
        {
            return;
        }

        int direction = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float amount = UnityEngine.Random.Range(-10f, 10f);

        Debug.Log("added wind" + direction + amount);

        WindText.GetComponent<WindTextScript>().updateText(Mathf.Round(amount * 10) / 10);
        gemi.GetComponent<GemiScript>().addWindForce(direction, amount);

    }
}
