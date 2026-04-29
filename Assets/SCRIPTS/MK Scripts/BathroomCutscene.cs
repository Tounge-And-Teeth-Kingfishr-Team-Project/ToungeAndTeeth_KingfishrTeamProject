using NUnit.Framework;
using System.Collections;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BathroomCutscene : MonoBehaviour
{
    private BoxCollider cutsceneTrigger;
    public GameObject[] objectsToSwitchOn;
    public GameObject[] objectsToSwitchOff;
    public GameObject player;
    public GameObject flashlight;
    //public GameObject virtualCamera;
    public PlayableDirector cutscene;
    public string nextScene;

    [Header ("UI")]
    public GameObject loadingScreen;
    public Image loadingBarFill;
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
            g.SetActive(true);
        }
        StartCoroutine(LoadSceneAsync());
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
            flashlight.SetActive(false);
            cutscene.Play();
            cutsceneTrigger.enabled = false;
            StartCoroutine(waitForCutsceneFinish());
        }
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }
}
