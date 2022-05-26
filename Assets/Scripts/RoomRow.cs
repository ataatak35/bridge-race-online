using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RoomRow : MonoBehaviourPunCallbacks
{

    public void OnClickRoomRow()
    {
        PhotonNetwork.JoinRoom(GetComponentInChildren<Text>().text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Test");
    }
}
