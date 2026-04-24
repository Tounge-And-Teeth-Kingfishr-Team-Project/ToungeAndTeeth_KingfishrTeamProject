using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinalCutsceneEnding : MonoBehaviour
{
    public PlayableDirector cutscene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cutscene.Play();
        StartCoroutine(waitForCutsceneFinish());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SceneManager.LoadScene(0);
    }
}
