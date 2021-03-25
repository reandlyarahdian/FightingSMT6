using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName ="SO/Character")]
public class CharacterSelect : ScriptableObject
{
    public string characterName;
    public GameObject characterPrefab;
}
