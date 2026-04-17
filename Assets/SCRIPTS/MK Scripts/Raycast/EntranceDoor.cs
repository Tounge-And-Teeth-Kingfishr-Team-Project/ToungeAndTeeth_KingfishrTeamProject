using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceDoor : MonoBehaviour
{
    public Collectable_Manager key;
    public GameObject keyUI;
    public bool canOpen = false;

    public GameObject lockedUI;
    public float lockedUIDialogueTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (key != null)
        {
            if (key.collected)
            {
                canOpen = true;
            }
        }
    }
    public void OpenDoor()
    {
        if (!canOpen)
        {
            StartCoroutine(DisplayLockedMessage());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    IEnumerator DisplayLockedMessage()
    {
        lockedUI.SetActive(true);
        yield return new WaitForSeconds(lockedUIDialogueTime);
        lockedUI.SetActive(false);
    }
}
