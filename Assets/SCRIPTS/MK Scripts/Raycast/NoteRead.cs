using UnityEngine;

public class NoteRead : MonoBehaviour
{
    public bool reading;
    public GameObject UINote;
    private void Start()
    {
        UINote.SetActive(false);
    }
    private void Update()
    {

    }
    public void ShowNote()
    {
        reading = !reading;
        UINote.SetActive(reading);
    }
}
