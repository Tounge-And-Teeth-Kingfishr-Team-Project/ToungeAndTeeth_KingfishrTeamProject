using System.Collections;
using UnityEngine;

public class Doors_Manager : MonoBehaviour
{
    public enum WhichKey
    {
        Yellow,
        Blue,
        Pink,
        Shovel
    }
    [Header("Unlock Requirements")]
    public WhichKey color;
    public bool unlocked;
    public bool canUnlock;
    public MK_KeyManager keyManager;

    [Header("UI")]
    public GameObject lockedUI;
    public float lockedUIDialogueTime = 3f;

    [Header("Door Setup")]
    public float rotationAmount = -90f;
    public float openSpeed = 3f;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        if (lockedUI != null)
        {
            lockedUI.SetActive(false);
        }
        closedRotation = transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, rotationAmount, 0);
    }
    private void Update()
    {
        if (keyManager != null)
        {
            if (color == WhichKey.Yellow)
            {
                if (keyManager.yellowKey) canUnlock = true;
            }
            else if (color == WhichKey.Blue)
            {
                if (keyManager.blueKey) canUnlock = true;
            }
            else if (color == WhichKey.Pink)
            {
                if (keyManager.pinkKey) canUnlock = true;
            }
            else if (color == WhichKey.Shovel)
            {
                if (keyManager.shovel) canUnlock = true;
            }
        }
    }
    public void UnlockDoor()
    {
        if (canUnlock)
        {
            unlocked = true;
            if (keyManager != null)
            {
                if (color == WhichKey.Yellow)
                {
                    keyManager.yellowKeyManager.UIIcon.SetActive(false);
                }
                else if (color == WhichKey.Blue)
                {
                    keyManager.blueKeyManager.UIIcon.SetActive(false);
                }
                else if (color == WhichKey.Pink)
                {
                    keyManager.pinkKeyManager.UIIcon.SetActive(false);
                }
                else if (color == WhichKey.Shovel)
                {
                    keyManager.shovelManager.UIIcon.SetActive(false);
                }
            }
            if (color != WhichKey.Shovel)
            {
                StartCoroutine(RotateDoor(openRotation));
            }
            else
            {
                DestroyRubble();
            }
        }
        else
        {
            StartCoroutine(DisplayLockedMessage());
        }
    }
    IEnumerator DisplayLockedMessage()
    {
        lockedUI.SetActive(true);
        yield return new WaitForSeconds(lockedUIDialogueTime);
        lockedUI.SetActive(false);
    }

    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * openSpeed
            );

            yield return null;
        }

        transform.rotation = targetRotation;
    }
    void DestroyRubble()
    {
        Destroy(gameObject);
    }
}
