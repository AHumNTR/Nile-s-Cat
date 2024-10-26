using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class WindScript : MonoBehaviour
{

    public GameObject gemi;
    public GameObject Timer;

    public GameObject WindText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("StartWind", 6f);
        GetComponent<RawImage>().enabled = false;
    }

    // Update is called once per frame
    void StartWind()
    {
        Debug.Log("wind start");
        StartCoroutine(CallMyMethodEveryNSeconds(2f));
    }

    private IEnumerator CallMyMethodEveryNSeconds(float seconds)
    {
        while (true)
        {
            if (Timer.GetComponent<TimerScript>().gameOverCalled)
            {
                break;
            }

            if (gemi.GetComponent<GemiScript>().nextLevelCalled)
            {
                break;
            }

            Wind();

            yield return new WaitForSeconds(seconds);

            Debug.Log("called wind in while");
        }
        Debug.Log("out of while");
    }

    void Wind()
    {   
        float decision = UnityEngine.Random.Range(0f, 1f);

        if (decision > 0.75)
        {
            return;
        }

        int direction = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float amount = UnityEngine.Random.Range(-10f, 10f);

        Debug.Log("added wind" + direction + amount);

        WindText.GetComponent<WindTextScript>().updateText(Mathf.Round(amount * 10) / 10);

        if (amount > 0) {
            GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            GetComponent<RawImage>().enabled = true;

        } else if (amount < 0)
        {
            GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
            GetComponent<RawImage>().enabled = true;
        } else {
            GetComponent<RawImage>().enabled = false;
        }


        gemi.GetComponent<GemiScript>().addWindForce(direction, amount);

    }
}
