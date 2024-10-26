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
    
    [SerializeField] private GameObject[] dotObjects;

    public void IncreaseDot(Color color, int valueToIncrease)
    {
        foreach (var dotObject in dotObjects)
        {
            var tempImage = dotObject.GetComponent<Image>();
            if (tempImage.color.a == 0)
            {
                //GameData.shipCondition += valueToIncrease;
                
                var imageColor = tempImage.color;
                imageColor.a = 1;
                tempImage.color = imageColor;
                tempImage.color = color;
                return;
            }
        }
    }
    public void DecreaseDot(int valueToDecrease)
    {
        foreach (var dotObject in dotObjects.Reverse())
        {
            var tempImage = dotObject.GetComponent<Image>();
            if (tempImage.color.a == 1)
            {
                //GameData.shipCondition -= valueToIncrease;
                
                var imageColor = tempImage.color;
                imageColor.a = 0;
                tempImage.color = imageColor;
            }
        }
    }
}
