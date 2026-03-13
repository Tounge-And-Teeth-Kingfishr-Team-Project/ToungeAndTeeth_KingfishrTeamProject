using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class IntroCutscene : MonoBehaviour
{
    public GameObject player;
    //public GameObject virtualCamera;
    public PlayableDirector cutscene;
    public ParticleSystem smoke;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //virtualCamera.SetActive(true);
        player.SetActive(false);
        cutscene.Play();
        StartCoroutine(waitForCutsceneFinish());
    }
    private IEnumerator waitForCutsceneFinish()
    {
        // Wait until the timeline finishes playing
        while (cutscene.state == PlayState.Playing)
        {
            yield return null;  // Keep checking the timeline state
        }
        //virtualCamera.SetActive(false);
        player.SetActive(true);
        if (smoke != null)
        {
            smoke.Play();
        }
        Destroy(gameObject);
    }
}
