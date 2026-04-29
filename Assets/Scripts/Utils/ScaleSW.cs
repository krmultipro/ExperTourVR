using UnityEngine;

public class ScaleSw : MonoBehaviour
{
    [Header("Configuration")]
    public bool utiliserLaPosition = false;
    public Vector3 positionCible;

    private readonly Vector3 scaleFixe = new Vector3(0.01f, 0.01f, 0.01f);

    // CETTE FONCTION APPARAÎT EN FAISANT UN CLIC DROIT SUR LE COMPOSANT
    [ContextMenu("== APPLIQUER MAINTENANT ==")]
    public void ExecuterTransformation()
    {
        // Enregistre l'action pour le Ctrl+Z
#if UNITY_EDITOR
        UnityEditor.Undo.RecordObject(transform, "ScaleSw Transformation");
#endif

        transform.localScale = scaleFixe;

        if (utiliserLaPosition)
        {
            transform.localPosition = positionCible;
        }

        Debug.Log($"<color=cyan>ScaleSw :</color> Appliqué sur {gameObject.name}");
    }
}