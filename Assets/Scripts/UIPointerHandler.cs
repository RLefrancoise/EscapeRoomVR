using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPointerHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Color enterColor;
	public Color exitColor;
	public Texture2D cursor;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("pointer enter");
		Cursor.SetCursor (cursor, Vector2.zero, CursorMode.Auto);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("pointer exit");
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}
}
