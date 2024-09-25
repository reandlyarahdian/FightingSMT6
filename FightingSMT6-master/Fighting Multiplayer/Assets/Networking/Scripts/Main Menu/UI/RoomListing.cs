using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text roomNameText;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo _roomInfo)
    {
        RoomInfo = _roomInfo;

        roomNameText.text = _roomInfo.MaxPlayers + ", " + _roomInfo.Name;
    }

    public void OnClickRoom()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
