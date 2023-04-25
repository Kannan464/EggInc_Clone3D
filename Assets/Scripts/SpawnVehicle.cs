using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicle : MonoBehaviour
{
    public GameObject[] vehiclePrefab;
    public Transform targetPos;
    int vehicleSpawnTime;
 
    void Start()
    {
        StartCoroutine(vehicleSpawn());     
    }

    //for Vehicle Spawn Different Position with Different Timing.
    public IEnumerator vehicleSpawn()
    {
        vehicleSpawnTime = Random.Range(10, 25);
        Debug.Log($"<color=cyan> Vehicle Spawn : {vehicleSpawnTime}</color>");
        yield return new WaitForSeconds(vehicleSpawnTime);
        int vehicle = Random.Range(0, vehiclePrefab.Length);
        Instantiate(vehiclePrefab[vehicle], targetPos.transform.position, vehiclePrefab[vehicle].transform.rotation);
        StartCoroutine(vehicleSpawn());
    }
}