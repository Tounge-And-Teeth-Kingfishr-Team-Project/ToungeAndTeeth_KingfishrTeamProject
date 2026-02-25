using System.Numerics;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    private Rigidbody rb;
    public float vel;
    public GameObject idle;
    public GameObject walk;
    public GameObject run;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        vel = rb.linearVelocity.magnitude;
    }
    public void ChangeAnimation()
    {
        if (vel <= 2)
        {
            idle.SetActive(true);
            walk.SetActive(false);
            run.SetActive(false);
        }
        else if (vel > 10)
        {
            idle.SetActive(false);
            walk.SetActive(false);
            run.SetActive(true);
        }
        else
        {
            idle.SetActive(false);
            walk.SetActive(true);
            run.SetActive(false);
        }
    }
}
