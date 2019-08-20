using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SpaceshipController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms")][SerializeField] float controlSpeed = 6f;
    [Tooltip("In m")] [SerializeField] float xRange = 10f;
    [Tooltip("In m")] [SerializeField] float yRange = 5.5f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position Based")]
    [SerializeField] float posPitchFactor = -5f;
    [SerializeField] float posYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float horizontalThrow, verticalThrow = 0;

    Boolean isDead = false;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isDead)
        {
            HorizontalMovement();
            VerticalMovement();
            Rotation();
            Firing();
        }
    }

    private void Firing()   {
        if (CrossPlatformInputManager.GetButton("Fire"))    {
            ActivateParticles(true);

        }
        else {
            ActivateParticles(false);
        }
    }

    private void ActivateParticles(Boolean activated)    {
        foreach (GameObject gun in guns)    {
            ParticleSystem.EmissionModule emissions = gun.GetComponent<ParticleSystem>().emission;
            emissions.enabled = activated;
        }
    }

    private void OnPlayerDeath()
    {
        isDead = true;
    }

    private void Rotation() {
        float pitch = (transform.localPosition.y * posPitchFactor) + (verticalThrow * controlPitchFactor);
        float yaw = (transform.localPosition.x * posYawFactor);
        float roll = horizontalThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void VerticalMovement() {
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffSet = verticalThrow * controlSpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffSet;
        float newYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, newYPos, transform.localPosition.z);
    }

    private void HorizontalMovement()   {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffSet = horizontalThrow * controlSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffSet;
        float newXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
    }


}
