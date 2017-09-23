using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharData char_data;
    protected CharacterControls character;
    protected Transform tran;
    protected int hp=1;

    void Awake()
    {
        character = GetComponent<CharacterControls>();
        tran = GetComponent<Transform>();
    }

	protected virtual void OnEnable ()
    {
        hp = char_data.hp_base;
        character.speed = char_data.speed_base;
	}

	public void GetHit(int damage)
    {
        hp -= damage;
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }
}
