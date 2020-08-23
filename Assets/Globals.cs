using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityScript.Steps;

public static class Globals
{
    public const float SheepHealthLossPerTurn = 0.5f;
    public const float SheepHealthGainOnGrass = 1f;
    public const float TileFoodLossWithSheep = 2f;
    public const float TileFoodGainPerTurn = 0.25f;
    public static  Vector2Int[] SheepStartLocations =
    {
        new Vector2Int(1, 1),
        new Vector2Int(0, 2),
        new Vector2Int(2, 1),
        new Vector2Int(3, 3),
        new Vector2Int(3, 0),
        new Vector2Int(2, 5)
    };

    public const float TileFoodMax = 4;
    public const float SheepHealthMax = 5;
    public const int GridWidth = 4;
    public const int GridHeight = 6;



    public static Grass[,] Grid = new Grass[GridWidth, GridHeight];
    public static List<Sheep> Sheep = new List<Sheep>();

    public static void ProcessTurn()
    {
        foreach (var sh in Sheep.Where(sh => sh.Dead).ToArray())
        {
            Sheep.Remove(sh);
            GameObject.Destroy(sh.gameObject);
        }

        foreach (var sh in Sheep)
        {
            sh.ProcessTurn();
        }

        for (int i = 0; i < GridWidth; i++)
        {
            for (int j = 0; j < GridHeight; j++)
            {
                Grid[i, j].SheepOnTile =
                    Sheep.Where(sh => sh.Pos == new Vector2Int(i, j)).Count() > 0;
                Grid[i, j].ProcessTurn();
            }
        }
    }
}
