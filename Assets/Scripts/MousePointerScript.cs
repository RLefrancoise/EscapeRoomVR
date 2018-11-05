using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointerScript : MonoBehaviour
{
	public Texture2D mouseEnterCursor;

	private void Start()
	{
	}

	private void OnMouseEnter()
	{
		Cursor.SetCursor (mouseEnterCursor, Vector2.zero, CursorMode.Auto);
	}

	private void OnMouseExit()
	{
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}
}
