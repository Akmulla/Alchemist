using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Game,Pause};

public class GameController : MonoBehaviour
{
    public static GameController gc;
    GameState game_state=GameState.Game;

    public GameState State
    {
        get
        {
            return game_state;
        }
        set
        {
            game_state = value;
        }
    }

	void Awake ()
    {
        gc = this;
	}

}
