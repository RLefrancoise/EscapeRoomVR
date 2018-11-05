using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {

    public GameObject itemsCanvas;

    private ArrayList items;

    private int selectedItemIndex;

	// Use this for initialization
	void Start () {
        items = new ArrayList();
        itemsCanvas.gameObject.SetActive(false);
        selectedItemIndex = -1;
	}
	
    public void ToggleInventoryCanvas()
    {
        if (itemsCanvas.activeInHierarchy) itemsCanvas.SetActive(false);
        else itemsCanvas.SetActive(true);
    }

    public void AddItem(GameObject i)
    {
        InventoryItem ii = i.GetComponent<InventoryItem>();
        if (ii != null)
        {
            AddItem(ii);
			if (selectedItemIndex == -1) SelectItem(0);
        }
    }

    public void AddItem(InventoryItem i)
    {
        if (!items.Contains(i))
        {
            items.Add(i);
            i.gameObject.SetActive(false);
            Print();
        }
    }

    public void RemoveItem(InventoryItem i)
    {
        if (items.Contains(i))
        {
            items.Remove(i);
            i.gameObject.SetActive(true);
            SelectItem(items.Count > 0 ? items.Count - 1 : -1);
            
            Print();
        }
    }

    private void SelectItem(int index)
    {
		selectedItemIndex = index;

		if (selectedItemIndex >= items.Count)
			selectedItemIndex = items.Count - 1;

		if (selectedItemIndex == -1)
        {
            itemsCanvas.transform.Find("ItemName").gameObject.GetComponent<Text>().text = "No Item";
            itemsCanvas.transform.Find("ItemDescription").gameObject.GetComponent<Text>().text = "";
        }
		else
        {
            itemsCanvas.transform.Find("ItemName").gameObject.GetComponent<Text>().text = GetItem().itemName;
            itemsCanvas.transform.Find("ItemDescription").gameObject.GetComponent<Text>().text = GetItem().itemDescription;
        }
    }

    public void SelectPreviousItem()
    {
        selectedItemIndex--;
        if (selectedItemIndex < 0) selectedItemIndex = 0;
        SelectItem(selectedItemIndex);
    }

    public void SelectNextItem()
    {
        selectedItemIndex++;
        if (selectedItemIndex >= items.Count) selectedItemIndex = items.Count - 1;
        SelectItem(selectedItemIndex);
    }

    public InventoryItem GetItem()
    {
        if (selectedItemIndex < 0) return null;
        return items[selectedItemIndex] as InventoryItem;
    }

    private void Print()
    {
        string str = "";
        foreach(InventoryItem i in items)
        {
            str += i.itemId + " ";
        }

        Debug.Log(str);
    }
}
