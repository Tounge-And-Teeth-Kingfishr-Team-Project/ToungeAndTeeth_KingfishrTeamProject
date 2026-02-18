using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject uvControlsUI;

    public void ShowUVControls(float duration)
    {
        if (uvControlsUI != null)
        {
            uvControlsUI.SetActive(true);
            StartCoroutine(HideAfterTime(duration));
        }
    }

    private IEnumerator HideAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (uvControlsUI != null)
            uvControlsUI.SetActive(false);
    }
}

