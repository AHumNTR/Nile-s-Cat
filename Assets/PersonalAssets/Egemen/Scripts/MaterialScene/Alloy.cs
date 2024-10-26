using UnityEngine;

public class Alloy : MonoBehaviour
{
    public string alloyName;
    public int durabilityValue;
    [SerializeField] private Color color;

    public void OnAddButtonPressed()
    {
        AlloyBottomDots.Instance.IncreaseDot(color, durabilityValue);
        if (AlloyBottomDots.Instance.isPressable)
        {
            AssignAlloysToGameData();
        }
    }
    
    public void OnRemoveButtonPressed()
    {
        AlloyBottomDots.Instance.DecreaseDot(color, durabilityValue);
        UnassignAlloyFromGameData();
    }

    private void AssignAlloysToGameData()
    {
        if (alloyName == "Wood")
        {
            GameData.IsWoodInCauldron = true;
            GameData.WoodCount++;
        }

        if (alloyName == "Crystal")
        {
            GameData.IsCrystalInCauldron = true;
            GameData.CrystalCount++;
        }

        if (alloyName == "Iron")
        {
            GameData.IsIronInCauldron = true;
            GameData.IronCount++;
        }
    }

    private void UnassignAlloyFromGameData()
    {
        switch (alloyName)
        {
            case "Wood" when GameData.WoodCount > 1:
                GameData.WoodCount--;
                break;
            case "Wood" when GameData.WoodCount == 1:
                GameData.IsWoodInCauldron = false;
                GameData.WoodCount--;
                break;
            case "Crystal" when GameData.CrystalCount > 1:
                GameData.CrystalCount--;
                break;
            case "Crystal" when GameData.WoodCount == 1:
                GameData.IsCrystalInCauldron = false;
                GameData.CrystalCount--;
                break;
            case "Iron" when GameData.IronCount > 1:
                GameData.IronCount--;
                break;
            case "Iron" when GameData.IronCount == 1:
                GameData.IsIronInCauldron = false;
                GameData.IronCount--;
                break;
        }
    }
}
