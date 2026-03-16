using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light firstLight;
    public Light secondLight;
    float timer;
    float interval;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interval = Random.Range(0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            firstLight.enabled = !firstLight.enabled;
            secondLight.enabled = !secondLight.enabled;
            interval = Random.Range(0.1f, 1f);
            timer = 0f;
        }
    }
}
