using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
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

        if (Input.GetKey(KeyCode.T))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.F))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.G))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.H))
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
