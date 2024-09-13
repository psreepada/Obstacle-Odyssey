using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MianMenuManager : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
    public void Quit() {
        Application.Quit();
    }
}