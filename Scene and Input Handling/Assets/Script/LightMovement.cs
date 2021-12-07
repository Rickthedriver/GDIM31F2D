using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    const float SPEED = 20f;

    [SerializeField] private Sprite[] frameArray;

    private int currentFrame;//which frame is cureeent

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = frameArray[1];
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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY = +1f;
            gameObject.GetComponent<SpriteRenderer>().sprite = frameArray[0];
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            moveX = -1f;
            gameObject.GetComponent<SpriteRenderer>().sprite = frameArray[3];
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
            gameObject.GetComponent<SpriteRenderer>().sprite = frameArray[1];

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = +1f;
            gameObject.GetComponent<SpriteRenderer>().sprite = frameArray[2];

        }
        moveDir = new Vector3(moveX, moveY).normalized;
        rigidbody2D.velocity = moveDir * SPEED;
    }
    private void FixedUpdata()
    {
        //rigidbody2D.velocity = moveDir * SPEED;
    }
}
