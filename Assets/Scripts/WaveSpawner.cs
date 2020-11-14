using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public static int maxWaves;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countDown = 3f;

    public Text waveCountdownText;

    private int waveNum = 0;

    void Start()
    {
        maxWaves = waves.Length;
    }

    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        if (waveNum < waves.Length)
        {
            countDown -= Time.deltaTime;
            countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        }
        
        waveCountdownText.text = string.Format("{0:0.0}", countDown);

        WinRound();
    }

    IEnumerator SpawnWave()
    {
        if (waveNum < waves.Length)
        {
            PlayerStats.roundsSurvived++;
            Wave wave = waves[waveNum];
            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                enemiesAlive++;
                Debug.Log(enemiesAlive);
                yield return new WaitForSeconds(1f / wave.rate);
            }

            waveNum++;
        }
        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    void WinRound()
    {
        if (waveNum == waves.Length && enemiesAlive == 0)
        {
            Debug.Log("Game won!");
            GameManager.gameWon = true;
            this.enabled = false;
        }
    }
}
//LastUpdate2