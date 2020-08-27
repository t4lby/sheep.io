using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    public Sprite[] BackgroundSprites;
    public SpriteRenderer current;
    public SpriteRenderer incoming;
    int callCount = 0;
    float progress = -1;
    float fadeincrement = 0.01f;

    public void ProcessTurn()
    {
        incoming.sprite =
            BackgroundSprites[callCount % BackgroundSprites.Length];
        callCount++;
        progress = 0;
    }

    private void Start()
    {
        incoming.color = new Color(1, 1, 1, 0);
        current.color = new Color(1, 1, 1, 1);
        current.sprite = BackgroundSprites[callCount % BackgroundSprites.Length];
    }

    private void Update()
    {
        if (progress >= 1)
        {
            current.color = new Color(1, 1, 1, 1);
            current.sprite = incoming.sprite;
            incoming.color = new Color(1, 1, 1, 0);
        }
        else if (progress >= 0)
        {
            current.color = new Color(1, 1, 1, 1.5f - progress);
            incoming.color = new Color(1, 1, 1, progress);
            progress += fadeincrement;
        }
    }
}
