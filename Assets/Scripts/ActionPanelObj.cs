﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPanelObj : MonoBehaviour
{
    public BottleData bottle_data;
    public KeyCode code;
    public SpriteRenderer sprite_rend;
	
	void Update ()
    {
		
	}

    public void InitPanelObj(BottleData data)
    {
        bottle_data = data;
        if (sprite_rend != null)
        {
            sprite_rend.sprite = data.bottle_sprite;
        }
    }
}
