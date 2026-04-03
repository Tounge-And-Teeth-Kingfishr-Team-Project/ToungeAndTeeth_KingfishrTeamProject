using UnityEngine;

public class MansionText : MonoBehaviour
{
    public ExteriorObjetiveScript exteriorScript;
    void Start()
    {
        
    }

    
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exteriorScript.enterMansionOn = true;
        }
    }
}
