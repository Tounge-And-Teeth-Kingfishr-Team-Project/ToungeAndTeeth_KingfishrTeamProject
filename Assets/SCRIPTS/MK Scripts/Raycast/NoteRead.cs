using UnityEngine;

public class NoteRead : MonoBehaviour
{
    private bool reading;
    public GameObject UINote;
    private void Start()
    {
        UINote.SetActive(false);
    }
    private void Update()
    {
        if (reading)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShowNote();
            }
        }
    }
    public void ShowNote()
    {
        reading = !reading;
        UINote.SetActive(reading);
    }
}
