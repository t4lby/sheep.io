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
        GetComponent<SpriteRenderer>().sprite = IndicatorImages[(int)Type];
    }

    private void OnMouseDown()
    {
        if (Type == IndicatorType.Possible)
        {
            Sheep.Pos = this.Pos;
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
