using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookPoint : MonoBehaviour {

    public Button lookButton;
    public Button backButton;
    public Transform lookPoint;
    public Transform backPoint;

    public Transform player;

    private void Start()
    {
        lookButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
    }

	public void ClickOnLook()
    {
        Vector3 pos = player.position;
        pos.x = lookPoint.position.x;
        pos.z = lookPoint.position.z;

        player.position = pos;
        player.rotation = lookPoint.rotation;

        lookButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

    public void ClickOnBack()
    {
        Vector3 pos = player.position;
        pos.x = backPoint.position.x;
        pos.z = backPoint.position.z;

        player.position = pos;
        player.rotation = backPoint.rotation;

        lookButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
    }

    public void Hide()
    {
        lookButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
}
