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

    //Game Mode
    public GameMode currentGameMode;

    //Single Player
    public GameObject inScenePlayer;

    //Local Multiplayer
    public GameObject playerPrefab;
    private int numberOfPlayers = 2;

    public Transform spawnRingCenter;
    public float spawnRingRadius;

    public GameObject canvas;

    //Spawned Players
    private List<PlayerController> activePlayerControllers;
    public List<HealthStats> stats;
    void Start()
    {
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
            case GameMode.OnlineMultiplayer:
                SetupOnlineMultiplayer();
                break;
        }
    }

    private void SetupOnlineMultiplayer()
    {
        throw new System.NotImplementedException();
    }

    void SetupSinglePlayer()
    {
        activePlayerControllers = new List<PlayerController>();

        if (inScenePlayer == true)
        {
            AddPlayerToActivePlayerList(inScenePlayer.GetComponent<PlayerController>());
        }else 
            SpawnPlayers();

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

    void SpawnPlayers()
    {

        activePlayerControllers = new List<PlayerController>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            Vector3 spawnPosition = CalculatePositionInRing(i, numberOfPlayers);
            Quaternion spawnRotation = CalculateRotation(i);

            GameObject spawnedPlayer = Instantiate(playerPrefab, spawnPosition, spawnRotation) as GameObject;
            AddPlayerToActivePlayerList(spawnedPlayer.GetComponent<PlayerController>());
        }
    }

    void AddPlayerToActivePlayerList(PlayerController newPlayer)
    {
        activePlayerControllers.Add(newPlayer);
    }

    void SetupActivePlayers()
    {
        for (int i = 0; i < activePlayerControllers.Count; i++)
        {
            activePlayerControllers[i].SetupPlayer(stats[i]);
        }
    }

    Vector3 CalculatePositionInRing(int positionID, int numberOfPlayers)
    {
        if (numberOfPlayers == 1)
            return spawnRingCenter.position;

        float angle = (positionID) * Mathf.PI * 2 / numberOfPlayers;
        float x = Mathf.Cos(angle) * spawnRingRadius;
        float z = Mathf.Sin(angle) * spawnRingRadius;
        return spawnRingCenter.position + new Vector3(x, 0, z);
    }

    Quaternion CalculateRotation(int i)
    {
        float y = i % 2 == 0 ? 0 : 180;
        return Quaternion.Euler(new Vector3(0, y, 0));
    }

}
