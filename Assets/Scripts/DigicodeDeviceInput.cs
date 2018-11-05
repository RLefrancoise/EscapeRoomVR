using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DigicodeDeviceInput : MonoBehaviour
{
	public GameController gameController;

	public Text LCDText;
	public string correctInput;

	//public AudioClip openDoorSound;
	public AudioClip errorSound;

    public UnityEvent codeFoundEvent;

	private int nextNumber;
	private char[] code;
	private bool found = false;

	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		code = new char[correctInput.Length];
		ResetCode();

		audioSource = GetComponent<AudioSource> ();
	}

	private void ResetCode()
	{
		LCDText.text = "";
		LCDText.color = Color.green;

		for(int i = 0; i < correctInput.Length; i++)
		{
			LCDText.text += '-';
		}

		nextNumber = 0;
		for(int i = 0; i < code.Length; i++)
		{
			code[i] = '-';
		}
	}

	public void pressEnter()
	{
		if (found)
			return;
		
		if (nextNumber != correctInput.Length) return;

		if (LCDText.text == correctInput) {
			LCDText.text = "Open";
			found = true;
			/*audioSource.clip = openDoorSound;
			audioSource.Play ();*/
            codeFoundEvent.Invoke();
		} else {
			LCDText.text = "Error";
			LCDText.color = Color.red;
			audioSource.clip = errorSound;
			audioSource.Play ();
			StartCoroutine (ReturnToResetCode ());
		}
	}

	private IEnumerator ReturnToResetCode()
	{
		yield return new WaitForSeconds (1);
		ResetCode ();
		yield break;
	}

	public void pressCancel()
	{
		if (found)
			return;
		
		ResetCode();
	}

	public void pressNumberKey(char key)
	{
		if (found)
			return;
		
		if (nextNumber >= correctInput.Length) return;
		LCDText.color = Color.green;

		code[nextNumber] = key;
		nextNumber++;

		LCDText.text = "";

		for (int i = 0; i < nextNumber; i++)
		{
			LCDText.text += code[i];
		}

		for (int i = nextNumber; i < code.Length; i++)
		{
			LCDText.text += '-';
		}
	}
}
