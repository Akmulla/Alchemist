using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilType {Active,Passive,None }
[CreateAssetMenu()]
public class CharData : ScriptableObject
{
    //public Sprite bottle_sprite;
    //public AbilType abli1;
    //public string description1;
    //public AbilType abli2;
    //public string description2;
    //public AbilType abli3;
    //public string description3;
    public BottleData bottle_data;
    public int hp_base;
    public float speed_base;
    public float reload_1;
    public float reload_2;
}
