using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawn : MonoBehaviour
{
    public static DroneSpawn instance;
    public GameObject[] dronePrefab;
    int droneSpawnTime;
    private void Start()
    {
        instance = this;
        StartCoroutine(droneSpawn());
    }
    void Update()
    {

    }
    //for Drone Spawn Different Position with Different Timing.
    public IEnumerator droneSpawn()
    {
        droneSpawnTime = Random.Range(1, 20);
        Debug.Log($"<color=green> Drone Spawn :  {droneSpawnTime}</color>");
        yield return new WaitForSeconds(droneSpawnTime);
        Vector3 randomDroneSpawn = new Vector3(Random.Range(-200, 200), -50, Random.Range(-100, 210));
        int drone=Random.Range(0,dronePrefab.Length);
        Instantiate(dronePrefab[drone], randomDroneSpawn, Quaternion.identity);
        StartCoroutine(droneSpawn());
    } 
}