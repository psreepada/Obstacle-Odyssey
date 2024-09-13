using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UOM : MonoBehaviour
{
    float FINAL_time;
    Vector3 startingPosition;
    bool redo = false;
    [SerializeField] ParticleSystem Fire_heat;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        pre_rec();
    }

    // Update is called once per frame
    void pre_rec() {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        if (!Fire_heat.isPlaying) {Fire_heat.Play();}
    }
    void back_pre_rec() {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<BoxCollider>().enabled = false;
        Fire_heat.Stop();
    }
    void Update()
    {
        if (redo == true) {
            if (Time.time > FINAL_time) {
                pre_rec();
            }
        }
    }
    private void OnCollisionEnter(Collision other) {
        FINAL_time = Time.time + 3;
        back_pre_rec();
        transform.position = startingPosition;
        redo = true;
    }
}