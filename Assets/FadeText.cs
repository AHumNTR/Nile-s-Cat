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

    public void fadeInThenOutText(float speed,float waitTime){
        StopAllCoroutines();
        StartCoroutine(fadeInThenOutCoroutine(speed,waitTime));
    }

    public void fadeWaitThenOutText(float speed,float waitTime){
        StopAllCoroutines();
        StartCoroutine(fadeInThenOutCoroutine(speed,waitTime));
    }

    IEnumerator fadeIntextCoroutine(float speed){
        while(text.alpha<=1)
        {
            text.alpha+=speed*Interval;
            yield return new WaitForSeconds(Interval);
        }
    }

    IEnumerator fadeWaitThenOuttextCoroutine(float speed, float waitTime){
        yield return new WaitForSeconds(waitTime);
        while(text.alpha>=0)
        {
            text.alpha-=speed*Interval;
            yield return new WaitForSeconds(Interval);
        }
    }

    IEnumerator fadeInThenOutCoroutine(float speed,float waitTime){

        while(text.alpha<=1)
        {
            text.alpha+=speed*Interval;
            yield return new WaitForSeconds(Interval);
        }
        yield return new WaitForSeconds(waitTime);
        while(text.alpha>=0)
        {
            text.alpha-=speed*Interval;
            yield return new WaitForSeconds(Interval);
        }
    }
}
