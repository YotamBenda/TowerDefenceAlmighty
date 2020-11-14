using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonUI : MonoBehaviour
{
    [SerializeField]
    private Button upgradeButton;

    private void Update()
    {
        EnableUpgradeButton();
    }
    public void EnableUpgradeButton()
    {
        if(PlayerStats.upgradePoints >= 5 && BuildManager.instance.upgradedAmount < BuildManager.instance.maxTurrets)
        {
            upgradeButton.gameObject.SetActive(true);
        }
        else
        {
            upgradeButton.gameObject.SetActive(false);
        }
    }
}
