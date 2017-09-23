using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Ability
{
    public AbilType abil_type;
    public string description;
    public EnemyType enemy_type;
}

[CreateAssetMenu]
public class BottleData : ScriptableObject
{
    public Ability[] ability;
    public Sprite sprite;
}
