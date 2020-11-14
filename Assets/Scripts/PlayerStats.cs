using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int lives;
    [SerializeField] private int startLives = 5;

    public static int currScore = 0;

    public static int roundsSurvived = 0;

    public static int overallScore = 0;

    public static int bombPoints = 0;

    public static int upgradePoints = 0;
    
    void Start()
    {
        lives = startLives;
        currScore = 0;
        roundsSurvived = 0;
        bombPoints = 0;
        upgradePoints = 0;
    }
    



}
