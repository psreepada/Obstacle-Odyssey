using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtohome : MonoBehaviour
{
    public void backHome() {
        Debug.Log("It works");
        SceneManager.LoadScene(0);
    }
}