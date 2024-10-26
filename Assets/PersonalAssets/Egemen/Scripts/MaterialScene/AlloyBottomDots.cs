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

    public void IncreaseDot(Color color, int valueToChange)
    {
        foreach (var dotObject in dotObjects)
        {
            var tempImage = dotObject.GetComponent<Image>();
            if (tempImage.color.a == 0)
            {
                tempImage.color = color;
                PrepareButton.Instance.totalDurabilityToChange += valueToChange;
                return;
            }
        }
    }
    public void DecreaseDot(int valueToChange)
    {
        foreach (var dotObject in dotObjects.Reverse())
        {
            var tempImage = dotObject.GetComponent<Image>();
            if (Mathf.Approximately(tempImage.color.a, 1))
            {
                var imageColor = tempImage.color;
                imageColor.a = 0;
                tempImage.color = imageColor;
                PrepareButton.Instance.totalDurabilityToChange -= valueToChange;
                return;
            }
        }
    }
}
