using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DroneManager : MonoBehaviour
{
    //  public GameObject target;

    public float speed = 15f;
    Vector3 targetGo;
    int addAmount,addGoldEgg;
    public GameObject Textprefab;
    public TMP_Text droneAmountTxt;

    // Start is called before the first frame update
   public void Start()
    {
        this.transform.SetParent(GameObject.Find("SpawnDrone").GetComponent<Transform>());
        droneAmountTxt=(TextMeshPro)FindObjectOfType(typeof(TextMeshPro));
        Textprefab = GameObject.Find("DroneAmount");
        targetGo = new Vector3(-transform.position.x, transform.position.y, -transform.position.z);
        StartCoroutine(ondes());
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void FixedUpdate()
    {
            transform.position = Vector3.MoveTowards(transform.position, targetGo, speed * Time.deltaTime); // drone move to is Negative Position...
     }
    // this method is called by Event Trigger.
    public void OnDroneDestroy()
    {
        Destroy(gameObject);
        addAmount = Random.Range(300, 1500);

        GameManager.instance.amount += addAmount;
        droneAmountTxt.text = addAmount.ToString();

        GameObject Clone = Instantiate(Textprefab, transform.position, Quaternion.identity);
        Destroy(Clone, 2f);
    }

    // this method is called by Event Trigger in GoldDrone .
    public void goldDrone()
    {
        Destroy(gameObject);
        addGoldEgg = Random.Range(1, 9);
        GameManager.instance.goldeggCount += addGoldEgg;
        droneAmountTxt.text = addGoldEgg.ToString();

        GameObject Clone = Instantiate(Textprefab, transform.position, Quaternion.identity);
        Destroy(Clone, 2f);
    }

    // for Drone After 20 sec it will destroy...(Automatically)
    IEnumerator ondes()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);     
    }
}