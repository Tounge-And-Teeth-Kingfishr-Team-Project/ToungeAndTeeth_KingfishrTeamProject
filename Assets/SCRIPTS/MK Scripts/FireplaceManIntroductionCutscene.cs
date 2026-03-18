using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.Image;

public class FireplaceManIntroductionCutscene : MonoBehaviour
{
    private BoxCollider cutsceneTrigger;
    public GameObject[] objectsToSwitchOn;
    public GameObject[] objectsToSwitchOff;
    public GameObject player;
    //public GameObject virtualCamera;
    public PlayableDirector cutscene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cutsceneTrigger = GetComponent<BoxCollider>();
        //virtualCamera.SetActive(true);
        foreach (GameObject g in objectsToSwitchOn)
        {
            g.SetActive(false);
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
        foreach (GameObject g in objectsToSwitchOn)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in objectsToSwitchOff)
        {
            g.SetActive(true);
        }
        player.GetComponent<PlayerMovement>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            foreach (GameObject g in objectsToSwitchOn)
            {
                g.SetActive(true);
            }
            foreach (GameObject g in objectsToSwitchOff)
            {
                g.SetActive(false);
            }
            player.GetComponent<PlayerMovement>().enabled = false;
            cutscene.Play();
            cutsceneTrigger.enabled = false;
            StartCoroutine(waitForCutsceneFinish());
        }
    }
}
