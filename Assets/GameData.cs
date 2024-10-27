using UnityEngine;

public static class GameData
{
    public static Color mixtureColor;
    public static float shipCondition = 0.64f;
    public static int money;

    public static int day;
    public static int WoodCount;
    public static readonly int WoodDurability = 5;
    public static readonly int WoodSpeed = 20;
    public static int IronCount;
    public static readonly int IronDurability = 10;
    public static readonly int IronSpeed = 5;
    public static int CrystalCount;
    public static readonly int CrystalDurability = 20;
    public static readonly int CrystalSpeed = 10;

    public static bool IsWoodInCauldron;
    public static bool IsCrystalInCauldron;
    public static bool IsIronInCauldron;
}