using UnityEngine;
using System.Collections;
using System;

// to do list
// - random event
// - game over scene
// - next level scene


public class BackgroundScript : MonoBehaviour
{   
    public float sceneDuration = 12f;
    public Vector3 targetPosition;
    
    public GameObject background;

    void Start()
    {
        targetPosition = new Vector3(0, -20,0);
    }

    void Update()
    {
        
    }

    public void StartShip()
    {
        Debug.Log("ship start");
        // SlideBackground();
    }

    private void SlideBackground()
    {
        StartCoroutine(SlideToPos(targetPosition, sceneDuration));
    }

    private IEnumerator SlideToPos(Vector3 target, float duration)
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, target, elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
   
}
