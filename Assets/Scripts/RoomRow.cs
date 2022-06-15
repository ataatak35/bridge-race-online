using Photon.Pun;
using UnityEngine.UI;

public class RoomRow : MonoBehaviourPunCallbacks
{

    public void OnClickRoomRow()
    {
        PhotonNetwork.JoinRoom(GetComponentInChildren<Text>().text);
    }
}
