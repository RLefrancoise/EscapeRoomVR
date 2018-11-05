using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorScript : MonoBehaviour
{
	public Texture rainbowHintTexture;
    public Texture vigenereTexture;

    public GameController gameController;

	public AudioClip correctSound;
	public AudioClip errorSound;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	public void setRainbowRiddle() {
		GetComponent<MeshRenderer> ().material.mainTexture = rainbowHintTexture;
		this.GetComponentInChildren<Canvas> ().enabled = false;
        gameController.StartRainbowRiddle();
	}

    public void setVigenereRiddle()
    {
        GetComponent<MeshRenderer>().material.mainTexture = vigenereTexture;
        this.GetComponentInChildren<Canvas>().enabled = false;
    }

	public void playCorrectSound() {
		audioSource.clip = correctSound;
		audioSource.Play ();
	}

	public void playErrorSound() {
		audioSource.clip = errorSound;
		audioSource.Play ();
	}
}
