using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    public GameObject playerPrefab;
    public GameObject ballPrefab;
    public List<GameObject> spawnPositions;
    public GameObject ballSpawnPosition;
    private GameObject ball;


    private GameObject masterGameObject;
    private GameObject clientGameObject;
    
    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            masterGameObject = PhotonNetwork.Instantiate(playerPrefab.name,
                new Vector3(spawnPositions[0].transform.position.x, -3f,
                    0), Quaternion.identity);
        }
        else
        {
            clientGameObject = PhotonNetwork.Instantiate(playerPrefab.name,
                new Vector3(spawnPositions[1].transform.position.x, -3f,
                    0), Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //topu tam ortadan yukarıdan ya sağa atacak ya da sola
        if (PhotonNetwork.IsMasterClient)
        {
            
            ball = PhotonNetwork.Instantiate(ballPrefab.name, ballSpawnPosition.transform.position, Quaternion.identity);
        
            int randomNumber = Random.Range(0, 2);
        
            if (randomNumber == 0)
                ball.GetComponent<Rigidbody>().AddForce(Vector3.left * 2f, ForceMode.Impulse);
            else
                ball.GetComponent<Rigidbody>().AddForce(Vector3.right * 2f, ForceMode.Impulse);  
            
        }
        
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnCharacters()
    {

        if (PhotonNetwork.IsMasterClient)
        {

            masterGameObject.transform.position = new Vector3(spawnPositions[0].transform.position.x, -3f,
                0);

            
            ball.transform.position = ballSpawnPosition.transform.position;
            
            int randomNumber = Random.Range(0, 2);
        
            if (randomNumber == 0)
                ball.GetComponent<Rigidbody>().AddForce(Vector3.left * 2f, ForceMode.Impulse);
            else
                ball.GetComponent<Rigidbody>().AddForce(Vector3.right * 2f, ForceMode.Impulse);

        }
        else
        {
            clientGameObject.transform.position = new Vector3(spawnPositions[1].transform.position.x, -3f,
                0);
        }

    }
}