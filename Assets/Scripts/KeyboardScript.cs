using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour
{
	public Text passwordField;
	public string code = "1835264";
	public GameController gameController;
	public AudioClip keyBeep;

	private bool passwordFound;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		passwordField.text = "";
		passwordFound = false;

		audioSource = GetComponent<AudioSource> ();
	}

	public void pressEnter()
	{
		audioSource.clip = keyBeep;
		audioSource.Play ();

		if (passwordFound)
			return;
		
		if (passwordField.text == code) {
			Debug.Log ("Password correct");
			gameController.MonitorPasswordFound ();
			passwordFound = true;
			gameController.MonitorPlayCorrectSound ();
		} else {
			Debug.Log ("Wrong password");
			passwordField.text = "";
			gameController.MonitorPlayErrorSound ();
		}
	}

	private void pressNumberKey(char key)
	{
		if (passwordField.text.Length >= 10) return;

		audioSource.clip = keyBeep;
		audioSource.Play ();

		if (passwordFound)
			return;
		
		passwordField.text += key;
	}

	public void pressKey1()
	{
		pressNumberKey('1');
	}

	public void pressKey2()
	{
		pressNumberKey('2');
	}

	public void pressKey3()
	{
		pressNumberKey('3');
	}

	public void pressKey4()
	{
		pressNumberKey('4');
	}

	public void pressKey5()
	{
		pressNumberKey('5');
	}

	public void pressKey6()
	{
		pressNumberKey('6');
	}

	public void pressKey7()
	{
		pressNumberKey('7');
	}

	public void pressKey8()
	{
		pressNumberKey('8');
	}

	public void pressKey9()
	{
		pressNumberKey('9');
	}

	public void pressKey0()
	{
		pressNumberKey('0');
	}
}
