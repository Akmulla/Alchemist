using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle : MonoBehaviour
{
    public BottleData bottle_data;
    public Image image;
    public SpriteRenderer sprite_rend;


    public void InitBottle(BottleData data)
    {
        bottle_data = data;
        if (image!=null)
        {
            image.sprite = data.bottle_sprite;
        }
        //else
        //{
        //    sprite_rend.sprite = data.bottle_sprite;
        //}
    }
}
