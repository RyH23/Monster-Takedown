using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject Player;

    public void Start()
    {
        GameIsPaused = false;
        Resume();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Resume();
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Player.GetComponent<PlayerMovement>().enabled = true;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("LevelOne");
    }
}


