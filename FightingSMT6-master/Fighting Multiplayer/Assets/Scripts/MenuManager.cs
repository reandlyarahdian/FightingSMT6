using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MenuManager : MonoBehaviourPunCallbacks
{
    public GameObject menu;
    public GameObject test;
    public CharacterSelect[] selects;

    void Update()
    {
        if (!menu.activeInHierarchy && test.activeInHierarchy)
        {
            if (Input.anyKeyDown)
            {
                test.SetActive(false);
                menu.SetActive(true);
            }
        }
    }
    public void onCharacter1Click(int i)
    {
        GameSetting.Instance.gameObjects[0] = selects[i].characterPrefab;
    }

    public void onCharacter2Click(int i)
    {
        GameSetting.Instance.gameObjects[1] = selects[i].characterPrefab;
    }

    public void onSelect(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void onOnlineMultiplayer() => GameSetting.Instance.mode = GameMode.OnlineMulyiplayer;
    public void onMultiplayer() => GameSetting.Instance.mode = GameMode.LocalMultiplayer;
    public void onSingleplayer() => GameSetting.Instance.mode = GameMode.SinglePlayer;

    public void onExit() => Application.Quit();
}
