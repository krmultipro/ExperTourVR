using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OuverturePorteVR : MonoBehaviour
{
    [Header("Paramètres de Mouvement")]
    public Transform pivotDeLaPorte;
    public float angleOuverture = 90f;
    public float vitesseRotation = 3f;

    [Header("Sons")]
    public AudioClip sonOuverture;
    public AudioClip sonFermeture;
    private AudioSource audioSource;

    private bool estOuverte = false;
    private bool enMouvement = false;
    private Quaternion rotationFermee;
    private Quaternion rotationOuverte;

    void Start()
    {
        if (pivotDeLaPorte == null) pivotDeLaPorte = transform;
        audioSource = GetComponent<AudioSource>();
        rotationFermee = pivotDeLaPorte.localRotation;
        
        Debug.Log("🚪 Script OuverturePorteVR démarré sur : " + gameObject.name);
    }

    void Update()
    {
        Quaternion cible = estOuverte ? rotationOuverte : rotationFermee;

        if (Quaternion.Angle(pivotDeLaPorte.localRotation, cible) > 0.1f)
        {
            pivotDeLaPorte.localRotation = Quaternion.Slerp(pivotDeLaPorte.localRotation, cible, Time.deltaTime * vitesseRotation);
        }
        else if (enMouvement)
        {
            enMouvement = false;
            if (!estOuverte && sonFermeture != null)
            {
                audioSource.PlayOneShot(sonFermeture);
                Debug.Log("🔊 Son de fermeture joué.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1er LOG : Vérifie si N'IMPORTE QUEL objet touche la porte
        Debug.Log("⚠️ COLLISION DÉTETÉE ! L'objet qui touche la porte s'appelle : [" + other.gameObject.name + "] et son Tag est : [" + other.tag + "]");

        // On vérifie le Tag
        bool estUnJoueur = other.CompareTag("Player") || other.CompareTag("MainCamera") || other.CompareTag("Main Camera");

        if (estUnJoueur)
        {
            if (!estOuverte)
            {
                Debug.Log("✅ SUCCÈS : Joueur détecté ! Ouverture de la porte.");
                
                Vector3 directionJoueur = other.transform.position - pivotDeLaPorte.position;
                float cote = Vector3.Dot(pivotDeLaPorte.forward, directionJoueur);
                float angleFinal = (cote > 0) ? -angleOuverture : angleOuverture;

                rotationOuverte = rotationFermee * Quaternion.Euler(0, angleFinal, 0);

                estOuverte = true;
                enMouvement = true;

                if (sonOuverture != null)
                {
                    audioSource.PlayOneShot(sonOuverture);
                    Debug.Log("🔊 Son d'ouverture joué.");
                }
            }
            else
            {
                Debug.Log("ℹ️ Le joueur est détecté, mais la porte est DÉJÀ ouverte.");
            }
        }
        else
        {
            Debug.Log("❌ REJETÉ : L'objet [" + other.gameObject.name + "] n'a pas le bon Tag.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bool estUnJoueur = other.CompareTag("Player") || other.CompareTag("MainCamera") || other.CompareTag("Main Camera");

        if (estUnJoueur && estOuverte)
        {
            Debug.Log("🚶‍♂️ Le joueur s'éloigne. Fermeture de la porte.");
            estOuverte = false;
            enMouvement = true;
        }
    }
}