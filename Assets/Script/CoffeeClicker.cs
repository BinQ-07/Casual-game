using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoffeeClicker : MonoBehaviour
{
    public TMP_Text coinText;
    public int coin = 0;
    private int tempcoin;
    public int clickValue = 1;

    public void OnCoffeeClicked()
    {
        coin += clickValue;
        //UpdateUI();
    }

    private void Update()
    {
        if (tempcoin != coin)
        {
            UpdateUI();
            tempcoin = coin;
        }
    }

    public void UpdateUI()
    {
        coinText.text = coin.ToString();
    }
}
