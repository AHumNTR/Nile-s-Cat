using System;
using UnityEngine;

public class Alloy : MonoBehaviour
{
    public string alloyName;
    
    [SerializeField] private Color color;
    
    private int _durabilityValue;
    private int _alloySpeed;
    private int _alloyWeight;
    
    private void Start()
    {
        AssignAlloyValues(); 
    }

    private void AssignAlloyValues()
    {
        _durabilityValue = alloyName switch
        {
            "Wood" => GameData.WoodDurability,
            "Iron" => GameData.IronDurability,
            "Crystal" => GameData.CrystalDurability,
            _ => _durabilityValue
        };

        _alloySpeed = alloyName switch
        {
            "Wood" => GameData.WoodSpeed,
            "Iron" => GameData.IronSpeed,
            "Crystal" => GameData.CrystalSpeed,
            _ => _alloySpeed
        };
        
        _alloyWeight = alloyName switch
        {
            "Wood" => GameData.WoodWeight,
            "Iron" => GameData.IronWeight,
            "Crystal" => GameData.CrystalWeight,
            _ => _alloyWeight
        };
    }
    public void OnAddButtonPressed()
    {
        AudioManager.Instance.PlayButtonSound(0);
        AlloyBottomDots.Instance.IncreaseDot(color, _durabilityValue, _alloySpeed, _alloyWeight);
        if (AlloyBottomDots.Instance.isPressable)
        {
            AssignAlloysToGameData();
        }
    }
    
    public void OnRemoveButtonPressed()
    {
        AudioManager.Instance.PlayButtonSound(0);
        AlloyBottomDots.Instance.DecreaseDot(color, _durabilityValue, _alloySpeed, _alloyWeight);
        UnassignAlloyFromGameData();
    }

    private void AssignAlloysToGameData()
    {
        if (alloyName == "Wood")
        {
            GameData.IsWoodInCauldron = true;
            GameData.WoodCount++;
        }

        if (alloyName == "Iron")
        {
            GameData.IsIronInCauldron = true;
            GameData.IronCount++;
        }
        
        if (alloyName == "Crystal")
        {
            GameData.IsCrystalInCauldron = true;
            GameData.CrystalCount++;
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
