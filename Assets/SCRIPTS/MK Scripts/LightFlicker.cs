using System.Collections;
using System.Threading;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light myLight;
    public Light myLightInner;
    public float maxWait = 1;
    public float maxFlicker = 0.2f;

    float timer;
    float interval;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        myLight.enabled = !myLight.enabled;
        myLightInner.enabled = !myLightInner.enabled;
        if (myLight.enabled)
        {
            interval = Random.Range(0, maxWait);
        }
        else
        {
            interval = Random.Range(0, maxFlicker);
        }

        timer = 0;
    }
}
