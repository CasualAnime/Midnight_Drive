using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    Transform player;
    [SerializeField]
    private float carSpawnInterval, obstacleSpawnInterval;

    [SerializeField]
    private GameObject deerObstacle;

    [SerializeField]
    private List<GameObject> carList = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player Car").transform;

        InvokeRepeating("SpawnObstacles", 0.0f, obstacleSpawnInterval);
        InvokeRepeating("SpawnOtherCars", 0.0f, carSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacles()
    {
        Instantiate(deerObstacle, new Vector3(player.position.x, player.position.y, player.position.z + 50), Quaternion.identity);
    }

    public void SpawnOtherCars()
    { 
        int rand = Random.Range(0, carList.Count);
        GameObject car = Instantiate(carList[rand], new Vector3(-0.35f, player.position.y, player.position.z + 20), Quaternion.identity);
        car.transform.Rotate(0f, 180f, 0f);

        int randomSpeed = Random.Range(-20, -30);
        car.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, randomSpeed);

    }

    
}
