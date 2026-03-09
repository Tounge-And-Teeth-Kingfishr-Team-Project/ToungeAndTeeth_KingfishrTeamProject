using System.Linq;
using UnityEngine;

public class GoToNextTrigger : MonoBehaviour
{
    public int currentTrigger = 0;
    public TriggerEnterCallback[] triggers;
    private void OnEnable()
    {
        foreach (var trigger in triggers)
        {
            trigger.onEnter += NextTip;
        }
    }
    private void OnDisable()
    {
        foreach (var trigger in triggers)
        {
            trigger.onEnter -= NextTip;
        }
    }
    void NextTip(TriggerEnterCallback source)
    {
        if (currentTrigger != triggers.Length - 1)
        {
            currentTrigger++;
        }
        triggers[currentTrigger].gameObject.SetActive(true);
        triggers[currentTrigger].enabled = true;
    }
    private void OnDrawGizmos()
    {
        foreach (TriggerEnterCallback t in triggers)
        {
            Gizmos.DrawWireCube(t.transform.position, Vector3.one);
        }
    }
}
