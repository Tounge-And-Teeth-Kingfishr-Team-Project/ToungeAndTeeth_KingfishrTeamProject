using UnityEngine;
using UnityEngine.SceneManagement;

public class MK_PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject controlsUI;
    public PlayerMovement player;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        controlsUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameIsPaused = false;
    }
    public void Controls()
    {
        pauseMenuUI.SetActive(false);
        controlsUI.SetActive(true);
    }
    public void BackToPauseUI()
    {
        pauseMenuUI.SetActive(true);
        controlsUI.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("");
    }
    public void QuitGame()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
