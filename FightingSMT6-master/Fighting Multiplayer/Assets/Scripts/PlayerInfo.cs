using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo PI;

    public int CharIndex;

    public GameObject[] Characters;

    private void OnEnable()
    {
        PlayerInfo.PI = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            CharIndex = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            CharIndex = 0;
            PlayerPrefs.SetInt("MyCharacter", CharIndex);
        }
    }
}
