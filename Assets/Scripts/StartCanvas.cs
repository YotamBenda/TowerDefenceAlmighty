using GoogleARCore.Examples.ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    [SerializeField]
    private Canvas startCanvas;
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private Button[] buttons;
    private int currButton = 0;
    [SerializeField]
    private Text[] texts;
    private int currText = 0;

    [SerializeField]
    private Button fireButton;

    public ManipulationSystem maniSys;

    //[SerializeField]
    //private GameObject manipulation;
    //[SerializeField]
    //private GameObject manipulationSystem;
    //[SerializeField]
    //private GameObject pawnManipulator;

    private Node nodeRef;
    //public static bool canBuild = false;

    private WaveSpawner waveSpawn;
    public void StartLevel()
    {
        startCanvas.gameObject.SetActive(false);
        texts[currText].gameObject.SetActive(false);
        buttons[currButton].gameObject.SetActive(false);
        gameManager.GetComponent<WaveSpawner>().enabled = true;
        //maniSys.ShouldDisable(true);
        //manipulation.gameObject.SetActive(false);
        //manipulationSystem.gameObject.SetActive(false);
        //pawnManipulator.gameObject.SetActive(false);
        //fireButton.gameObject.SetActive(true);
    }

    public void NextStep()
    {
        texts[currText].gameObject.SetActive(false);
        buttons[currButton].gameObject.SetActive(false);
        currText++;
        currButton++;
        if(currText == texts.Length)
        {
            StartLevel();
            return;
        }
        
        texts[currText].gameObject.SetActive(true);
        buttons[currButton].gameObject.SetActive(true);
        //maniSys.ShouldDisable(true);
        //manipulation.gameObject.SetActive(false);
        //manipulationSystem.gameObject.SetActive(false);
        //pawnManipulator.gameObject.SetActive(false);
        //gameManager.GetComponent<BuildManager>().enabled = true
    }

}
