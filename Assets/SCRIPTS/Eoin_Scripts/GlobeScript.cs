using UnityEngine;

public class GlobeScript : MonoBehaviour
{
    public Material unlitMat;
    public Material litMat;
    public bool correct;
    public float rotatePoint;
    void Start()
    {
      GetComponent<Renderer>().material = unlitMat;
        correct = false;
        rotatePoint = 0f;
        transform.Rotate(0f, -90f, 0f);
    }

    void Update()
    {
        //changes the colourto blue when the puzzleis solved
        if (correct == true)
        {
            GetComponent<Renderer>().material = litMat;
        }
        //resets the globe's rotation after five turns
        if (rotatePoint >= 5f)
        {
            rotatePoint = 0f;
            correct = false;
            transform.Rotate(0f, 225f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //turns the globe when the player touches it
        if (other.gameObject.CompareTag("Player") && correct == false)
        {
            rotatePoint++;
            transform.Rotate(0f, -45f, 0f);
            Debug.Log("Globe Rotated");
        }
    }
}
