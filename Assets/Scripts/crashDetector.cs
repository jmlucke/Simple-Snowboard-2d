using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class crashDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float loadDelay=0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
     
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
             
            if(FindObjectOfType<playerControls>().audioPlayer)
            {
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
            }
            FindObjectOfType<playerControls>().DisableControls();
            Invoke("ReloadScene", loadDelay);
        }
    }

   void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

