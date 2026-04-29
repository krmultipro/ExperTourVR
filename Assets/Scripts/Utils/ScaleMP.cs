using UnityEngine;

public class ScaleMp : MonoBehaviour
{
    // On garde uniquement le scale fixe de 10, 10, 10
    private readonly Vector3 scaleFixe = new Vector3(10f, 10f, 10f);

    [ContextMenu("== APPLIQUER MAINTENANT ==")]
    public void ExecuterTransformation()
    {
        // Enregistre l'action pour le Ctrl+Z dans l'éditeur
#if UNITY_EDITOR
        UnityEditor.Undo.RecordObject(transform, "ScaleMp Transformation");
#endif

        // Applique le nouveau scale
        transform.localScale = scaleFixe;

        // Force la position locale à 0, 0, 0
        transform.localPosition = Vector3.zero;

        Debug.Log($"<color=cyan>ScaleMp :</color> Scale (10) et Position (0,0,0) appliqués sur {gameObject.name}");
    }
}