using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetting : Singleton<GameSetting>
{
    public int index;
    public GameObject[] gameObjects;
    public GameMode mode;
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Setup()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameManager.Instance.currentGameMode = mode;
            GameManager.Instance.playerPrefab = gameObjects;
        }
    }
}
