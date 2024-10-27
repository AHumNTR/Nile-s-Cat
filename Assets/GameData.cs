using UnityEngine;

public static class GameData
{
    public static Color mixtureColor;
    public static int Day;
    
    
    public static float Steering = 0.64f; 
    public static float Durability;
    public static float Speed;
    public static float Weight;
    
    
    public static int WoodCount;
    public static readonly int WoodDurability = 5;
    public static readonly int WoodSpeed = 20;
    public static readonly int WoodWeight = 50;
    public static int IronCount;
    public static readonly int IronDurability = 10;
    public static readonly int IronSpeed = 5;
    public static readonly int IronWeight = 200;
    public static int CrystalCount;
    public static readonly int CrystalDurability = 20;
    public static readonly int CrystalSpeed = 10;
    public static readonly int CrystalWeight = 100;

    public static bool IsWoodInCauldron;
    public static bool IsCrystalInCauldron;
    public static bool IsIronInCauldron;
}