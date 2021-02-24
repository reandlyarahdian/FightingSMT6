using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameMode
{
    SinglePlayer,
    LocalMultiplayer,
    OnlineMultiplayer
}
<<<<<<< Updated upstream


public class GameManager : Singleton<GameManager>
{
    public GameMode GameMode;

=======

public class GameManager : Singleton<GameManager>
{
    public GameMode gameMode;
>>>>>>> Stashed changes
    public GameObject inScenePlayer;
    private PlayerController Controller;

    public GameObject playerPrefab;
    public int numberOfPlayers;

    public Transform spawnRingCenter;
    public float spawnRingRadius;

<<<<<<< Updated upstream
    private List<PlayerController> activePlayerControllers;

    void Start()
    {
        SetupBasedOnGameState();
    }

    void SetupBasedOnGameState()
    {
        switch (GameMode)
=======
    //Spawned Players
    private List<PlayerController> PlayerControllers;

    void Start()
    {
        GameState();
    }

    void GameState()
    {
        switch (gameMode)
>>>>>>> Stashed changes
        {
            case GameMode.SinglePlayer:
                SetupSinglePlayer();
                break;

            case GameMode.LocalMultiplayer:
                SetupLocalMultiplayer();
                break;
            case GameMode.OnlineMultiplayer:
                SetupOnlineMultiplayer();
                break;
        }
    }

<<<<<<< Updated upstream
    private void SetupOnlineMultiplayer()
    {
        throw new NotImplementedException();
    }

    private void SetupSinglePlayer()
    {
        activePlayerControllers = new List<PlayerController>();

        if (inScenePlayer == true)
        {
            PlayerToActive(inScenePlayer.GetComponent<PlayerController>());
        }

        Activate();
    }

    private void SetupLocalMultiplayer()
    {
        if (inScenePlayer == true)
        {
            Destroy(inScenePlayer);
        }

        SpawnPlayers();

        Activate();
    }

    void SpawnPlayers()
    {

        activePlayerControllers = new List<PlayerController>();
=======
    private void SetupSinglePlayer()
    {
        PlayerControllers = new List<PlayerController>();

        if (inScenePlayer == true)
        {
            AddPlayerToActivePlayerList(inScenePlayer.GetComponent<PlayerController>());
        }else 
            SpawnPlayers();

        Activate();
    }

    private void SetupOnlineMultiplayer()
    {
        if (inScenePlayer == true)
        {
            Destroy(inScenePlayer);
        }

        SpawnPlayers();

        Activate();
    }

    private void SetupLocalMultiplayer()
    {
        if (inScenePlayer == true)
        {
            Destroy(inScenePlayer);
        }

        SpawnPlayers();

        Activate();
    }

    void SpawnPlayers()
    {

        PlayerControllers = new List<PlayerController>();
>>>>>>> Stashed changes

        for (int i = 0; i < numberOfPlayers; i++)
        {
            Vector3 spawnPosition = CalculatePositionInRing(i, numberOfPlayers);
            Quaternion spawnRotation = CalculateRotation(i);

            GameObject spawnedPlayer = Instantiate(playerPrefab, spawnPosition, spawnRotation) as GameObject;
<<<<<<< Updated upstream
            PlayerToActive(spawnedPlayer.GetComponent<PlayerController>());
        }
    }

    void Activate()
    {
        for (int i = 0; i < activePlayerControllers.Count; i++)
        {
            activePlayerControllers[i].SetupPlayer();
        }
    }

    void PlayerToActive(PlayerController newPlayer)
    {
        activePlayerControllers.Add(newPlayer);
    }

    Vector3 CalculatePositionInRing(int positionID, int numberOfPlayers)
=======
            AddPlayerToActivePlayerList(spawnedPlayer.GetComponent<PlayerController>());
        }
    }

    private void AddPlayerToActivePlayerList(PlayerController playerController)
    {
        PlayerControllers.Add(playerController);
    }

    void Activate()
    {
        for (int i = 0; i < PlayerControllers.Count; i++)
        {
            PlayerControllers[i].SetupPlayer();
        }
    }

    Vector3 CalculatePositionInRing(int i, int numberOfPlayers)
>>>>>>> Stashed changes
    {
        if (numberOfPlayers == 1)
            return spawnRingCenter.position;

<<<<<<< Updated upstream
        float angle = (positionID) * Mathf.PI * 2 / numberOfPlayers;
=======
        float angle = (i) * Mathf.PI * 2 / numberOfPlayers;
>>>>>>> Stashed changes
        float x = Mathf.Cos(angle) * spawnRingRadius;
        float z = Mathf.Sin(angle) * spawnRingRadius;
        return spawnRingCenter.position + new Vector3(x, 0, z);
    }

    Quaternion CalculateRotation(int i)
    {
        float y = i % 2 == 0 ? 270 : 90;
        return Quaternion.Euler(new Vector3(0, y, 0));
    }
}
