using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
	public float duration = 1.0f;
    public Material mat;

	// Update is called once per frame
	void Update () {
        if(mat != null)
        {
            Color textureColor = mat.color;
            textureColor.a = Mathf.PingPong(Time.time, duration) / duration;
            mat.color = textureColor;
        } else
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                Color textureColor = renderer.material.color;
                textureColor.a = Mathf.PingPong(Time.time, duration) / duration;
                renderer.material.color = textureColor;
            }
            else
            {
                Color textureColor = GetComponent<Text>().material.color;
                textureColor.a = Mathf.PingPong(Time.time, duration) / duration;
                GetComponent<Text>().material.color = textureColor;
            }
        }
	}
}
