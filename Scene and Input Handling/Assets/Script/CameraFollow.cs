using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow  : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = new Vector2(0f, 0f);
    public float soothSpeed = 0.125f;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
