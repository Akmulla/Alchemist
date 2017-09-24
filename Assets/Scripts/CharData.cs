using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CharData : ScriptableObject
{
    public int hp_base;
    public float speed_base;
    public float reload_1;
    public float reload_2;
    public BottleData bottle_data;
}
