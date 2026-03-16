using UnityEngine;

public class CandleChecker : MonoBehaviour
{
    public bool correct;

    public bool canLight = false;
    public bool isLit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("E"))
        {
            if (canLight)
            {
                isLit = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            canLight = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            canLight = false;
        }
    }
}
