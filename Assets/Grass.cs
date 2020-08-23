using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grass : MonoBehaviour {

    public Sprite[] GrassSprites;

    public float Food;

    public bool SheepOnTile;

    private void Start()
    {
        UpdateImage();
    }

    public void ProcessTurn()
    {
        if (!SheepOnTile)
        {
            Food += Globals.TileFoodGainPerTurn;
        }

        if (Food < 1) Food = 1;
        if (Food > Globals.TileFoodMax) Food = Globals.TileFoodMax;

        UpdateImage();
    }

    private void UpdateImage()
    {
        int index = Mathf.FloorToInt(Food) - 1;
        try
        {
            GetComponent<SpriteRenderer>().sprite = GrassSprites[index];
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("grass sprite index out of range! can't update");
        }
    }
}
