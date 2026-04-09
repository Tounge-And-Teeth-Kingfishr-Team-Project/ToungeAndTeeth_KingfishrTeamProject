using UnityEngine;

public class MoonInteract : MonoBehaviour
{
    public Material unlitMat;
    public Material litMat;
    public bool correct = false;
    public int correctState;
    public int currentState = 0;

    // Update is called once per frame
    void Update()
    {
        if (currentState == correctState)
        {
            correct = true;
        }
        else
        {
            correct = false;
        }
    }
    public void RotateMoon()
    {
        if (currentState == 4)
        {
            transform.Rotate(0f, 180f, 0f);
            currentState = 0;
        }
        else
        {
            transform.Rotate(0f, -45f, 0f);
            currentState++;
            Debug.Log("Globe Rotated");
        }
    }
    public void AllCorrect()
    {
        GetComponent<Renderer>().material = litMat;
        gameObject.layer = 0;
    }
}
