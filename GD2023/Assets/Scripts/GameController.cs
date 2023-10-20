using System;using UnityEngine;

//This is very much stubbed in, this is not the gospel for the game flow
public enum GameState
{
    Loading,
    Menu,
    Gameplay,
    Gameover
} 

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    void Awake()
    {
        Instance = this;
    }
}
