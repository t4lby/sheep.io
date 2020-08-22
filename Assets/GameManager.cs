using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject GrassPrefab;
    public GameObject SheepPrefab;

    public void Start()
    {
        //Instantiate grass.
        for (int i = 0; i < Globals.GridWidth; i++)
        {
            for (int j = 0; j < Globals.GridHeight; j++)
            {
                var go = Instantiate(GrassPrefab, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity);
                Globals.Grid[i, j] = go.GetComponent<Grass>();
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

    void Update()
    {
        
    }
}
