using UnityEngine;

public class ObservetoryDoor : Interactable
{
    [Header("Door Settings")]
    public Transform doorToRotate;   // Assign the door object
    public float openAngle = 90f;
    public float openSpeed = 3f;

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (doorToRotate == null)
            doorToRotate = transform;

        closedRotation = doorToRotate.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    protected override void Interact(GameObject player)
    {
        ToggleDoor();
        ShowPrompt(false);
    }

    void ToggleDoor()
    {
        isOpen = !isOpen;
        StopAllCoroutines();
        StartCoroutine(RotateDoor(isOpen ? openRotation : closedRotation));
    }

    System.Collections.IEnumerator RotateDoor(Quaternion targetRotation)
    {
        while (Quaternion.Angle(doorToRotate.rotation, targetRotation) > 0.1f)
        {
            doorToRotate.rotation = Quaternion.Slerp(
                doorToRotate.rotation,
                targetRotation,
                Time.deltaTime * openSpeed
            );
            yield return null;
        }

        doorToRotate.rotation = targetRotation;
    }
}
