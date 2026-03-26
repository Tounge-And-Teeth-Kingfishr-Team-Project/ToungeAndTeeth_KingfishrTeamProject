using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Script : MonoBehaviour
{
    public Button controlsButton;
    public GameObject pauseScreen;
    public GameObject controlsScreen;
    public bool pauseOn;

    public int sceneIndex = -1; // Scene to load
    void Start()
    {
        pauseScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if ()
        //{
        //    pauseOn == true
        //}
    }

    public void OptionsButton()
    {
        if (pauseOn == true)
        {
            pauseScreen.SetActive(false);
            controlsScreen.SetActive(true);
        }

    }

    public void QuitButton() 
    {
        SceneManager.LoadScene(sceneIndex);
        
    }
}
