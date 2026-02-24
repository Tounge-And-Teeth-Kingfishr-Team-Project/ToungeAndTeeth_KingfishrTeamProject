using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MirrorDimensionStalker : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform targetDestination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetDestination = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(targetDestination.position);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            Debug.Log("I hit the player, TELEPORT THEMMMMM");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
