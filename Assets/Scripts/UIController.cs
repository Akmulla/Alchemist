using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController ui;
    public GameObject[] heart;
    public GameObject inventory;
    public GameObject[] bottle_cell;
    public GameObject bottle_prefab;
    public GameObject mix_holder;


	void Awake ()
    {
        ui = this;
	}
	
    public void UpdateHearts(int hp)
    {
        int active_icons = Mathf.Clamp(hp, 0, heart.Length);
        for (int i=0;i<heart.Length;i++)
        {
            if (i<active_icons)
            {
                heart[i].SetActive(true);
            }
            else
            {
                heart[i].SetActive(false);
            }
        }
    }

    public void UpdateUI()
    {
        switch (GameController.gc.State)
        {
            case GameState.Game:
                inventory.SetActive(false);
                break;

            case GameState.Inventory:
                inventory.SetActive(true);
                SetBottles();
                break;
        }
    }
    
    public void UpdateDescription()
    {

    }

    public void Mix()
    {
        Bottle[] active_bottles = mix_holder.GetComponentsInChildren<Bottle>();
        if (active_bottles.Length!=0)
        {

        }
    }

    void SetBottles()
    {
        List<CharData> bottle_list = BottleHandler.b.GetBottles();
        for (int i=0;i< bottle_list.Count;i++)
        {
            GameObject new_bottle = Instantiate(bottle_prefab);
            bottle_cell[i].GetComponent<DragAndDropCell>().PlaceItem(new_bottle);
            //new_bottle.GetComponent<Image>().sprite = bottle_list[i].bottle_sprite;
            //new_bottle.GetComponent<Bottle>().bottle = bottle_list[i].bottle_data;
            new_bottle.GetComponent<Bottle>().InitBottle(bottle_list[i].bottle_data);
        }
    }
}
