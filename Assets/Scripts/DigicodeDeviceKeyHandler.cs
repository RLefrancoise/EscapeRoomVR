using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigicodeDeviceKeyHandler : MonoBehaviour
{
	public DigicodeDeviceInput deviceInput;

	public AudioClip keyBeep;
	public AudioSource audioSource;

	/*void OnMouseDown()
	{
		if (Input.GetMouseButtonDown (0)) {
			string key = gameObject.name.Substring (3);

			if (!key.Equals ("Validate") && !key.Equals ("Cancel")) {
				deviceInput.pressNumberKey (key.ToCharArray () [0]);
				PlayBeepSound ();
			} else if (key.Equals ("Validate")) {
				deviceInput.pressEnter ();
			} else if (key.Equals ("Cancel")) {
				deviceInput.pressCancel ();
				PlayBeepSound ();
			}
		}
	}*/

    public void Click()
    {
        string key = gameObject.name.Substring(3);

        if (!key.Equals("Validate") && !key.Equals("Cancel"))
        {
            deviceInput.pressNumberKey(key.ToCharArray()[0]);
            PlayBeepSound();
        }
        else if (key.Equals("Validate"))
        {
            deviceInput.pressEnter();
        }
        else if (key.Equals("Cancel"))
        {
            deviceInput.pressCancel();
            PlayBeepSound();
        }
    }

	private void PlayBeepSound()
	{
		audioSource.clip = keyBeep;
		audioSource.Play ();
	}
}
