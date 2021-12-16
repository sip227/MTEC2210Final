using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            PlayerScore.playerScore = 0;
            GameOver.isPlayerDead = false;
            Time.timeScale = 1;

            SceneManager.LoadScene("MainScene");
        }
    }
}
