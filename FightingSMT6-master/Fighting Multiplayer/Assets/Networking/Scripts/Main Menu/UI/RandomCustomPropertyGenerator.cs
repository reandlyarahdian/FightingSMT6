using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    [SerializeField]
    private Text randomNumberText;

    private ExitGames.Client.Photon.Hashtable myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void SetCustomNumber()
    {
        System.Random rnd = new System.Random();

        int result = rnd.Next(0, 99);

        randomNumberText.text = result.ToString();

        myCustomProperties["RandomNumber"] = result;

        PhotonNetwork.SetPlayerCustomProperties(myCustomProperties);

        //PhotonNetwork.LocalPlayer.CustomProperties = myCustomProperties;
    }

    public void OnClickRandomGeneratorButton()
    {
        SetCustomNumber();
    }
}
