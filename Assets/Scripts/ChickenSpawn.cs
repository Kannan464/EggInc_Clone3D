using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawn : MonoBehaviour
{
    public int Count;
    int countSpawn;
    public int increaseChickenSpawnCount = 1;
    public static ChickenSpawn instance;
    public List<GameObject> pools = new List<GameObject>();
    public GameObject Chicken;
    [SerializeField]
    private Transform ChickSpawnPos;
    public bool isClick = false;
    float timeSpawn;
    public bool isSpawn = true;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        isSpawn = true;
        CreateChicken();
    }
    private void Update()
    {
        objPool();
    }

    // Player Spawn When button Single click or long press
    private void objPool()
    {
        if (GameManager.instance.chickenCapacitySlider.value > 0)
        {
            if (GameManager.instance.chickenCount <= GameManager.instance.henHouseCapacity)
            {
                isClickSpawn();
            }
            else
            {
                isClick = false;
            }
        }
        if (isClick==false)
        {
            GameManager.instance.chickenCapacitySlider.value += 0.03f;
        }
    }
    // for Long Press Button Spawn
    public void isClickSpawn()
    {
        if (isClick)
        {
            GameObject chick = ChickenObjPool();
            if (chick != null && isSpawn)
            {
              //  GameManager.instance.amount += 2;
                GameManager.instance.chickenCapacitySlider.value--;
                timeSpawn = 0;
                // StartCoroutine(delaySpawn());
                //  Debug.Log("Chicken Created...");
                chick.transform.position = ChickSpawnPos.position;
                chick.SetActive(true);
                countSpawn++;
                if (countSpawn == increaseChickenSpawnCount)
                {
                    isSpawn = false;

                    countSpawn = 0;
                }
            }
            else if (!isSpawn)
            {
                timeSpawn += Time.deltaTime;

                if (timeSpawn >= 0.2f)
                {

                    isSpawn = true;
                }
            }
        }
    }

    //long press pointerDown
    public void pointerDown()
    {
        isClick = true;
        objPool();
    }
    //long press pointerUp
    public void pointerUp()
    {
        isClick = false;
    }

    // players Active in Hierarchy
    public GameObject ChickenObjPool()
    {
        for (int i = 0; i < Count; i++)
        {
            if (!pools[i].activeInHierarchy)
            {
                return pools[i];
            }
        }
        return null;
    }

    //player instantiate and add to List 
    public void CreateChicken()
    {
        for (int i = 0; i < Count; i++)
        {
            GameObject chickSpawn = Instantiate(Chicken);
            chickSpawn.transform.position = Vector3.zero;
            chickSpawn.SetActive(false);
            pools.Add(chickSpawn);
        }
    }

}