using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void OnCharacterPick(int index)
    {
        if(PlayerInfo.PI != null)
        {
            PlayerInfo.PI.CharIndex = index;
            PlayerPrefs.SetInt("MyCharacter", index);
        }
    }
}
