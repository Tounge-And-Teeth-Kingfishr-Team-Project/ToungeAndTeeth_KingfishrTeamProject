using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneScript : Interactable
{
    public int sceneIndex = -1; // Scene to load

    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Interact(GameObject player)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
