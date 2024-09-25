using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionOBJ : MonoBehaviour
{
    public Button player1, player2;

    public GameObject char1, char2;

    public void OpenChar1()
    {
        char1.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(player1.gameObject);
    }
    public void OpenChar2()
    {
        char2.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(player2.gameObject);
    }
}
