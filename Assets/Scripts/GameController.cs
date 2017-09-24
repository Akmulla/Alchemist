using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Game,Inventory};

public class GameController : MonoBehaviour
{
    public static GameController gc;
    GameState game_state=GameState.Game;
    float saved_time_scale = 1.0f;
    //public int enemy_spawned;
    public int enemy_killed;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (State==GameState.Game)
            {
                Inventory();
            }
            else
            {
                if (State == GameState.Inventory)
                {
                    Game();
                }
            }
        }
    }

	void Awake ()
    {
        gc = this;
        
    }
    void Start()
    {
        UIController.ui.UpdateUI();
    }
    public void Inventory()
    {
        saved_time_scale = Time.timeScale;
        Time.timeScale = 0.0f;
        State = GameState.Inventory;
        UIController.ui.UpdateUI();
    }

    public void Game()
    {
        Time.timeScale = saved_time_scale;
        State = GameState.Game;
        UIController.ui.UpdateUI();
    }
}
