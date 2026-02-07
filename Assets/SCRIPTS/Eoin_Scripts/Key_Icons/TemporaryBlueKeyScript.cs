using UnityEngine;

public class TemporaryBlueKeyScript : MonoBehaviour
{
    public Transform spawnpoint;
    public CandleScript candleScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (candleScript.correct == true && candleScript.incorrect == !true)
        {
            transform.position = spawnpoint.position;
        }
    }
}
