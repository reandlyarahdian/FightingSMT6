using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text playerNameText;

    public Player Player { get; private set; }

    public bool Ready = false;

    public void SetPlayerInfo(Player _player)
    {
        Player = _player;

        SetPlayerText(_player);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);

        if (targetPlayer != null && targetPlayer == Player)
        {
            if (changedProps.ContainsKey("RandomNumber"))
            {
                SetPlayerText(targetPlayer);
            }
        }
    }

    private void SetPlayerText(Player _player)
    {
        int result = -1;

        if (_player.CustomProperties.ContainsKey("RandomNumber"))
        {
            result = (int)_player.CustomProperties["RandomNumber"];
        }

        playerNameText.text = result.ToString() + ", " + _player.NickName;
    }
}
