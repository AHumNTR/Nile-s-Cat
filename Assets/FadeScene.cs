using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeScene : MonoBehaviour
{
    Image image;
    public float Interval;
    private void Start() {
        image=GetComponent<Image>();
    }
    public void fadeInText(float speed){
        StartCoroutine(fadeIntextCoroutine(speed));
    }
    IEnumerator fadeIntextCoroutine(float speed){
        while(image.color.a<=1)
        {
            image.color+=speed*Interval*Color.black;//black for only transperancy
            yield return new WaitForSeconds(Interval);
        }
    }
}
