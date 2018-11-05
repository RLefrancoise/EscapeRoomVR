using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject playerCamera;
    public Light spotLight;
    public Canvas playerCanvas;

    private void Update()
    {
        Quaternion rot = playerCamera.transform.rotation;

        /*if((playerCamera.transform.eulerAngles.y % 360) >= 70)
        {*/
            playerCanvas.transform.rotation = Quaternion.Euler(90, rot.eulerAngles.y, 0);
            playerCanvas.gameObject.SetActive(true);
        /*} else
        {
            playerCanvas.gameObject.SetActive(false);
        }*/
    }

    public void ToggleLight()
    {
        if (spotLight.intensity > 0) spotLight.intensity = 0;
        else spotLight.intensity = 1.5f;
    }
}
