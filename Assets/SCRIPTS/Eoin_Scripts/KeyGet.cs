using UnityEngine;

public class KeyGet : MonoBehaviour
{
    public bool yellowKey;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            yellowKey = true;
            Destroy(gameObject);
        }
    }
}
