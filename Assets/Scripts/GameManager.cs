using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameLost;
    public static bool gameWon;
    public static int winScore = 300;
    public GameObject gameOverUI;
    public GameObject LevelWonUI;

    void Start()
    {
        gameLost = false;
        gameWon = false;
    }
    void Update()
    { 
        if (gameLost)
            return;
        if (PlayerStats.lives <= 0)
        {
            LostGame();
        }
        
        if (gameWon)
        {
            WinGame();
        }
    }

    void LostGame()
    {
        gameLost = true;
        gameOverUI.SetActive(true);
    }

    void WinGame()
    {
        gameWon = true;
        LevelWonUI.SetActive(true);
    }
}
