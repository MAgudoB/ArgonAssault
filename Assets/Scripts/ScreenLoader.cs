using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Invoke("LoadGame", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadGame()
    {
        int currentScence = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScence + 1;
        SceneManager.LoadScene(nextScene);
    }
}
