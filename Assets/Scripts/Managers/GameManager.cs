using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    public event Action OnGamePaused;
    public event Action OnGameResumed;

    public static GameManager Instance { get; private set; } = null;

    public bool IsGameStarted { get; private set; }
    public bool IsGamePaused { get; private set; }

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

    private IEnumerator Start()
    {
        yield return null;
        RestartGame();
    }

    public void RestartGame()
    {
        IsGameStarted = true;
        OnGameStart?.Invoke();
    }

    public void EndGame()
    {
        IsGameStarted = true;
        OnGameEnd?.Invoke();
    }

    public void PauseGame()
    {
        IsGamePaused = true;
        Time.timeScale = 0f;
        OnGamePaused?.Invoke();
    }

    public void ResumeGame()
    {
        IsGamePaused = false;
        Time.timeScale = 1f;
        OnGameResumed?.Invoke();
    }
}
