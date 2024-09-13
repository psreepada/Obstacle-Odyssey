using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bumper : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip Death;
    [SerializeField] bool isTransitioning = false;
    [SerializeField] bool isPart = false;
    [SerializeField] bool itHit = false;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isTransitioning = false;
        isPart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex);
        GetComponent<Movement_two>().enabled = true;
        isTransitioning = false;
        isPart = false;
    }
    void redo() {SceneManager.LoadScene(0);}
    void moveOn() {
        int newcurScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(newcurScene + 1);
    }
    void for_finish() {
        if (isPart == false) {
            isPart = true;
            successParticles.Play();
        }
    }
    void stop_sound() {audioSource.Stop();}
    void overall_die_sound() {
        if (isTransitioning == false) {
            isTransitioning = true;
            audioSource.PlayOneShot(Death);
            Invoke("stop_sound", 3);
        }
        else {return;}
    }
    void for_def() {
        Debug.Log("Reach check 2");
        if (isPart == false) {
            Debug.Log("Reach check 3");
            isPart = true;
            crashParticles.Play();
            Debug.Log("Reach check 4");
        }
        else {return;}
    }

    void Destroy() {Destroy(gameObject);}
    void remove() {audioSource.enabled = false;}
    private void OnCollisionEnter(Collision other) {
        audioSource.Stop();
        switch (other.gameObject.tag) {
            case "Finish":
                if (itHit == false) {
                    remove();
                    moveOn();
                    for_finish();
                    break;
                }
                else {return;}
            case "Friendly":
                return;
            default:
                itHit = true;
                gameObject.tag = "defeated";
                overall_die_sound();
                for_def();
                Invoke("remove", 1f);
                Invoke("ReloadLevel", 3f);
                break;
        }
    }
}                                                                 