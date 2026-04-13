using UnityEngine;
using UnityEngine.UI;

public class Back_Script : MonoBehaviour
{
    public Button backButton;
    public GameObject optionsScene;
    public GameObject titleScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (backButton.onClick != null)
        //{
            
        //}
    }

    public void OnClick()
    {
        optionsScene.SetActive(false);
        titleScene.SetActive(true);
    }
}
