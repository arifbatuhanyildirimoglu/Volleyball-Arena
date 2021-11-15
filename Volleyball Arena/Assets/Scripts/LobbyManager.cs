using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if (!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();

    }

    public void OnCreateRoomButtonClicked()
    {
        PhotonNetwork.CreateRoom("Room 1");
    }

    public void OnJoinRoomButtonClicked()
    {
        PhotonNetwork.JoinRoom("Room 1");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {

            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                PhotonNetwork.LoadLevel("GameScene");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}