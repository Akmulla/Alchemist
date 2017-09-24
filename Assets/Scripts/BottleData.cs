using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType { None,Active,Passive};

[System.Serializable]
public struct Ability
{
    public AbilityType ability_type;
    public float cooldown;
    public EnemyType enemy_type;
}

[CreateAssetMenu]
public class BottleData : ScriptableObject
{
    public Sprite bottle_sprite;
    public Ability[] abil;
    public Sprite char_sprite;
}
