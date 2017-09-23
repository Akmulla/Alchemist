using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo player;
    public Transform tran;

	// Use this for initialization
	void Awake ()
    {
        player = this;
	}

}
