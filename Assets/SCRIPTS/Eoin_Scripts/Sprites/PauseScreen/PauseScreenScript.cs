using UnityEngine;
using UnityEngine.UI;

public class PauseScreenScript : MonoBehaviour
{
    public GameObject pauseScreen;
    public bool isPaused;
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        }
        else 
        {
            pauseScreen.SetActive(false);
            isPaused = false;
        }
       
    }
}
