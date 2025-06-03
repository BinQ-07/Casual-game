using UnityEngine;
using TMPro;
using UnityEngine.UI;

// public enum TeaType
// {
//     TehHijau,
//     TehHitam,
//     TehPutih,
//     TehOolong,
//     TehHerbal,
//     TehMatcha
// }

// public enum Ingredients
// {
//     Madu,
//     Lemon,
//     Jahe,
//     Susu,
//     Boba
// }

public class UpgradeManager : MonoBehaviour
{
    // public TeaType teaType;
    // public Ingredients ingredients;
    private CoinCollector coinPlayer;
    [SerializeField] int upgradeCost;
    public int clickIncrease = 1;
    private Button button;
    public TextMeshProUGUI levelTxt;
    public TextMeshProUGUI upgradeButtonText;
    private int level = 1;

    private void Start()
    {
        coinPlayer = FindAnyObjectByType<CoinCollector>();
        button = GetComponent<Button>();
        UpdateUI();
    }

    private void Update()
    {
        if (coinPlayer.GetPlayerCoin() < upgradeCost)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void BuyUpgrade()
    {
        if (coinPlayer.GetPlayerCoin() >= upgradeCost)
        {
            // button.interactable = true;
            coinPlayer.coin -= upgradeCost;
            coinPlayer.SetPlayerCoin(clickIncrease);
            level++;
            upgradeCost *= 2;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        levelTxt.text = $"Level {level}";
        upgradeButtonText.text = $"Buy \n ({upgradeCost})";
    }
}
