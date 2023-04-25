using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

public class ChickenMovement : MonoBehaviour
{
    //public Transform[] path;
    //public float speed;
    //private int current;
    //public float damping = 6.0f;
    //void Update()
    //{
    //    pathRun();
    //}

    //public void pathRun()
    //{
    //    if (Vector3.Distance(transform.position, path[current].transform.position) > 0.1f)
    //    {
    //        Vector3 pos = Vector3.MoveTowards(transform.position, path[current].position, speed);
    //        var rotation = Quaternion.LookRotation(path[current].position + transform.position);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, damping * Time.deltaTime);
    //        GetComponent<Rigidbody>().MovePosition(pos);
    //    }
    //    else
    //        current = (current + 1) % path.Length;
    //}
 
    public NavMeshAgent agent;
   // public GameObject[] path;
    [SerializeField]
    private Transform[] pathpoints;
    [SerializeField]
    //  private Transform[] pathpoints2;
    public float mindistance = 1;
    public int index = 0;
    public List<Transform> paths = new List<Transform>();

    private void Awake()
    {
        Transform path1 = GameObject.Find("Path1").transform;
      //  Transform path2 = GameObject.Find("Path2").transform;

        paths.Add(path1);
     //   paths.Add(path2);

     //   Debug.Log(paths.Count + "!!!!!!!!!!!!!!!!!!!!!");

    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = UnityEngine.Random.Range(8, 12);
        pathpoints = new Transform[ paths[UnityEngine.Random.Range(0, paths.Count)].transform.childCount];
        for (int i = 0; i < pathpoints.Length; i++)
        {
           pathpoints[i] = paths[0].transform.GetChild(i);
        }
    }   

    // Set Parent to Gameobject
    public void OnEnable()
    {
        this.transform.SetParent(GameObject.Find("ChickenSpawnpoint").GetComponent<Transform>(), false);
    }
    void Update()
    {
        findingpath();
        // Geneate();
    }

    // player find path using navmesh
    public void findingpath()
    {
        try
        { 
            if (Vector3.Distance(transform.position, pathpoints[index].position) < mindistance)
            {
                if (index >= 0 && index < pathpoints.Length)
                {
                    index += 1;
                }
                else
                {
                    index = 0;
                }
            }
            agent.SetDestination(pathpoints[index].position);
        }
        catch
        {
            Debug.Log("");
        }
    }

    // collide door and increase chicken count 
    public void OnCollisionEnter(Collision collision)
    {                                                                                   
        if (collision.gameObject.CompareTag("Door"))
        {
            playerCounts();
              index = 0;
            if (Vector3.Distance(transform.position, pathpoints[index].position) < mindistance)
            {
                if (index >= 0 && index < pathpoints.Length)
                {
                    index += 1;
                    //debug.log("#####" + index);
                }
                else
                {
                    index = 0;
                }

            }
            this.gameObject.SetActive(false);
            return;

        }
        findingpath();

    }
    // Chicken Count , Seconds increase and amount increase
    public void playerCounts()
    {
        GameManager.instance.chickenCount++;
        GameManager.instance.amount += 3f;
        GameManager.instance.secIncrease();
    }
}
    //public void Geneate()
    //{
    //    if (Vector3.Distance(pathpoints2[pathpoints2.Length - 1].position, transform.position) < 1f)
    //    {
    //        Destroy(gameObject);
    //    }
    //    if (Vector3.Distance(transform.position, pathpoints2[index].position) < 1f)
    //    {
    //        if (index >= 0 && index < pathpoints2.Length)
    //        {
    //            index += 1;
    //            //debug.log("#####" + index);
    //        }
    //        else
    //        {
    //            index = 0;
    //        }
    //    }
    //    try
    //    {
    //        agent.SetDestination(pathpoints2[index].position);
    //    }
    //    catch
    //    {
    //        Debug.Log("");
    //    }
    //}

    //public Transform player;
    //public PathType pathSystem = PathType.CatmullRom;

    //public Vector3[] pathVal;

    //public void Start()
    //{
    //    player.transform.DOPath(pathVal, 6, pathSystem);
    //}
