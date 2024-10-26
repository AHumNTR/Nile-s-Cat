using UnityEngine;

public class Crystal : MonoBehaviour
{
    Color[] states = new Color[6];
    int statesIdx = 0;
    int states2Idx = 1;

    float lerpTime = 0f; 
    public float transitionSpeed = 2.0f; 

    void Start()
    {
        states[0] = new Color(1, 1, 0.5f);
        states[1] = new Color(1, 0.5f, 0.5f);
        states[2] = new Color(1, 0.5f, 1);
        states[3] = new Color(0.5f, 0.5f, 1);
        states[4] = new Color(0.5f, 1, 1);
        states[5] = new Color(0.5f, 1, 0.5f);
    }

    void Update()
    {
        lerpTime += Time.deltaTime / transitionSpeed;
        GetComponent<SpriteRenderer>().color = Color.Lerp(states[statesIdx], states[states2Idx], lerpTime);
        if (lerpTime >= 1f)
        {
            lerpTime = 0f;
            statesIdx = (statesIdx + 1) % states.Length;
            states2Idx = (states2Idx + 1) % states.Length;
        }
    }
}
