using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject room;
    public GameObject instructions;
    public GameObject youFoundItCanvas;
    public GameObject warpPoints;

    public AudioSource redLightSound;

	public MonitorScript monitorScript;
	public KeyboardScript keyboardScript;
    public RainbowRiddle rainbowRiddle;

	public Animator mainDoorAnimator;
    public AudioSource mainDoorAudioSource;
	public GameObject alertLogo;

    public Animator roomDoorAnimator;
    public AudioSource roomDoorAudioSource;
    public GameObject[] roomWarpPoints;

    public Material screen1;
    public Texture conway;
    public Material screen2;
    public Texture robinson;
    public Material screen3;
    public Texture vigenere;
    public Material screen4;
    public Texture exitCode;

    public GameObject exitCodeKeyHint;

    public Texture noData;

    public AudioClip success;

	// Use this for initialization
	void Start ()
	{
        room.SetActive(false);
        instructions.SetActive(true);
        youFoundItCanvas.SetActive(false);
    }

    public void StartGame()
    {
        instructions.SetActive(false);
        room.SetActive(true);
        alertLogo.SetActive(true);
        screen1.mainTexture = noData;
        screen2.mainTexture = noData;
        screen3.mainTexture = noData;
        screen4.mainTexture = noData;

        foreach (GameObject wp in roomWarpPoints)
        {
            wp.SetActive(false);
        }

        exitCodeKeyHint.SetActive(false);
    }

    public void EndGame()
    {
        redLightSound.Stop();
        youFoundItCanvas.SetActive(true);
        StartCoroutine(WaitBeforeEndGame());
    }

    private IEnumerator WaitBeforeEndGame()
    {
        warpPoints.SetActive(false);
        yield return new WaitForSeconds(5);
        Application.Quit();
    }

	public void MonitorPasswordFound()
	{
		monitorScript.setRainbowRiddle ();
	}

    public void RoomDoorCodeFound()
    {
        roomDoorAnimator.SetTrigger("OpenCardDoor");
        roomDoorAudioSource.Play();
        foreach (GameObject wp in roomWarpPoints)
        {
            wp.SetActive(true);
        }

        screen3.mainTexture = vigenere;
        screen4.mainTexture = exitCode;

        monitorScript.setVigenereRiddle();
    }

	public void MainDoorCodeFound()
	{
        mainDoorAnimator.SetTrigger("OpenRoomDoor");
        mainDoorAudioSource.Play();
		alertLogo.SetActive (false);
        EndGame();
	}

	public void MonitorPlayCorrectSound()
	{
		monitorScript.playCorrectSound ();
	}

	public void MonitorPlayErrorSound()
	{
		monitorScript.playErrorSound ();
	}

    public void StartRainbowRiddle()
    {
        rainbowRiddle.ShowOrbs(true);
    }

    public void RainbowRiddleOK()
    {
        AudioSource a = GetComponent<AudioSource>();
        a.clip = success;
        a.Play();

        screen1.mainTexture = conway;
        screen2.mainTexture = robinson;
    }

    public void CardsOK()
    {
        exitCodeKeyHint.SetActive(true);
    }
}
