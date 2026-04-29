using UnityEngine;

public class ExportHierarchyToLLM : MonoBehaviour
{
    void Start()
    {
        Debug.Log("--- DÉBUT DE LA STRUCTURE DU PREFAB ---");
        string report = GetDetailedHierarchy(transform, "");
        Debug.Log(report);
        Debug.Log("--- FIN DE LA STRUCTURE ---");
    }

    string GetDetailedHierarchy(Transform t, string indent)
    {
        // On récupère les données locales (par rapport au parent)
        string pos = $"Pos: {t.localPosition}";
        string rot = $"Rot: {t.localEulerAngles}";
        string scale = $"Scale: {t.localScale}";
        
        // On vérifie si l'objet a un composant visuel (Renderer) pour donner sa taille "réelle"
        string boundsInfo = "";
        if (t.TryGetComponent<Renderer>(out Renderer r))
        {
            boundsInfo = $" | Size (World): {r.bounds.size}";
        }

        string info = $"{indent}• {t.name} [{pos} | {rot} | {scale}{boundsInfo}]\n";

        foreach (Transform child in t)
        {
            info += GetDetailedHierarchy(child, indent + "    ");
        }
        return info;
    }
}