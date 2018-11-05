using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestInput : MonoBehaviour {
    public LookPoint lookPoint;

    public string correctInput;

    public Animator doorAnimator;
    public Text LCDText;

	public AudioClip keyBeep;
	public AudioClip openDoorSound;
	public AudioClip errorSound;

    public Material LCDGreen;
    public Material LCDRed;

    private int nextNumber;
    private char[] code;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        code = new char[4];
        ResetCode();

		audioSource = GetComponent<AudioSource> ();
	}

    private void ResetCode()
    {
        LCDText.text = "----";
		LCDText.color = Color.green;
        LCDText.material = LCDGreen;
        nextNumber = 0;
        for(int i = 0; i < code.Length; i++)
        {
            code[i] = '-';
        }
    }

    public void pressEnter()
    {
        if (nextNumber != 4) return;

		if (LCDText.text == correctInput) {
			LCDText.text = "OPEN";
			doorAnimator.SetTrigger ("OpenTrigger");
			audioSource.clip = openDoorSound;
			audioSource.Play ();
            lookPoint.ClickOnBack();
            lookPoint.Hide();
		} else {
			LCDText.color = Color.red;
			LCDText.text = "ERR";
            LCDText.material = LCDRed;
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
		audioSource.clip = keyBeep;
		audioSource.Play ();
        ResetCode();
    }

    private void pressNumberKey(char key)
    {
		audioSource.clip = keyBeep;
		audioSource.Play ();

        if (nextNumber >= 4) return;

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
