using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Text masterScoreText;
    public Text clientScoreText;

    public Player[] players;
    private Player masterPlayer;
    private Player clientPlayer;

    private int masterScore;
    private int clientScore;
    
    // Start is called before the first frame update
    void Start()
    {

        players = PhotonNetwork.PlayerList;

        foreach (Player player in players)
        {
            if (player.Equals(PhotonNetwork.MasterClient))
                masterPlayer = player;
            else
                clientPlayer = player;
        }

        

    }

    public void AddScoreToMaster()
    {
        
        masterPlayer.AddScore(1);
        
        GameManager.Instance.SpawnCharacters();
        
        
    }

    public void AddScoreToClient()
    {
       
        clientPlayer.AddScore(1);
        
        GameManager.Instance.SpawnCharacters();
        
        

    }
    // Update is called once per frame
    void Update()
    {

        masterScore = masterPlayer.GetScore();
        clientScore = clientPlayer.GetScore();
        
        masterScoreText.text = masterScore.ToString();
        clientScoreText.text = clientScore.ToString();
    }
}
