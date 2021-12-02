using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Removal : MonoBehaviour
{
    // Start is called before the first frame update
    private float fadeSpeed;
    SpriteRenderer rend;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        //Color c = rend.material.color;
        //c.a = 0f;
        //rend.material.color = c;
    }
    /*
    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);

        }
    }
    */

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >=-0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
            
        }
        gameObject.SetActive(false);
    }




    void OnMouseDown()
    {
        //StartCoroutine("FadeIn");
        StartCoroutine("FadeOut");
        
    }
}
