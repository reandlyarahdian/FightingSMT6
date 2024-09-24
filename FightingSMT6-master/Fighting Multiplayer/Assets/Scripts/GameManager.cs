using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;
using System;
using Photon.Pun;
using Photon.Realtime;

public enum GameMode
{
    SinglePlayer,
    LocalMultiplayer,
    OnlineMulyiplayer
}

public class GameManager : Singleton<GameManager>
{

    //Game Mode
    public GameMode currentGameMode;

    //Single Player
    public GameObject inScenePlayer;
    public GameObject insceneEnemy;

    //Local Multiplayer
    public GameObject[] playerPrefab;
    private int numberOfPlayers = 2;

    public Transform spawnRingCenter;
    public float spawnRingRadius;

    public Transform[] spawnpoints;

    public GameObject canvas;

    public CinemachineTargetGroup target;

    public GameObject death, PopUp;

    public TextMeshProUGUI text;

    public int index;

    //Spawned Players
    private List<PlayerController> activePlayerControllers;
    private List<AI> activeAIEnemy;
    public List<HealthStats> stats;


    void Start()
    {
        GameSetting.Instance.Setup();
        for (int i = 0; i < numberOfPlayers; i++) 
        {
            stats.Add(canvas.GetComponentsInChildren<HealthStats>()[i]);
        }
        SetupBasedOnGameState();
    }

    void SetupBasedOnGameState()
    {
        switch (currentGameMode)
        {
            case GameMode.SinglePlayer:
                SetupSinglePlayer();
                break;

            case GameMode.LocalMultiplayer:
                SetupLocalMultiplayer();
                break;
            case GameMode.OnlineMulyiplayer:
                SetupOnlineMultiplayer();
                break;
        }
    }

    private void SetupOnlineMultiplayer()
    {
        activePlayerControllers = new List<PlayerController>();

        for (int i = 0; i < spawnpoints.Length; i++)
        {
            AddPlayerToActivePlayerList(spawnpoints[i].GetComponentInChildren<PlayerController>());
        }

        SetupActivePlayers();
    }

    void SetupSinglePlayer()
    {
        activePlayerControllers = new List<PlayerController>();
        activeAIEnemy = new List<AI>();
        if (inScenePlayer == true )
        {
            AddPlayerToActivePlayerList(inScenePlayer.GetComponent<PlayerController>());
            
        }
        else if (insceneEnemy == true)
        {
            AddEnemyToActiveList(insceneEnemy.GetComponent<AI>());
        }
        else
        {
            SpawnPlayers();
            SpawnAiEnemy();
        }

        SetupAIEnemy();

        SetupActivePlayers();

       
    }

    void SetupLocalMultiplayer()
    {

        if (inScenePlayer == true)
        {
            Destroy(inScenePlayer);
        }

        SpawnPlayers();

        SetupActivePlayers();
    }

    public void GameDeath()
    {
        index = index % 2 == 0 ? 1 : 2;
        text.text = "Player " + index + " Win";
        death.SetActive(true);
        PopUp.SetActive(true);
    }

    void SpawnPlayers()
    {

        activePlayerControllers = new List<PlayerController>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject spawnedPlayer = Instantiate(playerPrefab[i], spawnpoints[i].position, spawnpoints[i].rotation) as GameObject;
            AddPlayerToActivePlayerList(spawnedPlayer.GetComponent<PlayerController>());

        }
    }

    void SpawnAiEnemy()
    {

        activeAIEnemy = new List<AI>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject spawnedEnemy = Instantiate(playerPrefab[i], spawnpoints[i].position, spawnpoints[i].rotation) as GameObject;
            AddEnemyToActiveList(spawnedEnemy.GetComponent<AI>());
        }
    }

    void AddPlayerToActivePlayerList(PlayerController newPlayer)
    {
        activePlayerControllers.Add(newPlayer);
    }

    void AddEnemyToActiveList(AI newAI)
    {
        activeAIEnemy.Add(newAI);
    }

    void SetupActivePlayers()
    {
        for (int i = 0; i < activePlayerControllers.Count; i++)
        {
            activePlayerControllers[i].SetupPlayer(stats[i], i + 1);
            target.m_Targets[i].target = activePlayerControllers[i].transform;
        }
    }

    void SetupAIEnemy()
    {
        for (int i = 0; i < activeAIEnemy.Count; i++)
        {
            activeAIEnemy[i].SetupPAI(stats[i], i + 1);
           
        }
    }

    Vector3 CalculatePositionInRing(int positionID, int numberOfPlayers)
    {
        if (numberOfPlayers == 1)
            return spawnRingCenter.position;

        float angle = (positionID) * Mathf.PI * 2 / numberOfPlayers;
        float x = Mathf.Cos(angle) * spawnRingRadius;
        float z = Mathf.Sin(angle) * spawnRingRadius;
        return spawnRingCenter.position + new Vector3(x, 3, z);
    }

    Quaternion CalculateRotation(int i)
    {
        float y = i % 2 == 0 ? 0 : 180;
        return Quaternion.Euler(new Vector3(0, y, 0));
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene 2");
        GameSetting.Instance.mode = GameMode.LocalMultiplayer;
    }
}
