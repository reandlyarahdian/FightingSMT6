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


public class GameManager : Singleton<GameManager>
{
    public GameMode mode;
    public GameObject inScenePlayer;
    public GameObject playerPrefab;
    private List<PlayerController> activeControllers;
    private int players = 2;
    public Transform RingCenter;
    public float RingRadius;

    void Start()
    {
        SetupMode();
    }

    private void SetupMode()
    {
        switch (mode)
        {
            case GameMode.SinglePlayer:
                SinglePlayer();
                break;
            case GameMode.LocalMultiplayer:
                MultiPlayer();
                break;
            case GameMode.OnlineMultiplayer:
                Online();
                break;
        }
    }


    void SpawnPlayers()
    {

        activeControllers = new List<PlayerController>();

        for (int i = 0; i < players; i++)
        {
            Vector3 spawnPosition = PositionInRing(i, players);
            Quaternion spawnRotation = Rotation(i);

            GameObject spawnedPlayer = Instantiate(playerPrefab, spawnPosition, spawnRotation) as GameObject;
            AddPlayer(spawnedPlayer.GetComponent<PlayerController>());
        }
    }

    private void Online()
    {
        throw new NotImplementedException();
    }

    private void MultiPlayer()
    {
        if (inScenePlayer == true)
        {
            Destroy(inScenePlayer);
        }

        SpawnPlayers();

        Activate();
    }

    private void SinglePlayer()
    {
        activeControllers = new List<PlayerController>();

        if (inScenePlayer == true)
        {
            AddPlayer(inScenePlayer.GetComponent<PlayerController>());
        }

        Activate();
    }

    private void AddPlayer(PlayerController playerController)
    {
        activeControllers.Add(playerController);
    }

    void Activate()
    {
        for (int i = 0; i < activeControllers.Count; i++)
        {
            activeControllers[i].SetupPlayer(i);
        }
    }
    Vector3 PositionInRing(int positionID, int numberOfPlayers)
    {
        if (numberOfPlayers == 1)
            return RingCenter.position;

        float angle = (positionID) * Mathf.PI * 2 / numberOfPlayers;
        float x = Mathf.Cos(angle) * RingRadius;
        float z = Mathf.Sin(angle) * RingRadius;
        return RingCenter.position + new Vector3(x, 0, z);
    }

    private Quaternion Rotation(int i)
    {
        float y = i % 2 == 0 ? 270 : 90;
        return Quaternion.Euler(new Vector3(0, y, 0));
    }
}
