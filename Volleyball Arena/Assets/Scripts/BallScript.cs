using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
        
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.name.Equals("Ground"))
        {
            if (transform.position.x < 0)
            {
                //TODO: CLIENT SCORE ALIR
                ScoreManager.Instance.AddScoreToClient();
            }
            else
            {
                //TODO: MASTER CLIENT SCORE ALIR
                ScoreManager.Instance.AddScoreToMaster();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
