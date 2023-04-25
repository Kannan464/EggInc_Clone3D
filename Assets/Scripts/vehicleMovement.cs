using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class vehicleMovement : MonoBehaviour
{
    public GameObject targetPos;
    public float speed;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        targetPos = GameObject.Find("TargetPosition");
        this.transform.SetParent(GameObject.Find("TargetPos").GetComponent<Transform>());
    }

    // vehicle move to the vehicle house.
    private void FixedUpdate()
    {

        transform.position = Vector3.SmoothDamp(transform.position, targetPos.transform.position, ref velocity, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos.transform.position) <= 2.5f)
        {
            StartCoroutine(changeTargetPos());
        }            
    }

    // change vehicle target position 
    IEnumerator changeTargetPos()
    {
        yield return new WaitForSeconds(0.5f);
        targetPos = GameObject.Find("TargetPosition1");

        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}