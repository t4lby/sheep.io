using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject GrassPrefab;
    public GameObject SheepPrefab;
    public GameObject BackgroundPrefab;

    public void Start()
    {
        Camera.main.transform.position =
            new Vector3(Globals.GridWidth / 2.0f, Globals.GridHeight / 2.0f - 0.5f, -10);
        Camera.main.orthographicSize = Globals.GridWidth / 2.0f + 2.0f;
        Globals.Background = Instantiate(BackgroundPrefab).GetComponent<Background>();
        Globals.Background.transform.position =
            new Vector3(Globals.GridWidth / 2.0f, Globals.GridHeight / 2.0f);

        //Instantiate grass.
        for (int i = 0; i < Globals.GridWidth; i++)
        {
            for (int j = 0; j < Globals.GridHeight; j++)
            {
                var go = Instantiate(GrassPrefab, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity);
                Globals.Grid[i, j] = go.GetComponent<Grass>();
                Globals.Grid[i, j].Food = Random.Range(1, Globals.TileFoodMax);
            }
        }

        //Instantiate sheep.
        foreach (var loc in Globals.SheepStartLocations)
        {
            var go = Instantiate(SheepPrefab);
            var sheep = go.GetComponent<Sheep>();
            sheep.Pos = loc;
            sheep.UpdatePosition();
            Globals.Sheep.Add(sheep);
        }

        
    }
}
