using UnityEngine;
using UnityEngine.Playables;
using System.Collections;


public class EnterCutscene : MonoBehaviour
{
    public GameObject player;
    public PlayableDirector cutscene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
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
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
