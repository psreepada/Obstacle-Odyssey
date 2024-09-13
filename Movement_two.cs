using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_two : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float thrust_tuner = 2000;
    [SerializeField] float rotate_tuner = 30f;
    [SerializeField] AudioClip Rocket_thrust;
    [SerializeField] ParticleSystem Main_jet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Steps_key();
        ProccesRotation();
    }
    void Steps_key() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * thrust_tuner * Time.deltaTime);
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(Rocket_thrust);
            }
            if (!Main_jet.isPlaying) {Main_jet.Play();}
        }
        else {
            audioSource.Stop();
            Main_jet.Stop();
        }
    }

    void ProccesRotation() {
        if (Input.GetKey(KeyCode.A)) {
            Rotation(rotate_tuner);
        }
        else if (Input.GetKey(KeyCode.D)) {
            Rotation(-rotate_tuner);
        }
    }
    void Rotation(float Rotater) {  
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * Rotater);
        rb.freezeRotation = false;
    }
    private void OnCollisionEnter(Collision other) {
        audioSource.Stop();
        switch (other.gameObject.tag) {
            
            case "Friendly":
                return;
            case "Finish":
                return;
            default:
                gameObject.tag = "defeated";
                GetComponent<Movement_two>().enabled = false;
                Main_jet.Stop();
                break;
        }
    }
}