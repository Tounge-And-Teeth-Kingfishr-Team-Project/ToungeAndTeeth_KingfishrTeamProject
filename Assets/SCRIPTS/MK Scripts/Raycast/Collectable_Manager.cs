using UnityEngine;

public class Collectable_Manager : MonoBehaviour
{
    public bool collected;
    public GameObject UIIcon;
    public GameObject objectDisplay;
    private void Start()
    {
        objectDisplay.SetActive(false);
        UIIcon.SetActive(false);
    }
    public void IWasCollected()
    {
        collected = true;
        UIIcon.SetActive(true);
        objectDisplay.SetActive(false);
    }
}
