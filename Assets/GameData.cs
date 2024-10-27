using UnityEngine;

public static class GameData
{
    public static Color mixtureColor;
    public static int Day;
    
    
    public static float Steering = 0.64f; 
    public static float Durability = 0.80f;
    public static float Speed;
    public static float Weight = 500;
    
    
    public static int WoodCount;
    public static readonly int WoodDurability = 5;
    public static readonly int WoodSpeed = 20;
    public static readonly int WoodWeight = 50;
    public static int IronCount;
    public static readonly int IronDurability = 10;
    public static readonly int IronSpeed = 5;
    public static readonly int IronWeight = 150;
    public static int CrystalCount;
    public static readonly int CrystalDurability = 20;
    public static readonly int CrystalSpeed = 10;
    public static readonly int CrystalWeight = 100;

    public static bool IsWoodInCauldron;
    public static bool IsCrystalInCauldron;
    public static bool IsIronInCauldron;
    
    public class Ship1
    {
        public static readonly float NeededDurability = 55;
        public static readonly float NeededSpeed = 80;
        public static readonly float NeededWeight = 350;
    }
    public class Ship2
    {
        public static readonly float NeededDurability = 65;
        public static readonly float NeededSpeed = 50;
        public static readonly float NeededWeight = 550;
    }
    public class Ship3
    {
        public static readonly float NeededDurability = 80;
        public static readonly float NeededSpeed = 40;
        public static readonly float NeededWeight = 600;
    }
}