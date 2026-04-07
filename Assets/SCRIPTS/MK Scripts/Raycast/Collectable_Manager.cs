using UnityEngine;

public class Collectable_Manager : MonoBehaviour
{
    public bool collected;
    public GameObject UIIcon;
    private void Start()
    {
        UIIcon.SetActive(false);
    }
    public void IWasCollected()
    {
        collected = true;
        UIIcon.SetActive(true);
    }
}
