using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public Enemy enemy;
    public int damage = 10;

    public GameObject impactEffect;
    private Vector3 effectOffset = new Vector3(0, 0.015f, 0);

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position + effectOffset, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);
        Damage(target);
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e !=null)
        {
            e.TakeDamage(damage);
        }
    }
}


