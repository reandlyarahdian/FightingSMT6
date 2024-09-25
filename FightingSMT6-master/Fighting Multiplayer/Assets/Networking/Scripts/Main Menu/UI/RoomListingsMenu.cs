using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;

    [SerializeField]
    private RoomListing roomListing;

    private List<RoomListing> listings = new List<RoomListing>();

    private RoomCanvases roomCanvases;

    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }

    public override void OnJoinedRoom()
    {
        roomCanvases.CurrentRoomCanvas.Show();

        content.DestroyChildren();

        listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        foreach (RoomInfo info in _roomList)
        {
            if (info.RemovedFromList)
            {
                int _index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);

                if (_index != -1)
                {
                    Destroy(listings[_index].gameObject);

                    listings.RemoveAt(_index);
                }
            }

            else
            {
                int _index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);


                if (_index == -1)
                {
                    RoomListing _listing = Instantiate(roomListing, content);

                    if (_listing != null)
                    {
                        _listing.SetRoomInfo(info);

                        listings.Add(_listing);
                    }
                }
                else
                {
                    //DO edit the room info
                    //Listing[index].dowhatever
                }

            }
        }
    }
}
