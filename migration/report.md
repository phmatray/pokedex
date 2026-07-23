# Rapport de migration — Pokédex G (UWP 2016 → Blazor WASM)

**Date :** 2026-07-23 · **Pipeline :** ai-migration-kit v1.4.0 (réécriture port-characterize-wrap) ·
**Branche :** migration/2026-07-23 · **Dashboard :** [report.html](report.html) ·
**Production :** https://phmatray.github.io/pokedexg/

## Avant / après

| | Avant | Après |
|---|---|---|
| Plateforme | UWP 10.0.14393 (Store fermé, Template10 mort) | Blazor WebAssembly, net10.0 |
| Distribution | Windows Store (certificat expiré) | PWA web, hors ligne compris |
| Données | SQLite veekun 49 Mo + 15 requêtes SQL artisanales | mêmes SQLite et requêtes **verbatim**, exécutés au build → API statique JSON |
| Illustrations | 2 713 assets locaux (Sugimori, Global Link, icônes, police) | les mêmes, copiés octet pour octet au build |
| Accès données | SQLite.Net-PCL + copie en mémoire (WinRT) | shim Microsoft.Data.Sqlite (46 lignes), même contrat |
| Tests | aucun (référence pendante dans une .sln morte) | **53** tests de caractérisation, couverture **75 % lignes** |
| Diagnostics Roslyn | solution inanalysable (netcoreapp1.0 + UWP) | **0 erreur, 0 warning** (PokedexG.Blazor.sln) |

## Corrections à l'audit initial

- Le « backend ASP.NET Core moderne à conserver » **n'existait pas** : `PokemonAPI.WebService`
  cible netcoreapp1.0 (2016), exige SQL Server, et n'a **jamais été branché au frontend**
  (aucun HttpClient). Renovate poussait des paquets 10.0.6 dans un projet mort.
- Le « projet de tests » était une référence pendante dans une .sln de sauvegarde.
- La vraie valeur : le SQLite veekun embarqué, les 15 requêtes SQL, 2 713 assets, et la
  logique de fiche (formats, formules, suffixes de formes).

## Portes franchies

1. **Préflight** — 8/8 ; aucune dégradation.
2. **Cœur porté et caractérisé** (`af5fe68`) — modèles/filtrage/logique verbatim (namespaces
   conservés), requêtes 2014 embarquées telles quelles (1 reconstruite : jointures réordonnées,
   le SQLite moderne refuse un ON qui référence une table plus à droite), générateur d'API
   statique (838 JSON) ; 53 tests verts.
3. **UI et garde-fous** (`89d5735`) — 7 pages Blazor (table virtualisée, galerie, fiche à
   4 volets, matrice 18×18, CT, options), identité 2016 (bandeau DarkRed, police Pokemon Solid,
   pokéball, filets bisque), thèmes Rubis/Saphir ; workflows CI + déploiement depuis les
   templates du kit.
4. **Promesses vérifiées et livraison** — contraste AA **mesuré** (22 paires thèmes/badges + 18 encres de
   types ; le blanc de 2016 échouait sur 13 types) ; **hors-ligne prouvé serveur coupé** sur une
   fiche jamais visitée (`captures/fiche-hors-ligne.png`, précache 1 773 entrées) ; publish à
   froid vérifié (assets + données présents) ; **production vérifiée** : jobs build/deploy/verify verts, racine et `/pokemon/25` contrôlées dans un vrai navigateur.

## Quirks figés par les tests (échantillon)

- Recherche : le type 1 se compare **sans** retirer les accents, le type 2 **avec**
  (« électrik » → 0 match par type 1, 6 par type 2) ; tri « par numéro » = tri de chaînes.
- Les « Min IVs » de la fiche gardent les EV à 255 (formule d'origine).
- La requête d'évolutions triplique chaque ligne (fan-out) — l'UI dédoublonne, divergence assumée.
- Formats fr-FR : `5'6" (1.70 m)`, `199.52 lbs (90.5 kg)` — culture figée dans l'app et les tests.

## Estimation vs réalisé

Audit : **29 j** (fourchette 20–37 j) — calibré équipe humaine, et sur de fausses prémisses
(backend « moderne », tests « présents »). Réalisé : **~1 h** chronométrée, redécouverte du
périmètre comprise.

## Prochaines étapes

- [x] Repo rendu public + Pages actif — déploiement, smoke `verify` et fiche profonde vérifiés en production
- [ ] Installer la PWA sur un appareil réel (~15 min)
- [ ] **Décision propriétaire** : archiver ou migrer un jour les projets `PokemonAPI.*` (webservice 2016 jamais branché) (~30 min)

## Suivis différés

- **Actualité** — l'API Bing News de 2016 est morte ; page non portée.
- **Games** — coquille vide dans l'app d'origine ; non portée.
- **Textes des talents** — l'app 2016 affichait l'effet détaillé en anglais (pile EF non portée) ;
  la fiche affiche le texte français du jeu. Divergence assumée.
- **Illustrations hors ligne** — préchargées : données + icônes ; les grandes illustrations
  (25 Mo) se mettent en cache à la visite.
- **Poids des assets** — JPG/PNG de 2016 tels quels ; WebP/AVIF possible en v2.
