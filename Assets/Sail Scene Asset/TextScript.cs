using UnityEngine;
using System.Collections;
using TMPro;
using System;
using Unity.VisualScripting;

public class TextScript : MonoBehaviour
{
    public GameObject Gemi;
    public TextMeshProUGUI textGroup;


    public float fadeDuration = 2;
    public float delayBetweenFades = 1f;

    void Start()
    {
        textGroup.alpha = 0;    
        // fade text in
        FadeIn();
    }

    private void FadeIn()
    {
        StartCoroutine(FadeTextIn(1));
    }

    private void FadeOut()
    {
        StartCoroutine(FadeTextOut(0));
    }

    private IEnumerator FadeTextIn(float targetAlpha)
    {
        float startAlpha = textGroup.alpha;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            textGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        textGroup.alpha = targetAlpha;
        StartCoroutine(keepText(delayBetweenFades));
    }

    private IEnumerator FadeTextOut(float targetAlpha)
    {
        float startAlpha = textGroup.alpha;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            textGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        textGroup.alpha = targetAlpha;

        if (Gemi != null)
        {
            Gemi.GetComponent<GemiScript>().StartShip(); 
        }
    }

    private IEnumerator keepText(float duration)
    {
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            yield return null;
        }
        FadeOut();
    }
}
