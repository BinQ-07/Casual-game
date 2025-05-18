using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public CoffeeClicker clicker;
    public int upgradeCost = 50;
    public int clickIncrease = 1;
    public TMP_Text upgradeButtonText;

    public void BuyUpgrade()
    {
        if (clicker.coin >= upgradeCost)
        {
            clicker.coin -= upgradeCost;
            clicker.clickValue += clickIncrease;
            upgradeCost *= 2;
            UpdateUI();
        }
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        upgradeButtonText.text = $"Upgrade (+{clickIncrease})\n[{upgradeCost} Co]";
   
    }
}
