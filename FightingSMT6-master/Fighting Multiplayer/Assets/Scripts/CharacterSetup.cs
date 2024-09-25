using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterSetup : MonoBehaviour
{
    private PhotonView PV;
    public int CharaValue;
    public GameObject Chara;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddChara", RpcTarget.AllBuffered, PlayerInfo.PI.CharIndex);
        }
    }

    [PunRPC]

    public void RPC_AddChara(int CharaVal)
    {
        CharaValue = CharaVal;
        Chara = Instantiate(PlayerInfo.PI.Characters[CharaVal], transform.position, transform.rotation, transform);
    }
}
