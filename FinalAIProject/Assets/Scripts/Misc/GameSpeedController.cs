using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    public PlayerController playerController;
    public float currentGameSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void StartGame()
    {
        if (ActionQueue.instance.getNumActions() > 0)
        {
            Time.timeScale = currentGameSpeed;
            playerController.playerActive = true;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        Time.timeScale = currentGameSpeed;
    }
}
