using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Removal : MonoBehaviour
{
    //keegan r. Magic sound and audio source for pentagon fade
    [SerializeField]
    private AudioClip m_MagicSound;

    [SerializeField]
    private AudioSource m_AudioSource;
    //keegan r.-----------------------------------------------

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
        //keegan r. Magic sound play b4 fade
        m_AudioSource.PlayOneShot(m_MagicSound);
        //keegan r.-------------------------

        for (float f = 1f; f >=-0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
            
        }
        gameObject.SetActive(false);
    }




    //Keegan R. Collsion of Pentagram Light & Dark------------------------

    /*if darkwizard collides with dark pentagram it disappears
      if lightwiard collides with light pentagram it disappears
      otherwise they cant pass through */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DarkWizard")
        {
            if (gameObject.tag == "Dark")
            {
                StartCoroutine("FadeOut");
            }

        }
        if (collision.gameObject.tag == "LightWizard")
        {
            if (gameObject.tag == "Light")
            {
                StartCoroutine("FadeOut");
            }
        }
    }
    //Keegan R. ------------------------------------------------------------
}
