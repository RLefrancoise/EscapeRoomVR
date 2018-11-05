using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowRiddle : MonoBehaviour {

    [SerializeField]
    private Transform player;

    [SerializeField]
    private List<GameObject> slots;

    [SerializeField]
    private List<GameObject> orbs;

    public GameController gameController;

    void Start()
    {
        ShowOrbs(false);
    }

    public void ShowOrbs(bool show)
    {
        foreach(GameObject go in orbs)
        {
            go.SetActive(show);
        }
    }

    public void ClickOnOrb()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(new Ray(player.position, player.forward), out hitInfo))
        {
            GameObject orb = hitInfo.collider.gameObject;
            
            foreach(GameObject slot in slots)
            {
                if(slot.transform.position == orb.transform.position)
                {
                    slot.SetActive(true);
					slot.GetComponent<SphereCollider> ().enabled = true;

					InventorySystem inventory = GameObject.FindGameObjectWithTag("InventorySystem").GetComponent<InventorySystem>();
					inventory.AddItem(orb);
                }
            }
        } else
        {
            Debug.Log("No hit");
        }
    }

    public void ClickOnSlot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(new Ray(player.position, player.forward), out hitInfo))
        {
            GameObject slot = hitInfo.collider.gameObject;

            InventorySystem inventory = GameObject.FindGameObjectWithTag("InventorySystem").GetComponent<InventorySystem>();

            InventoryItem selectedItem = inventory.GetItem();
            if(selectedItem != null)
            {
                bool isOrb = false;
                foreach(GameObject go in orbs)
                {
                    if(selectedItem.gameObject == go)
                    {
                        isOrb = true;
                        break;
                    }
                }

                if(isOrb)
                {
                    inventory.RemoveItem(selectedItem);
                    selectedItem.gameObject.transform.position = slot.transform.position;
                    slot.SetActive(false);
					slot.GetComponent<SphereCollider> ().enabled = false;

                    CheckRiddle();
                }
            }
        }
        else
        {
            Debug.Log("No hit");
        }
    }

    private void CheckRiddle()
    {
        GameObject[] _slots = slots.ToArray();
        GameObject[] _orbs = orbs.ToArray();

        bool riddleOk = true;
        for(var i = 0; riddleOk && i < _slots.Length; i++)
        {
            if(_slots[i].transform.position != _orbs[i].transform.position)
            {
                riddleOk = false;
            }
        }

        if(riddleOk)
        {
            foreach(GameObject orb in orbs)
            {
                orb.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                orb.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
                orb.GetComponent<Collider>().enabled = false;
            }

            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Collider>().enabled = false;
            }

            gameController.RainbowRiddleOK();
        }
    }
}
