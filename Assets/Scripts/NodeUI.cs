using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
	private Node target;

    public TextMeshProUGUI upgradeCost;
	public Button upgradeButton;

    public TextMeshProUGUI sellAmount;
    
	public void SetTarget(Node newTarget)
	{
		target = newTarget;
		transform.position = target.GetBuildPosition();

        if(!target.isUpgraded) {
			upgradeCost.text = "<b>UPGRADE</b> <br>$" + target.turretBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		} else {
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}

        sellAmount.text = "<b>SELL</b> <br>$" + target.turretBlueprint.GetSellAmount();

		ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
        Debug.Log("Hiding");
	}

    public void Upgrade()
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}

    public void Sell()
	{
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}
}
