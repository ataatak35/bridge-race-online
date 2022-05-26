using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";

    #region MonoBehaviour Callbacks

    private void Awake()
    {
    }

    void Start()
    {
    }

    void Update()
    {
    }

    #endregion

    #region Public Methods

    public void Connect()
    {
        //Connect to the photon cloud
        //Load room list scene

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
            
        }
    }

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        PhotonNetwork.LoadLevel("Lobby Scene");
    }

    #endregion
}