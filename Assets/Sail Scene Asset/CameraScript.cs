using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform ship;
    public GameObject gemi;
    private Vector3 newVector;

    private float cameraMaxY = 32.6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per 
    void Update()
    {
        if (!gemi.GetComponent<GemiScript>().shipStopped)
        {
            float shipY = ship.transform.position.y;
            shipY = Mathf.Clamp(shipY, -10f, cameraMaxY);

            newVector = new Vector3(0, 3f + shipY, -10f);
            transform.position = newVector;

            transform.rotation = Quaternion.Euler(0,0,0);   
        }
    }

    public void slideOff()
    {
        StartCoroutine(SlideCamera());
    }
    
    private IEnumerator SlideCamera()
    {
        float time = 0f;
        float startY = transform.position.y;
        float targetY = startY + 0.6f;

        // Debug.Log($"Start Position: {startY}, Target Position: {targetY}");

        while (time < 0.7f)
        {
            time += Time.deltaTime;
            float newY = Mathf.Lerp(startY, targetY, time/0.7f);
            transform.position =  new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);

        gemi.GetComponent<GemiScript>().GameOver();
    }
}