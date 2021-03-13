using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //ok as long as this is the only script that loads scenes.

public class CollisionHandler : MonoBehaviour {
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on Player")][SerializeField] ParticleSystem deathFX;

    void OnTriggerEnter(Collider other) {
        StartDeathSequence();
    }

    private void StartDeathSequence() {
        deathFX.Play();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel() { // string referenced
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}