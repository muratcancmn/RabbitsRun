using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 1;
    float moveHoriz;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MoveRabbit();
    }
    private void MoveRabbit()
    {
        //PLAYER MOVEMENT
        moveHoriz = Input.GetAxis("Horizontal") * force * Time.deltaTime;
        rb.velocity = new Vector3(moveHoriz, 0, 0);
    }
    private void MoveWithMouse()
    {
        moveHoriz= Input.GetAxis("Mouse X")*force * Time.deltaTime;
        Debug.Log(moveHoriz);
        rb.velocity= new Vector3(moveHoriz, 0, 0);
    }
}
