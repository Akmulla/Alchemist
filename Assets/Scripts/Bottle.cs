using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle : MonoBehaviour
{
    public BottleData bottle_data;
    public Image image;

    public void InitBottle(BottleData data)
    {
        bottle_data = data;
        image.sprite = data.bottle_sprite;
    }
}
