using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomCanvases roomCanvases;

    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);

        roomCanvases.CurrentRoomCanvas.Hide();
    }
}
