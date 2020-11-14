using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject ExplosionEffect;
    private int dmgAmount = 1000;

    private void OnCollisionEnter(Collision collision)
    {
        var position = Instantiate(ExplosionEffect, collision.transform.position, Quaternion.identity);
        Destroy(this.gameObject);

        
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.TakeDamage(dmgAmount);
        }
    }
}
