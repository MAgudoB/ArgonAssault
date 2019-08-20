using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scoreHit = 12;

    int score;
    Text scoreText;

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ScoreHit()  {
        score += scoreHit;
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int enemyScore) {
        score += enemyScore;
        scoreText.text = score.ToString();
    }
}
