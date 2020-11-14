using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    public Vector3 positionOffset = new Vector3(0f, 0.0015f, 0);
    public Color tooManyTurrets;
    private GameObject effect;
    public GameObject turrentSpawnEffect;


    private Renderer rend;

    private GameObject turret;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            //This "if" checks the if the upgraded button was pressed and we should upgrade the chosen turret
            if (BuildManager.instance.shouldUpgrade == true)
            {
                //if the chosen turret is already an upgraded one, it returns and the upgrade function is waiting for next Node input
                if(turret.gameObject.tag == "Turret2")
                {
                    return;
                }
                //if the chosen turret isn't upgraded yet, upgrade the hell up.
                UpgradeTurret();
                BuildManager.instance.shouldUpgrade = false;
                return;
            }
            //if the upgraded funtion wasnt activated, but there is already a turret on the chosen Node, delete the turret (to replace it)
            else
            {
                if (turret.gameObject.tag == "Turret2")
                {
                    BuildManager.instance.upgradedInStock++;
                }

                Destroy(turret);
                BuildManager.instance.turretsAmount--;
                gameObject.tag = "Node";
                return;
            }
        }
        //if the chosen Node is empty, and the player has turrets at his disposle, instantiate a turret.
        if (BuildManager.instance.turretsAmount < BuildManager.instance.maxTurrets)
        {
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            effect = (GameObject)Instantiate(turrentSpawnEffect, transform.position + positionOffset, Quaternion.identity);

            BuildManager.instance.turretsAmount++;
            turret.transform.SetParent(this.transform);
            gameObject.tag = "Occupied";
        }
    }
    private void OnMouseEnter()
    {
        if (BuildManager.instance.turretsAmount < BuildManager.instance.maxTurrets)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = tooManyTurrets;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    //Upgrade the chosen turret.
    public void UpgradeTurret()
    {
        if(turret != null)
        {
            Destroy(turret);
            GameObject newTurret = BuildManager.instance.upgradedTurret;
            turret = (GameObject)Instantiate(newTurret, transform.position + positionOffset, transform.rotation);
            turret.transform.SetParent(this.transform);
            PlayerStats.upgradePoints -= 5;
            BuildManager.instance.upgradedAmount++;
        }
    }

}
