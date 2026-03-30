using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Script : MonoBehaviour
{
    public Button controlsButton;
    public GameObject pauseScreen;
    public GameObject controlsScreen;
    public bool pauseActive;
    public bool isPaused;

    public int sceneIndex = -1; // Scene to load
    void Start()
    {
        pauseScreen.SetActive(false);
        controlsScreen.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseActive == true)
        {
            Pause();
        }
    }

    void Pause() 
    {
        if (isPaused == false) 
        {
            pauseScreen.SetActive(true);
            isPaused = true;
            //Time.timeScale = 0f;
        }
        else if (isPaused == true)
        {
            pauseScreen.SetActive(false);
            isPaused = false;
            //Time.timeScale = 1f;
        }

    }
    public void ResumeButton()
    {
        if (isPaused == true)
        {
            pauseScreen.SetActive(false);
            isPaused = false;
        }
    }

    public void ControlsButton()
    {
        pauseScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void QuitButton() 
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void BackButton() 
    {
        pauseScreen.SetActive(true);
        controlsScreen.SetActive(false);
    }
}
