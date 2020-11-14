using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    

    private Transform target;
    private int wavePointIndex = 0;

    public float health;
    public float startHealth = 20;

    public int scoreWorth = 10;

    public GameObject deathEffect;

    [Header("Balagan")]
    private Transform self;
    Vector3 posOffset = new Vector3(0, 3f, 0);
    Vector3 currYPos;
    public float floatSpeed = 1f;
    private bool goingUp = true;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }


    void Update()
    {
        Move();
        Rotate();
        //Float();
    }

    private void Rotate()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        transform.LookAt(target.position);
    }

    void GetNextWaypoint()
    {
        if(wavePointIndex >= Waypoints.points.Length -1)
        {
            Destroy(gameObject);
            PlayerStats.lives--;
            WaveSpawner.enemiesAlive--;
            return;
        }

        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
       // Destroy(effect);
        PlayerStats.currScore += scoreWorth;
        PlayerStats.overallScore += scoreWorth;
        WaveSpawner.enemiesAlive--;
        PlayerStats.bombPoints++;
        PlayerStats.upgradePoints++;
        //Debug.Log(WaveSpawner.enemiesAlive);
        Destroy(gameObject);
    }

    void Move()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.012f)
        {
            GetNextWaypoint();
        }
    }
}
