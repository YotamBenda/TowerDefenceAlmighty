using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody bomb;
    public GameObject cursor;
    public Transform shootPoint;
    public LayerMask layer;
    public GameObject fireEffect;
    public GameObject CannonRef;

    public GameObject cubeTest;
    

    private Vector3 offset = new Vector3(0, 5, 0);

    public Camera cam;

    void Start()
    {
        CannonRef = GameObject.FindWithTag("Canon");
    }

    void Update()
    {
        launchProjectile();
    }

    void launchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(camRay, out hit,5000f, layer))
        {
           
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up;
           // cursor.transform.position = hit.point + Vector3.up * 0.1f;

            // Vector3 Velocity = CalculaterVelocoity(hit.point, shootPoint.position, 2f);

            //transform.rotation = Quaternion.LookRotation(Velocity);

            if (Input.GetMouseButtonUp(0))
            {
              
                
                    ////var position =  Instantiate(fireEffect, shootPoint.position, Quaternion.identity);
                    //Rigidbody obj = Instantiate(bomb, hit.point + offset, Quaternion.identity);
                    ////obj.velocity = Velocity;
                    var cube = Instantiate(bomb, hit.point + offset, Quaternion.identity);
                    CannonRef.SetActive(false);
                    //ScoreUI.score -= 3;  
            }
        }
        else
        {
            cursor.SetActive(false);
        }
    }

    Vector3 CalculaterVelocoity(Vector3 target,Vector3 origin,float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        //create a float that represent our distance
        float Sy = distance.y;
        float Sxz = distance.magnitude;

        float velocityXZ = Sxz / time;
        float velocityY = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y*0.6f) * time;

        Vector3 result = distanceXZ.normalized;
        result *= velocityXZ;
        result.y = velocityY;

        return result;
    }
}
