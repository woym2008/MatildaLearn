using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    static private GameManager _instance;
    static public GameManager getInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    private bool _enableGame = false;
    public bool IsGameStart
    {
        get
        {
            return _enableGame;
        }
    }

    public void GameInit()
    {
        InputManager.getInstance.InitInputManager();
        EnemyManager.getInstance.InitEnemyManager();
        PlayerManager.getInstance.InitPlayerManager();
    }
    
    public void GameStart()
    {
        _enableGame = true;
        PlayerManager.getInstance.StartPlayer();
        EnemyManager.getInstance.StartEnemyManager();
    }

    public void GameOver()
    {
        _enableGame = false;

        EnemyManager.getInstance.StopEnemyManager();
    }

    //游戏主循环
    public void GameUpdate()
    {
        InputManager.getInstance.Update();
        PlayerManager.getInstance.Update();
        EnemyManager.getInstance.Update();
    }
}
