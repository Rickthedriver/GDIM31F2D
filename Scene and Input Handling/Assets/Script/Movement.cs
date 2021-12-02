using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    const float SPEED = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }
        moveDir = new Vector3(moveX, moveY).normalized;
        rigidbody2D.velocity = moveDir * SPEED;
    }
    private void FixedUpdata()
    {
        //rigidbody2D.velocity = moveDir * SPEED;
    }
}
