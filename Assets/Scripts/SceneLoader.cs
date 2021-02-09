using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField] float levelLoadDelay = 2f;
    // [SerializeField] float levelLoadDelay = 15f;  //for final build (music beat drop)
    // Start is called before the first frame update
    void Start() {
        Invoke("LoadNextScene", levelLoadDelay);
    }

    void LoadNextScene() {
        SceneManager.LoadScene(1);
    }
}