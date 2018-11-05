using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePodHiDoor : MonoBehaviour
{
    public Animator animator;
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
        CloseDoor();
    }

    /*private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse down");
            ToggleDoor();
        }
    }*/

    public void ToggleDoor()
    {
        if (!isOpen) OpenDoor();
        else CloseDoor();
    }

    public void OpenDoor()
    {
        Debug.Log("open");
        animator.SetTrigger("OpenPod");
        animator.ResetTrigger("ClosePod");
		animator.SetBool ("PodIsOpened", true);
		animator.SetBool ("PodIsClosed", false);
        isOpen = true;
    }

    public void CloseDoor()
    {
        Debug.Log("close");
        animator.SetTrigger("ClosePod");
        animator.ResetTrigger("OpenPod");
		animator.SetBool ("PodIsOpened", false);
		animator.SetBool ("PodIsClosed", true);
        isOpen = false;
    }
	
}
