# Utils - Scripts d'aide

Ce dossier contient des scripts utilitaires classés par origine:
- **MP** = scripts liés a **Magic Plan**
- **SW** = scripts liés a **Sweet Home**

## MP - Magic Plan

### `ScaleMP.cs` (`ScaleMp`)
**But**
- Normaliser les objets Magic Plan avec un scale fixe.
- Recentrer l'objet a l'origine locale.

**Ce que fait `ExecuterTransformation()`**
- Applique `localScale = (10, 10, 10)`.
- Applique `localPosition = (0, 0, 0)`.
- Enregistre l'action dans l'Undo Unity (editeur).
- Log de confirmation dans la console.

**Utilisation**
1. Attacher `ScaleMp` au GameObject cible.
2. Clic droit sur le composant.
3. Lancer `== APPLIQUER MAINTENANT ==`.

---

## SW - Sweet Home

### `ScaleSW.cs` (`ScaleSw`)
**But**
- Redimensionner un objet Sweet Home avec un scale fixe `0.01, 0.01, 0.01`.
- Optionnel: appliquer aussi une position locale cible.

**Parametres**
- `utiliserLaPosition`: active/desactive le repositionnement.
- `positionCible`: position locale appliquee si l'option est active.

**Ce que fait `ExecuterTransformation()`**
- Applique le scale fixe.
- Applique la position cible si activee.
- Enregistre l'action dans l'Undo Unity (editeur).
- Log de confirmation dans la console.

**Utilisation**
1. Attacher `ScaleSw` au GameObject cible.
2. Regler `utiliserLaPosition` et `positionCible` si besoin.
3. Clic droit sur le composant.
4. Lancer `== APPLIQUER MAINTENANT ==`.

---

## Outils generaux (diagnostic/edition)

### `GetHierarchy.cs` (`ExportHierarchyToLLM`)
**But**
- Exporter la hierarchie complete d'un objet (parent + enfants) en texte.
- Inclure position, rotation, scale locales et taille monde si renderer present.

**Utilisation**
1. Attacher `ExportHierarchyToLLM` sur la racine a analyser.
2. Passer la scene en `Play`.
3. Recuperer le rapport dans la console Unity.

### `LockObject.cs` (`LockHierarchy`)
**But**
- Verrouiller un objet et tous ses enfants en edition pour eviter les manipulations accidentelles.

**Fonctionnement**
- En `OnEnable`, applique `HideFlags.NotEditable` sur toute la hierarchie.
- Menu contextuel `Unlock All` pour supprimer le verrou (`HideFlags.None`).

**Utilisation**
1. Attacher `LockHierarchy` sur le parent a proteger.
2. Activer le composant pour verrouiller.
3. Clic droit > `Unlock All` pour deverrouiller.
