using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // TODO: work out why sometimes slow on first play of scene

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float controlSpeed = 4f; // 4 meters/sec
    [Tooltip("In m")][SerializeField] float xRange = 6f; // 6 meters
    [Tooltip("In m")][SerializeField] float yRange = 3f; // 3 meters
    [SerializeField] GameObject[] lasers;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-Throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

    // Update is called once per frame
    void Update() {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessTranslation() {
        // Process Horizonal Translation
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        // Process Vertical Translation
        yThrow = Input.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        // Set position of Rocket Ship
        transform.localPosition =
            new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

    }

    private void ProcessRotation() {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring() {
        if (Input.GetButton("Fire1")) {
            SetLasersActive(true);
        }
        else {
            SetLasersActive(false);
        }
    }
    
    void SetLasersActive(bool isActive) {
        // for each of the lasers that we have, turn them on
        foreach (GameObject laser in lasers) {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
  
}