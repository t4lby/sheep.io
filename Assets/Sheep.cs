using UnityEngine;
using System.Collections.Generic;

public class Sheep : MonoBehaviour
{
    public GameObject HealthObject;
    public Sprite[] HealthSprites;

    public float Health;

    public Vector2Int Pos;

    public bool JustMoved;
    public bool Dead;

    public GameObject MoveIndicatorPrefab;

    List<Indicator> indicators = new List<Indicator>();

    bool moving;
    bool initMove;
    Vector3 heartInitPos;

    private void Awake()
    {
        heartInitPos = HealthObject.transform.localPosition;
    }

    private void Update()
    {
        if (Health > 0)
        {
            HealthObject.transform.localPosition = heartInitPos +
                new Vector3(0, Mathf.Sin(Time.time * Globals.SheepHealthMax * 2 / Health) / 16);
        }
        else
        {
            HealthObject.transform.localPosition = heartInitPos;
        }
    }

    public void ProcessTurn()
    {
        UpdatePosition();

        if (Globals.Grid[Pos.x, Pos.y].Food >= 2 && !JustMoved)
        {
            Globals.Grid[Pos.x, Pos.y].Food -= Globals.TileFoodLossWithSheep;
            Health += Globals.SheepHealthGainOnGrass;
        }
        else
        {
            Health -= Globals.SheepHealthLossPerTurn;
        }

        if (JustMoved)
        {
            JustMoved = false;
        }

        if (Health > Globals.SheepHealthMax)
        {
            Health = Globals.SheepHealthMax;
        }

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }

        HealthObject.GetComponent<SpriteRenderer>().sprite =
            HealthSprites[Mathf.CeilToInt(Health)];
    }

    public void Die()
    {
        Dead = true;
        //flip sheep over.
        GetComponent<SpriteRenderer>().flipY = true;
    }

    public void UpdatePosition()
    {
        transform.position = new Vector3(Pos.x + 0.5f, Pos.y + 0.5f, 0);
    }

    private void OnMouseDown()
    {
        if (Dead)
        {
            return; //skip movement if sheep is dead.
        }
        //spawn movement indicators.
        initMove = true;
        var up = Instantiate(MoveIndicatorPrefab).GetComponent<Indicator>();
        var down = Instantiate(MoveIndicatorPrefab).GetComponent<Indicator>();
        var left = Instantiate(MoveIndicatorPrefab).GetComponent<Indicator>();
        var right = Instantiate(MoveIndicatorPrefab).GetComponent<Indicator>();
        var on = Instantiate(MoveIndicatorPrefab).GetComponent<Indicator>();
        up.Sheep = this; down.Sheep = this; left.Sheep = this; right.Sheep = this; on.Sheep = this;
        up.Type = IndicatorType.Possible; down.Type = IndicatorType.Possible;
        left.Type = IndicatorType.Possible; right.Type = IndicatorType.Possible;
        on.Type = IndicatorType.Selected;
        up.Pos = Pos + new Vector2Int(0, 1);
        down.Pos = Pos + new Vector2Int(0, -1);
        left.Pos = Pos + new Vector2Int(-1, 0);
        right.Pos = Pos + new Vector2Int(1, 0);
        on.Pos = Pos;
        indicators.AddRange(
            new[] { up, down, left, right, on }
        );
    }

    private void LateUpdate()
    {
        if (moving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                indicators.ForEach(g => Destroy(g.gameObject));
                indicators.Clear();
                moving = false;
            }
        }
        if (initMove)
        {
            moving = true;
            initMove = false;
        }
    }
}
