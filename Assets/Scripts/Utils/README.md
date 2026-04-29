# Utils - Scripts d'aide

Ce dossier contient des scripts utilitaires pour manipuler rapidement des objets dans Unity et extraire des informations utiles pour l'analyse de scène/prefab.

## 1) `ScaleSW.cs` (`ScaleSw`)

### A quoi sert ce script
- Appliquer une **échelle fixe** à un objet (`0.01, 0.01, 0.01`).
- Optionnellement repositionner l'objet avec une position cible.
- Exécuter l'action manuellement depuis l'inspecteur via un bouton de menu contextuel.

### Comment ça fonctionne
- Le script expose :
  - `utiliserLaPosition` : active ou non le déplacement.
  - `positionCible` : position locale à appliquer si l'option est activée.
- La méthode `ExecuterTransformation()` :
  - enregistre l'action dans l'Undo Unity (Ctrl+Z en éditeur),
  - applique la scale fixe,
  - applique la position si demandé,
  - écrit un log de confirmation dans la console.

### Comment l'utiliser
1. Attacher `ScaleSw` à un GameObject.
2. Régler les paramètres dans l'inspecteur (`utiliserLaPosition`, `positionCible`).
3. Clic droit sur le composant -> `== APPLIQUER MAINTENANT ==`.

### Cas d'usage typique
- Corriger rapidement l'échelle d'objets importés (OBJ/FBX) trop grands.
- Uniformiser la scale d'un lot d'objets.

---

## 2) `GetHierarchy.cs` (`ExportHierarchyToLLM`)

### A quoi sert ce script
- Générer un **rapport texte complet de la hiérarchie** d'un objet (et de tous ses enfants).
- Afficher pour chaque noeud :
  - position locale,
  - rotation locale,
  - scale locale,
  - taille monde (`Renderer.bounds.size`) si un `Renderer` est présent.

### Comment ça fonctionne
- Au démarrage (`Start`), le script :
  1. écrit un marqueur de début dans la console,
  2. parcourt récursivement la hiérarchie,
  3. construit une chaîne formatée lisible,
  4. affiche le résultat puis un marqueur de fin.

### Comment l'utiliser
1. Attacher `ExportHierarchyToLLM` au parent/racine que tu veux analyser.
2. Lancer la scène (`Play`).
3. Copier le rapport affiché dans la console Unity.

### Cas d'usage typique
- Documenter la structure d'un prefab.
- Vérifier les transformations locales de chaque enfant.
- Préparer une description exploitable dans une discussion technique/LLM.

---

## Notes
- Ces scripts sont des outils de support pour l'édition et le diagnostic.
- Si tu veux, je peux aussi ajouter un petit script "launcher" pour appliquer `ScaleSw` sur plusieurs objets sélectionnés d'un coup.
