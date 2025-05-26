using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public TextMeshProUGUI coinTxt;
    private int coin;
    private int tapCount;
    private bool isPlaying = false;

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
                    coin++;
                    coinTxt.text = "coin : " + coin.ToString();
                }
            }
        }
    }

    public int GetPlayerCoin()
    {
        return coin;
    }

    public void SetPlayerCoin(int currentCoin)
    {
        coin = currentCoin;
    }
}
