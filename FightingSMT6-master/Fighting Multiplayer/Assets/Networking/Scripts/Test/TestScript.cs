using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviourPun/*, IPunObservable*/
{
    [SerializeField]
    private Material playerMaterial;

    private const byte COLOR_CHANGE_EVENT = 0;

    private void Update()
    {
        if (base.photonView.IsMine && Input.GetKeyDown(KeyCode.Space))
        {
            base.photonView.RPC("RPC_ChangeColor", RpcTarget.AllBuffered, null);
        }       

    }

    //private void OnEnable()
    //{
    //    PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    //}
    //private void OnDisable()
    //{
    //    PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    //}

    //private void NetworkingClient_EventReceived(EventData obj)
    //{
    //    if (obj.Code == COLOR_CHANGE_EVENT)
    //    {
    //        object[] datas = (object[])obj.CustomData;

    //        float r = (float)datas[0];
    //        float g = (float)datas[1];
    //        float b = (float)datas[2];

    //        playerMaterial.color = new Color(r, g, b);
    //    }
    //}

    [PunRPC]
    private void RPC_ChangeColor()
    {
        playerMaterial = gameObject.GetComponent<Renderer>().material;

        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        playerMaterial.color = new Color(r, g, b);

        //object[] datas = new object[] { r, g, b };

        //PhotonNetwork.RaiseEvent(COLOR_CHANGE_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }

}
