using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController ui;
    public GameObject[] heart;
    public GameObject inventory;
    public GameObject bottle_prefab;
    public GameObject[] bottle_cell;
    public GameObject[] mix_cell;
    public GameObject mix_field;


    void Awake ()
    {
        ui = this;
	}

    void Start()
    {
       // UpdateHearts();
    }
	
    void ClearCells()
    {
        for(int i=0;i<bottle_cell.Length;i++)
        {
            bottle_cell[i].GetComponent<DragAndDropCell>().RemoveItem();
        }

        for (int i = 0; i < mix_cell.Length; i++)
        {
            mix_cell[i].GetComponent<DragAndDropCell>().RemoveItem();
        }
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
    
    public void Mix()
    {

        Bottle[] bottles_mixing = mix_field.GetComponentsInChildren<Bottle>();
        if (bottles_mixing.Length < 2)
            return;

        List<BottleData> bottle_data=new List<BottleData>();
        for (int i=0;i<bottles_mixing.Length;i++)
        {
            bottle_data.Add(bottles_mixing[i].bottle_data);
        }

        int active_abil = 0;
        List<Ability> new_abil = new List<Ability>();
        for (int i=0;i<bottle_data.Count;i++)
        {
            for(int j=0;j<bottle_data[i].abil.Length;j++)
            {
                if ((active_abil<2)&&(bottle_data[i].abil[j].ability_type==AbilityType.Active))
                {
                    new_abil.Add(bottle_data[i].abil[j]);
                }
            }

            for (int j = 0; j < bottle_data[i].abil.Length; j++)
            {
                if (bottle_data[i].abil[j].ability_type == AbilityType.Passive)
                {
                    new_abil.Add(bottle_data[i].abil[j]);
                }
            }

        }


        BottleData new_data = ScriptableObject.CreateInstance<BottleData>();
        new_data.abil = new Ability[new_abil.Count];
        for (int i=0;i<new_abil.Count;i++)
        {
            new_data.abil[i] = new_abil[i];
        }
        BottleHandler.b.AddBottle(new_data);
        for (int i = 0; i < bottle_data.Count; i++)
        {
            BottleHandler.b.RemoveBottle(bottle_data[i]);
        }
        SetBottles();
    }

    public void DrinkBottle(BottleData bottle)
    {
        if (Player.player.CheckIfDefault())
        {
            Player.player.DrinkBottle(bottle);
            BottleHandler.b.RemoveBottle(bottle);
            SetBottles();
        }
        
    }

    void SetBottles()
    {
        ClearCells();
        List<BottleData> bottles = BottleHandler.b.GetBottles();
        for (int i=0;i<bottles.Count;i++)
        {
            GameObject new_bottle = Instantiate(bottle_prefab);
            new_bottle.GetComponent<Bottle>().InitBottle(bottles[i]);
            bottle_cell[i].GetComponent<DragAndDropCell>().PlaceItem(new_bottle);
        }
    }
}
