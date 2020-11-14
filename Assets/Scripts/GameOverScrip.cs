using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScrip : MonoBehaviour
{
    public Text endScoreText;
    public Text roundsSurvivedText;

    public SceneFader fader;

    
    void OnEnable()
    {
        endScoreText.text = PlayerStats.overallScore.ToString();
        roundsSurvivedText.text = PlayerStats.roundsSurvived.ToString();
        PlayerStats.overallScore = 0;
        PlayerStats.roundsSurvived = 0;
    }

    public void TryAgain()
    {
        fader.FadeTo(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        fader.FadeTo(0);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex;
        nextLevel++;
        fader.FadeTo(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
