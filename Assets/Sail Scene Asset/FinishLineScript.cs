using Unity.VisualScripting;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{

    public GameObject Timer;
    public GameObject gemi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("finish line trigerred");

        Timer.GetComponent<TimerScript>().gameOverCalled = true; // prevents game over if finish line passed

        if (collider.tag == "gemi")
        {
            gemi.GetComponent<GemiScript>().nextLevel();
        }
    }
}
