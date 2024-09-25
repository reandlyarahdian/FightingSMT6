using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings", fileName = "New Game Settings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string gameVersion = "0.0.0";

    public string GameVersion { get => gameVersion; }

    [SerializeField]
    private string nickName = "Masters";

    public string NickName
    {
        get
        {
            int value = Random.Range(0, 9999);

            return nickName + value.ToString();
        }
    }
}
