using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AlloyBottomDots : MonoBehaviour
{
    #region Singleton

    public static AlloyBottomDots Instance;
        
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public bool isPressable;
    
    [SerializeField] private GameObject[] dotObjects;

    public void IncreaseDot(Color color, int valueToChange)
    {
        foreach (var dotObject in dotObjects)
        {
            var tempImage = dotObject.GetComponent<Image>();
            if (tempImage.color.a == 0)
            {
                tempImage.color = color;
                PrepareButton.Instance.totalDurabilityToChange += valueToChange;
                isPressable = true;
                return;
            }
            isPressable = false;
        }
    }
    
    public void DecreaseDot(Color color, int valueToChange)
    {
        bool removedDot=false;
        for(int i =0;i<dotObjects.Length;i++){
            var tempImage = dotObjects[i].GetComponent<Image>();
            if(removedDot&&i<dotObjects.Length-1){
                tempImage.GetComponent<Image>().color=dotObjects[i+1].GetComponent<Image>().color;
            }
            if (Mathf.Approximately(tempImage.color.a, 1) && tempImage.color == color&&!removedDot)
            {
                var imageColor = tempImage.color;
                imageColor.a = 0;
                tempImage.color = imageColor;
                
                PrepareButton.Instance.totalDurabilityToChange -= valueToChange;
                removedDot=true;
                if(i==dotObjects.Length-1) dotObjects[dotObjects.Length-1].GetComponent<Image>().color=Color.clear;
                else tempImage.GetComponent<Image>().color=dotObjects[i+1].GetComponent<Image>().color;
            }
            
        }
        if(removedDot) dotObjects[dotObjects.Length-1].GetComponent<Image>().color=Color.clear;
    }
}
