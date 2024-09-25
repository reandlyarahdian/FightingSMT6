using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;

    [SerializeField]
    private PlayerListing playerListing;

    [SerializeField]
    private Text readyUpText;

    private List<PlayerListing> listings = new List<PlayerListing>();

    private RoomCanvases roomCanvases;

    private bool ready = false;

    public override void OnEnable()
    {
        base.OnEnable();

        SetReadyUp(false);

        GetCurrentRoomPlayer();
    }

    public override void OnDisable()
    {
        base.OnDisable();

        for (int i = 0; i < listings.Count; i++)
        {
            Destroy(listings[i].gameObject);
        }

        listings.Clear();
    }

    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }

    private void SetReadyUp(bool state)
    {
        ready = state;
        if (ready)
        {
            readyUpText.text = "R";
        }
        else
        {
            readyUpText.text = "N";
        }
        
    }

    private void GetCurrentRoomPlayer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
        {
            return;
        }

        foreach (KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    private void AddPlayerListing(Player player)
    {
        int _index = listings.FindIndex(x => x.Player == player);

        if (_index != -1)
        {
            listings[_index].SetPlayerInfo(player);
        }

        else
        {
            PlayerListing _listing = Instantiate(playerListing, content);

            if (_listing != null)
            {
                _listing.SetPlayerInfo(player);

                listings.Add(_listing);
            }
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        roomCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClickLeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int _index = listings.FindIndex(x => x.Player == otherPlayer);

        if (_index != -1)
        {
            Destroy(listings[_index].gameObject);

            listings.RemoveAt(_index);
        }
    }

    public void OnClickStartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < listings.Count; i++)
            {
                if (listings[i].Player != PhotonNetwork.LocalPlayer)
                {
                    if (!listings[i].Ready)
                    {
                        return;
                    }
                }
            }

            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;

            PhotonNetwork.LoadLevel(2);
        }
    }

    public void OnClickReadyUp()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            SetReadyUp(!ready);

            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, ready);
        }
    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool state)
    {
        int _index = listings.FindIndex(x => x.Player == player);

        if (_index != -1)
        {
            listings[_index].Ready = state;
        }
    }
}
