using UnityEngine;
using UnityEngine.UI;

public class Options_Script : MonoBehaviour
{
    public Button optionsButton;
    public GameObject optionsScene;
    public GameObject titleScene;
    public bool optionsOn;
    void Start()
    {
        optionsScene.SetActive(false);
        titleScene.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //if (optionsButton.onClick != null) 
        //{ 
           
        //}
    }

    public void OnClick()
    {
        optionsScene.SetActive(true);
        titleScene.SetActive(false);
    }
}
