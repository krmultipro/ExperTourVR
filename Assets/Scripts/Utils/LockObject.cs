using UnityEngine;

[ExecuteInEditMode]
public class LockHierarchy : MonoBehaviour
{
    void OnEnable()
    {
        // Applique le verrou au parent et à tous les enfants
        foreach (Transform child in GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.hideFlags = HideFlags.NotEditable;
        }
    }

    [ContextMenu("Unlock All")]
    void Unlock()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.hideFlags = HideFlags.None;
        }
    }
}