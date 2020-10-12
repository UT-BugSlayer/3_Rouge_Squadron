using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    [SerializeField] float levelLoadDelay = 2f;
    // [SerializeField] float levelLoadDelay = 15f;

    private void Awake() {
        DontDestroyOnLoad(this);  
    }

    // Start is called before the first frame update
    void Start() {
        Invoke("LoadNextScene", levelLoadDelay);
    }

    void LoadNextScene() {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update() {

    }
}