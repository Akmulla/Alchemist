using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle : MonoBehaviour
{
    public BottleData bottle;

    public void InitBottle(BottleData data)
    {
        bottle = data;
        GetComponent<Image>().sprite = data.sprite;
    }
}
