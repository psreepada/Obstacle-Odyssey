using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_sound : MonoBehaviour
{
    AudioSource audioSource;
    bool isTransitioning = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void stop_sound() {
        audioSource.Stop();
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            if (isTransitioning == false) {
                isTransitioning = true;
                audioSource.Play();
                Invoke("stop_sound", 3f);
            }
        }
    }
}