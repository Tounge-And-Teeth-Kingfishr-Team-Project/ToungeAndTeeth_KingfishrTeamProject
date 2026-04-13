using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using static UnityEngine.UI.Image;

public class IntroCutscene : MonoBehaviour
{
    public GameObject[] objectsToSwitch;
    public GameObject player;
    public Transform putPlayerHere;
    //public GameObject virtualCamera;
    public PlayableDirector cutscene;
    public ParticleSystem smoke;
    public Pause_Script pauseScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //virtualCamera.SetActive(true);
        foreach (GameObject g in objectsToSwitch)
        {
            g.SetActive(false);
        }
        //player.SetActive(false);
        cutscene.Play();
        StartCoroutine(waitForCutsceneFinish());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cutscene.Stop();
        }
    }
    private IEnumerator waitForCutsceneFinish()
    {
        // Wait until the timeline finishes playing
        while (cutscene.state == PlayState.Playing)
        {
            yield return null;  // Keep checking the timeline state
        }
        //virtualCamera.SetActive(false);
        //player.SetActive(true);
        if (smoke != null)
        {
            smoke.Play();
        }
        foreach (GameObject g in objectsToSwitch)
        {
            g.SetActive(true);
        }
        GameObject thePlayer;
        thePlayer = Instantiate(player, putPlayerHere);
        thePlayer.GetComponent<FlashlightController>().enabled = false;
        // pauseScript.pauseActive = true;
        Destroy(gameObject);
    }
}
