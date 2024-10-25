using System.Collections;
using TMPro;
using UnityEngine;

public class FadeText : MonoBehaviour
{
    TextMeshProUGUI text;
    public float Interval;
    private void Start() {
        text=GetComponent<TextMeshProUGUI>();
    }
    public void fadeInText(float speed){
        StartCoroutine(fadeIntextCoroutine(speed));
    }
    IEnumerator fadeIntextCoroutine(float speed){
        while(text.alpha<=1)
        {
            text.alpha+=speed*Interval;
            yield return new WaitForSeconds(Interval);
        }
    }
}
