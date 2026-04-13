using UnityEngine;

public class Disappearing_Door_Script : MonoBehaviour
{
    public GameObject Door;
    public GameObject Wall;
    
    void Start()
    {
        Door.SetActive(true);
        Wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Door.SetActive(false);
            Wall.SetActive(true);
        }
    }
}
