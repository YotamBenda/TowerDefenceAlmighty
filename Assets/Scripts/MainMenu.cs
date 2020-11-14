using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string lvlToLoad = "Level1";
    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo(1);
    }
    

}
