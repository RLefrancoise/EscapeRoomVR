using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

    [SerializeField]
    public string itemId;
    [SerializeField]
    public string itemName;
    [SerializeField]
    public string itemDescription;

    public void ClickOnOItem()
    {
        Transform player = GameObject.FindGameObjectWithTag("MainCamera").transform;

        RaycastHit hitInfo;
        if (Physics.Raycast(new Ray(player.position, player.forward), out hitInfo))
        {
            GameObject item = hitInfo.collider.gameObject;

			Debug.Log ("Click on item : " + item.name);

            InventorySystem inventory = GameObject.FindGameObjectWithTag("InventorySystem").GetComponent<InventorySystem>();
            inventory.AddItem(item);
        }
        else
        {
            Debug.Log("No hit");
        }
    }
}
