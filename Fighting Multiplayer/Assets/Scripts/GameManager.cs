using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : Singleton<GameManager>
{
    public GameObject inScenePlayer;
    private PlayerController Controller;

    void Start()
    {
        Controller = inScenePlayer.GetComponent<PlayerController>();
        Activate();
    }

    void Activate()
    {
        Controller.SetupPlayer();
    }
}
