using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int score = 10;
    [SerializeField] int hitPoints = 30;

    ScoreBoard scoreBoard;

    // Use this for initialization
    void Start ()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)  {
        hitPoints--;
        if (hitPoints < 1)
        {
            KillMethod();
        }
    }

    private void KillMethod()
    {
        scoreBoard.ScoreHit(score);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
