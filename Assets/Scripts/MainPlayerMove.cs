using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    internal float speed=100;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, 10) * speed * Time.deltaTime;
        Debug.Log(rb.velocity.ToString());
        Debug.Log(speed);
    }
}
