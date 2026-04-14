using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.Image;

public class IntroCutscene : MonoBehaviour
{
    public PlayableDirector cutscene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cutscene.Play();
        StartCoroutine(waitForCutsceneFinish());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadLevel();
        }
    }
    private IEnumerator waitForCutsceneFinish()
    {
        // Wait until the timeline finishes playing
        while (cutscene.state == PlayState.Playing)
        {
            yield return null;  // Keep checking the timeline state
        }
        LoadLevel();
    }
    void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
