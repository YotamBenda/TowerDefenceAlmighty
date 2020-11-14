using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ScoreUI : MonoBehaviour
{
    public Text scoreText;
    public Text turretsAmountText;
    public Text lvlText;
    public TextMeshProUGUI turrentEnergy;
    public static int score;
    private int currentLevel;

    private void Start()
    {
        //turrentEnergy = FindObjectOfType<TextMeshProUGUI>();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        currentLevel++;

    }
    void Update()
    {
        //scoreText.text = "SCORE "  + PlayerStats.currScore.ToString() + "/ " + GameManager.winScore.ToString();
        scoreText.text = "WAVE " + PlayerStats.roundsSurvived +"/ " + WaveSpawner.maxWaves.ToString();
        turretsAmountText.text = "TURRETS "+ BuildManager.instance.turretsAmount.ToString()+ "/"+ BuildManager.instance.maxTurrets;
        lvlText.text = "LVL " + currentLevel.ToString();
        score = PlayerStats.bombPoints;
        turrentEnergy.text = "" + score + "/4";

    }
}
