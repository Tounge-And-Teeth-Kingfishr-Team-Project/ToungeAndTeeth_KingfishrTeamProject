using UnityEngine;

public class MK_KeyManager : MonoBehaviour
{
    public bool yellowKey = false;
    public bool blueKey = false;
    public bool pinkKey = false;
    public bool shovel = false;

    public Collectable_Manager yellowKeyManager;
    public Collectable_Manager blueKeyManager;
    public Collectable_Manager pinkKeyManager;
    public Collectable_Manager shovelManager;

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
        if (shovelManager.collected)
        {
            shovel = true;
        }
    }
}
