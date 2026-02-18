using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public GameObject pressE_UI;
    public UnityEvent onInteract;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            onInteract.Invoke();

            if (pressE_UI != null)
            {
                pressE_UI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (pressE_UI != null)
            {
                pressE_UI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (pressE_UI != null)
            {
                pressE_UI.SetActive(false);
            }
        }
    }
}
