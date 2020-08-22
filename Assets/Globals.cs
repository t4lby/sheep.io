using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public static class Globals
{
    public const float SheepHealthLossPerTurn = 0.5f;
    public const float SheepHealthGainOnGrass = 1f;
    public const float TileFoodLossWithSheep = 2f;
    public const float TileFoodGainPerTurn = 1f;
    public static  Vector2Int[] SheepStartLocations =
    {
        new Vector2Int(1, 1),
        new Vector2Int(0, 2)
    };

    public const int TileFoodMax = 4;
    public const int GridWidth = 3;
    public const int GridHeight = 3;



    public static Grass[,] Grid = new Grass[GridWidth, GridHeight];
    public static List<Sheep> Sheep = new List<Sheep>();

    public static void ProcessTurn()
    {
        for (int i = 0; i < GridWidth; i++)
        {
            for (int j = 0; j < GridHeight; j++)
            {
                Grid[i, j].ProcessTurn();
            }
        }

        foreach (var sh in Sheep)
        {
            sh.ProcessTurn();
        }
    }
}
