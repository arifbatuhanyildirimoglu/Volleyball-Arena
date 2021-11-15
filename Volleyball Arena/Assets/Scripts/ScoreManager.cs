using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Text masterScoreText;
    public Text clientScoreText;

    private int masterScore;
    private int clientScore;
    
    // Start is called before the first frame update
    void Start()
    {

        masterScore = Convert.ToInt32(masterScoreText.text);
        clientScore = Convert.ToInt32(clientScoreText.text);
    }

    public void AddScoreToMaster()
    {

        masterScore++;

        PhotonNetwork.LoadLevel("GameScene");
        masterScoreText.text = masterScore.ToString();
        
    }

    public void AddScoreToClient()
    {
        clientScore++;
        
        PhotonNetwork.LoadLevel("GameScene");
        clientScoreText.text = clientScore.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
