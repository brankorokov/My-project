using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameState _gameState;

    public enum GameState
    {
        INTRO,
        LEVEL1,
        GAMEOVER
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is null");

            return _instance;
        }
        
    }

    private void Awake()
    {
        if(_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
      
    }

    public void Update()
    {
        if (GetState() == GameState.GAMEOVER)
        {
            HandleGameOver();
        }
    }

    public GameState GetState()
    {
        return _gameState;
    }
    public void PlayerDeath()
    {
        ChangeState(GameState.GAMEOVER);
    }

    private void ChangeState(GameState state)
    {
        _gameState = state;
    }

    private void OnApplicationQuit()
    {
        _instance = null;
    }

    private void HandleGameOver()
    {
        _gameState = GameState.INTRO;
        SceneManager.LoadScene("Level1");
    }

}
