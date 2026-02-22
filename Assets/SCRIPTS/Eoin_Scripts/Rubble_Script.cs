using UnityEngine;

public class Rubble_Script : Interactable
{
    public KeyManager keyManager;

    [Header("Hitbox Scaling")]
    public float xScale = 2f; // How wide the interactable area is
    public float zScale = 3f; // How long the interactable area is

    void Start()
    {
        if (keyManager == null)
            keyManager = FindFirstObjectByType<KeyManager>();
    }

    protected override void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Transform player position to rubble's local space
            Vector3 localPlayerPos = transform.InverseTransformPoint(player.transform.position);

            // Check if player is within scaled XZ box
            if (Mathf.Abs(localPlayerPos.x) <= xScale && Mathf.Abs(localPlayerPos.z) <= zScale)
            {
                if (!playerInRange)
                {
                    playerInRange = true;
                    ShowPrompt(true);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact(player);
                }
            }
            else
            {
                if (playerInRange)
                {
                    playerInRange = false;
                    ShowPrompt(false);
                }
            }
        }
    }

    protected override void Interact(GameObject player)
    {
        if (keyManager != null && keyManager.shovel)
        {
            keyManager.shovel = false;
            Destroy(gameObject);
            Debug.Log("Rubble cleared using shovel!");
        }
        else
        {
            Debug.Log("You need a shovel to clear this rubble.");
        }

        ShowPrompt(false);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a box gizmo for the scaled hitbox
        Gizmos.color = Color.cyan;

        Vector3 center = transform.position;
        Vector3 size = new Vector3(xScale * 2, 1f, zScale * 2); // multiply by 2 because bounds go both sides

        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, size);
    }
}