using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;
    public GameObject standardTurretPrefab;
    public GameObject upgradedTurret;
    public int turretsAmount = 0;
    public int maxTurrets = 8;

    public int upgradedInStock = 0;
    public int upgradedAmount = 0;

    public bool shouldUpgrade = false;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        if (upgradedInStock > 0)
        {
            turretToBuild = upgradedTurret;
            upgradedInStock--;
        }
        else
        {
            turretToBuild = standardTurretPrefab;
        }
        
        return turretToBuild;
    }

    public void UpgradeTurret()
    {
        shouldUpgrade = true;
    }

}
