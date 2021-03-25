using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
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

    public void onCharacterClick(int i)
    {
        if (GameSetting.Instance.gameObjects[0] == null) GameSetting.Instance.gameObjects[0] = selects[i].characterPrefab; 
        else GameSetting.Instance.gameObjects[1] = selects[i].characterPrefab;
    }

    public void onSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void onMultiplayer() => GameSetting.Instance.mode = GameMode.LocalMultiplayer;

    public void onOnlineMultiplayer() => GameSetting.Instance.mode = GameMode.OnlineMultiplayer;

    public void onSingleplayer() => GameSetting.Instance.mode = GameMode.SinglePlayer;

    public void onExit() => Application.Quit();
}
