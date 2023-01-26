using System;
using System.Collections;
using System.Collections.Generic;
using SGoap;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BFAGameManager : ModernBehaviour
{

    [Space, Header("Config:")] 
    [SerializeField] private float m_gameTimeSeconds;
    [Space, Header("Events:")]
    [SerializeField] private UnityEvent m_onGamePaused;
    [SerializeField] private UnityEvent m_onGameContinue;
    [SerializeField] private UnityEvent m_onGameOver;
    
    public static BFAGameManager Instance { get; private set; }

    public float GameTimeSeconds => _gameTimer;
    public static bool IsPaused { get; private set; }
    public static bool IsGameOver { get; private set; }

    private ScoreVisualizer[] _allScoreVisualizers;
    private float _gameTimer;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        
        #region Input Init

        GameplayInputManager.Instance.CharacterInput.Pause.performed 
            += context =>
            {
                if (IsGameOver)
                    return;
                
                if (!IsPaused)
                    PauseGame();
                else
                    ContinueGame();
            };


        #endregion

        _allScoreVisualizers = FindObjectsOfType<ScoreVisualizer>();
        m_onGameOver.AddListener(() =>
        {
            foreach (var visualizer in _allScoreVisualizers)
                visualizer.VisualizeScore();
            
        });

        IsGameOver = false;
    }
    
    private void Start()
    {
        ContinueGame();
        _gameTimer = m_gameTimeSeconds;
    }

    protected override void Update()
    {
        base.Update();

        if (_gameTimer > 0 && IsGameOver == false)
        {
            if (!Instance)
                IsGameOver = false;
            _gameTimer -= Time.deltaTime;
        }
        else
        {
            if (!IsGameOver)
                GameOver();
        }
        
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        IsPaused = true;
        m_onGamePaused?.Invoke();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        IsPaused = false;
        m_onGameContinue?.Invoke();
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        _gameTimer = 0;
        IsGameOver = true;
        Time.timeScale = 0;
        m_onGameOver?.Invoke();
    }
}
