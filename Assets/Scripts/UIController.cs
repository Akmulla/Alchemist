using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController ui;
    public GameObject[] heart;
    public GameObject inventory;

	void Awake ()
    {
        ui = this;
	}

    void Start()
    {
       // UpdateHearts();
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
                break;
        }
    }
    
}
