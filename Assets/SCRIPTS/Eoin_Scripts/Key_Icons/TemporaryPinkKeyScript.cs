using UnityEngine;
using UnityEngine.UIElements;

public class TemporaryPinkKeyScript : MonoBehaviour
{
    public Transform spawnpoint;
    public GlobeScript globeScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (globeScript.correct == true && globeScript.rotatePoint != 0f)
        {
            transform.position = spawnpoint.position;
        }
    }
}
