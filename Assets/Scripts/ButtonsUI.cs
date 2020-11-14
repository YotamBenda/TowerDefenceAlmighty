using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsUI : MonoBehaviour
{
    public GameObject cannon;
    //public GameObject ground;
    //public Camera cameraScreen;
    public bool canShoot = false;

    public void SpawnCannon()
    {
        if(canShoot == true)
        {
            cannon.SetActive(true);
            PlayerStats.bombPoints -= 4;
            if(PlayerStats.bombPoints < 4)
            {
                canShoot = false;
            }
        }
        //cannon.transform.position = new Vector3(cameraScreen.transform.position.x, cameraScreen.transform.position.y, cameraScreen.transform.position.z - 10F);
    }
    private void Update()
    {
        if (PlayerStats.bombPoints >= 4)
        {
            canShoot = true;
        }
        

        if (Input.GetMouseButtonDown(1))
        {
            cannon.SetActive(false);
        }
    }


}
