using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardReader : MonoBehaviour {

    public Transform[] slots;
    public GameObject[] cards;
    public GameObject[] lights;

    public Material redLight;
    public Material greenLight;

    public UnityEvent cardsOK;

    private bool[] cardsInSlots;

    private void Start()
    {
        foreach(GameObject go in lights)
        {
            go.GetComponent<Renderer>().material = redLight;
        }

        cardsInSlots = new bool[slots.Length];
        for(var i = 0; i< cardsInSlots.Length; i++)
        {
            cardsInSlots[i] = false;
        }
    }

    public void OnClick()
    {
        InventorySystem inventory = GameObject.FindGameObjectWithTag("InventorySystem").GetComponent<InventorySystem>();

        InventoryItem item = inventory.GetItem();
        if(item != null)
        {
            bool isCard = false;
            int cardSlot = -1;

            for (var i = 0; !isCard && i < cards.Length; i++)
            {
                if (item.gameObject == cards[i])
                {
                    cardSlot = i;
                    isCard = true;
                }
            }

            if (isCard)
            {
                inventory.RemoveItem(item);
                item.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                item.gameObject.GetComponent<Collider>().enabled = false;
                item.gameObject.transform.parent = slots[cardSlot];
                item.gameObject.transform.position = slots[cardSlot].position;
                item.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90f);
                item.enabled = false;

                lights[cardSlot].GetComponent<Renderer>().material = greenLight;
                cardsInSlots[cardSlot] = true;
            }
        }

        CheckCards();
    }

    private void CheckCards()
    {
        bool ok = true;
        foreach(bool b in cardsInSlots)
        {
            if(!b)
            {
                ok = false;
                break;
            }
        }

        if(ok)
        {
            cardsOK.Invoke();
        }
    }
}
