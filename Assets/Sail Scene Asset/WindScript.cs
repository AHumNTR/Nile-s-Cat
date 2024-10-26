using UnityEngine;
using System.Collections;

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
        float decision = Random.Range(0f, 1f);

        if (decision > 0.5)
        {
            return;
        }

        int direction = Random.Range(0, 2) == 0 ? -1 : 1;
        float amount = Random.Range(-1f, 1f);

        Debug.Log("added wind" + direction + amount);

        
        gemi.GetComponent<GemiScript>().addWindForce(direction, 15*amount);

    }
}
