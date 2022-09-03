using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;

            if (paused)
            {
                PauseGame();

                pauseMenu.SetActive(true);
            }
            else
            {
                UnpauseGame();
                
                pauseMenu.SetActive(false);
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
