using UnityEngine;

public class Alloy : MonoBehaviour
{
    public int durabilityValue;
    [SerializeField] private Color color;

    public void OnAddButtonPressed()
    {
        AlloyBottomDots.Instance.IncreaseDot(color, durabilityValue);
    }
    
    public void OnRemoveButtonPressed()
    {
        AlloyBottomDots.Instance.DecreaseDot(durabilityValue);
    }
}
