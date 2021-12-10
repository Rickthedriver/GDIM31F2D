using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animated_Skin : MonoBehaviour
{


    [SerializeField] private Sprite[] frameArray;
    private int currFrame;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            timer -= 1f;
            currFrame = (currFrame + 1) % frameArray.Length;
            gameObject.GetComponent<SpriteRenderer>().sprite = frameArray[currFrame];
        }

    }
}
