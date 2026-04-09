using UnityEngine;

public class Collectable_Manager : MonoBehaviour
{
    public bool collected;
    public GameObject UIIcon;
    public GameObject objectDisplay;
    public bool startOn;
    private void Start()
    {
        UIIcon.SetActive(false);

        if (startOn)
        {
            objectDisplay.SetActive(true);
        }
        else
        {
            objectDisplay.SetActive(false);
        }
    }
    public void IWasCollected()
    {
        collected = true;
        UIIcon.SetActive(true);
        objectDisplay.SetActive(false);
    }
}
