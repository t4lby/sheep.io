using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {
    public Sprite[] IndicatorImages;
    public IndicatorType Type;
    public Vector2Int Pos;
    public Sheep Sheep;

    private void Start()
    {
        transform.position = new Vector3(Pos.x + 0.5f, Pos.y + 0.5f, 0);
        if (Pos.x < 0 || Pos.y < 0 ||
            Pos.x >= Globals.GridWidth || Pos.y >= Globals.GridHeight ||
            Globals.Grid[Pos.x, Pos.y].SheepOnTile && Pos != Sheep.Pos)
        {
            Type = IndicatorType.Impossible;
        }
        GetComponent<SpriteRenderer>().sprite = IndicatorImages[(int)Type];
    }

    private void OnMouseDown()
    {
        if (Type == IndicatorType.Possible)
        {
            if (this.Pos.x != Sheep.Pos.x)
            {
                Sheep.GetComponent<SpriteRenderer>().flipX = this.Pos.x < Sheep.Pos.x;
            }
            Sheep.Pos = this.Pos;
            Sheep.JustMoved = true;
            Globals.ProcessTurn();
        }
    }
}

public enum IndicatorType
{
    Selected,
    Possible,
    Impossible
}
