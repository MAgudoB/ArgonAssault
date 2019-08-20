using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX Prefab on Player")] [SerializeField] GameObject deathFX;
    [SerializeField] int deathScore = -30;

    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start () {
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        PlayerDeathSequenceStarts();
    }

    private void PlayerDeathSequenceStarts() {
        scoreBoard.ScoreHit(deathScore);
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);        
    }

    private void ReloadLevel()  {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}