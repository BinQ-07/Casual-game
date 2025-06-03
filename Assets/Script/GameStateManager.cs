using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum GameState
    {
        WaitingToStart,
        Playing,
    }

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public static event Action<GameState> OnGameStateChanged;
    public GameState currentState = GameState.WaitingToStart;

    [Header("UI Settings")]
    [SerializeField] private GraphicRaycaster graphicRaycaster;
    [SerializeField] private LayerMask uiLayerMask; // Layer mask untuk UI elements
    [SerializeField] private bool hitUIButton;
    [SerializeField] private bool hitUIPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Cek touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Cek fase touch dimulai
            if (touch.phase == TouchPhase.Began)
            {
                // Convert touch position ke pointer event data
                PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                eventDataCurrentPosition.position = touch.position;

                // Raycast untuk deteksi UI dengan layer specific
                List<RaycastResult> results = new List<RaycastResult>();
                graphicRaycaster.Raycast(eventDataCurrentPosition, results);

                // Filter hasil raycast berdasarkan layer
                hitUIButton = false;
                hitUIPanel = false;

                foreach (RaycastResult result in results)
                {
                    int layer = result.gameObject.layer;

                    // Jika objek adalah button, set flag button
                    if (((1 << layer) & uiLayerMask) != 0 && result.gameObject.CompareTag("UIButton"))
                    {
                        hitUIButton = true;
                    }
                    // Jika objek adalah panel, set flag panel
                    else if (((1 << layer) & uiLayerMask) != 0 && result.gameObject.CompareTag("UIPanel"))
                    {
                        hitUIPanel = true;
                    }
                }

                // Jika menekan button, tampilkan panel, tetapi jangan ubah state game
                if (hitUIButton)
                {
                    return;
                }
                // Jika menekan panel, abaikan input
                if (hitUIPanel)
                {
                    return;
                }
                else
                {
                    // Jika tidak mengenai UI, proses state game
                    switch (currentState)
                    {
                        case GameState.WaitingToStart:
                            PlayingGame();
                            break;

                        case GameState.Playing:
                            break;
                    }
                }

            }
        }
    }

    public void PlayingGame()
    {
        currentState = GameState.Playing;
        OnGameStateChanged?.Invoke(currentState);

        Debug.Log("Playing State");
    }

    public bool GetUIButton()
    {
        return hitUIButton;
    }

    public bool GetUIPanel()
    {
        return hitUIPanel;
    }

}
