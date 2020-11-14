using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject menu;
    public Text currScoreText;
    public Text currRoundsText;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        menu.SetActive(!menu.activeSelf);
        currScoreText.text = PlayerStats.currScore.ToString();
        currRoundsText.text = PlayerStats.roundsSurvived.ToString();

        if (menu.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
