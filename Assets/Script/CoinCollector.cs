using UnityEngine;
using TMPro;
using System.Collections;

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coinTxt;
    public int coin;
    public int clickValue;
    [SerializeField] private int earlyCoin;
    [SerializeField] private int interval;
    private bool isPlaying = false;
    private bool isAddCoin = false;

    private void Start()
    {
        AddCoin();
        // UpdateCoinText();
    }

    private void OnEnable()
    {
        GameStateManager.OnGameStateChanged += HandlerGameStateChanged;
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= HandlerGameStateChanged;
    }

    private void HandlerGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Playing:
                EnablePlay();
                break;
        }
    }

    private void EnablePlay()
    {
        isPlaying = true;
    }

    private void Update()
    {
        UpdateCoinText();
        if (isPlaying)
        {
            TapCount();
        }
    }

    private void TapCount()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Cek fase touch dimulai
            if (touch.phase == TouchPhase.Began)
            {
                if (!GameStateManager.Instance.GetUIButton() && !GameStateManager.Instance.GetUIButton())
                {
                    coin += clickValue;
                    SpawnerManager.Instance.SpawnObject();
                }
            }
        }
    }

    private void UpdateCoinText()
    {
        coinTxt.text = "coin : " + coin.ToString();
    }

    public int GetPlayerCoin()
    {
        return coin;
    }

    public void SetPlayerCoin(int addCoin)
    {
        clickValue += addCoin;
    }

    public void AddCoin()
    {
        if (!isAddCoin)
        {
            StartCoroutine(AutoAddCoinCoroutine());
            isAddCoin = false;
        }
    }

    IEnumerator AutoAddCoinCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            coin += earlyCoin;
            isAddCoin = true;
            // Debug.Log("Coin: " + coin); // Debug agar bisa terlihat di Console
        }
    }
}
