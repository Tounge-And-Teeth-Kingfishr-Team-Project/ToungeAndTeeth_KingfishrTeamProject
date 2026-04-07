using UnityEngine;

public class MK_KeyManager : MonoBehaviour
{
    public bool yellowKey = false;
    public bool blueKey = false;
    public bool pinkKey = false;

    public Collectable_Manager yellowKeyManager;
    public Collectable_Manager blueKeyManager;
    public Collectable_Manager pinkKeyManager;

    private void Update()
    {
        if (yellowKeyManager.collected)
        {
            yellowKey = true;
        }
        if (blueKeyManager.collected)
        {
            blueKey = true;
        }
        if (pinkKeyManager.collected)
        {
            pinkKey = true;
        }
    }
}
