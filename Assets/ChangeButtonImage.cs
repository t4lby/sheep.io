using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeButtonImage : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public Sprite PressedImage;
	public Sprite DepressedImage;
    private Button _btn;

    private void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(() => Globals.ProcessTurn());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _btn.image.sprite = PressedImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _btn.image.sprite = DepressedImage;
    }

    
}
