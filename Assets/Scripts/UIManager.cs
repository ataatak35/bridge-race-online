using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviourPunCallbacks
{

    #region Private Variables

    [SerializeField] private InputField roomNameField;
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject roomRowPrefab;
    private Dictionary<string, RoomInfo> _roomList = new Dictionary<string, RoomInfo>();

    #endregion

    private void Start()
    {
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        _roomList.Clear();
        foreach(RoomInfo roomInfo in roomList)
        {
            
            _roomList[roomInfo.Name] = roomInfo;
            
        }
        RoomReceived();

    }

    private void RoomReceived()
    {

        //Destroy(content.GetComponentInChildren<GameObject>());

        for (int i = 0; i < _roomList.Count; i++)
        {

            var item = _roomList.ElementAt(i);
            string roomName = item.Key;
            
            GameObject newRow = Instantiate(roomRowPrefab, content.transform);
            if (i == 0)
            {
                
            }
            else
            {
                //contentin childlarını gezecek son childinin altına koyacak.
                //newRow.transform.position =     
                GameObject[] children = content.transform.GetComponentsInChildren<GameObject>();
                GameObject lastChild = children[children.Length - 1];

                newRow.transform.position =
                    lastChild.transform.position + new Vector3(0, lastChild.transform.localScale.y, 0);
            }
            Text text = newRow.GetComponentInChildren<Text>();
            text.text = roomName;
            
        }
        
        /*
        foreach (string roomName in _roomList.Keys)
        {
            
            //TODO: listedeki her roomun ismini alıp prefabteki texte atayıp contente child olarak ekleyecek.

        }
        */
        
    }

    public void OnClickCreateRoomButton()
    {
        PhotonNetwork.CreateRoom(roomNameField.text, new RoomOptions(), TypedLobby.Default);
        //GameObject newRow = Instantiate(roomRowPrefab,content.transform);
    }

    

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Test");
    }

    //TODO: ROOM LİSTESİNİ AL SCROLLVIEW İÇİNE AT
    
}
