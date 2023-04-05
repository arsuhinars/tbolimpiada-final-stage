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

    public bool IsGameStarted { get; private set; }
    public bool IsGamePaused { get; private set; }

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    public void RestartGame()
    {

    }

    public void EndGame()
    {

    }

    public void PauseGame()
    {

    }

    public void ResumeGame()
    {

    }
}
