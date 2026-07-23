![pokedexg banner](.github/banner.png)

# Pokédex G

<!-- portfolio-badges:start -->
<!-- Identity -->
[![phmatray - pokedexg](https://img.shields.io/static/v1?label=phmatray&message=pokedexg&color=blue&logo=github)](https://github.com/phmatray/pokedexg)
![Top language](https://img.shields.io/github/languages/top/phmatray/pokedexg)
[![Stars](https://img.shields.io/github/stars/phmatray/pokedexg?style=social)](https://github.com/phmatray/pokedexg/stargazers)
[![Forks](https://img.shields.io/github/forks/phmatray/pokedexg?style=social)](https://github.com/phmatray/pokedexg/network/members)

<!-- Activity -->
[![Issues](https://img.shields.io/github/issues/phmatray/pokedexg)](https://github.com/phmatray/pokedexg/issues)
[![Pull requests](https://img.shields.io/github/issues-pr/phmatray/pokedexg)](https://github.com/phmatray/pokedexg/pulls)
[![Last commit](https://img.shields.io/github/last-commit/phmatray/pokedexg)](https://github.com/phmatray/pokedexg/commits)
<!-- portfolio-badges:end -->

<!-- portfolio-toc:start -->

## Table of Contents

- [Architecture](#architecture)
- [Développement](#développement)
- [Données & crédits](#données--crédits)
- [Provenance](#provenance)
- [Tech Stack](#tech-stack)
- [License](#license)
- [Contributing](#contributing)

<!-- portfolio-toc:end -->



> Les 721 Pokémon des générations 1 à 6, en français — fiches complètes, méga-évolutions,
> formes alternatives, table des types et capsules techniques. Consultable hors ligne (PWA).

## Features

- **Pokédex complet** — les 721 Pokémon des générations 1 à 6 (`/`), triable par numéro ou par famille d'évolution, avec recherche instantanée et un bouton « Hasardex » pour ouvrir une fiche au hasard.
- **Fiches détaillées** — chaque Pokémon (`/pokemon/{id}`) affiche ses statistiques, ses types, ses évolutions, méga-évolutions et formes alternatives.
- **Galerie d'illustrations** — vue en grille (`/galerie`) de tous les sprites/artworks, avec recherche par nom.
- **Table des types** — matrice complète des forces et faiblesses (`/types` et `/type/{id}`) entre les 18 types.
- **Capsules techniques** — liste des CTs (`/machines`) avec puissance, précision, PP et type associé.
- **Personnalisation** — page Options (`/options`) pour choisir le tri du Pokédex, afficher/masquer les méga-évolutions et formes alternatives, et changer le style des illustrations (thèmes « Rubis »/« Saphir »).
- **Consultation hors ligne** — `manifest.webmanifest` + service worker font de l'app une PWA installable et utilisable sans connexion.

## Architecture

| Projet | Rôle |
|---|---|
| `src/PokedexG.Core` | Modèles, filtrage et logique métier de 2016, portés verbatim (namespaces conservés) |
| `src/PokedexG.Data` | Façade `Veekun` + les 15 requêtes SQL de 2014 (verbatim, embarquées) sur `pokedex.sqlite` |
| `src/PokedexG.DataGen` | Générateur : exécute les requêtes au build → API statique JSON (`wwwroot/data/`) |
| `src/PokedexG.Web` | Blazor WebAssembly — 7 pages, thèmes « Rubis »/« Saphir », PWA hors ligne |
| `tests/PokedexG.Core.Tests` | 53 tests de caractérisation (requêtes, formats, filtre, couleurs) |
| `PokedexG.Uwp` | L'app UWP de 2016 — source des données (SQLite veekun 49 Mo) et des 2 713 assets |

Les données et les illustrations ne sont jamais dupliquées : le SQLite et les assets de 2016
sont lus/copiés octet pour octet au build.

## Développement

```bash
dotnet test PokedexG.Blazor.sln                 # 53 tests de caractérisation
dotnet run --project src/PokedexG.DataGen       # régénère l'API statique JSON
dotnet run --project src/PokedexG.Web           # sert l'app en local
cd src/PokedexG.Web && npm install && npm run css  # feuille Tailwind (committée)
```

La CI (`.github/workflows/ci.yml`) exécute les tests avec couverture ; le déploiement
(`deploy-pages.yml`) publie sur GitHub Pages avec un smoke test permanent (racine + fiche).

## Usage

L'application est consultable en ligne sur [phmatray.github.io/pokedexg](https://phmatray.github.io/pokedexg/)
(installable comme PWA, utilisable hors connexion une fois chargée) :

- **Rechercher** un Pokémon par nom depuis le champ de recherche du Pokédex (`/`) ou de la Galerie (`/galerie`).
- **Ouvrir une fiche** au hasard avec le bouton « Hasardex », ou directement via une URL du type `/pokemon/6` (fiche de Dracaufeu).
- **Consulter la table des types** (`/types`) pour les forces/faiblesses, ou les capsules techniques (`/machines`) pour la puissance/précision d'une CT.
- **Ajuster l'affichage** depuis `/options` : tri par numéro ou par famille d'évolution, affichage des méga-évolutions/formes alternatives, thème des illustrations.

Pour la lancer en local :

```bash
dotnet run --project src/PokedexG.Web
```

## Données & crédits

- Base de données : [veekun](https://veekun.com/) (schéma pokedex, contenu multilingue).
- Illustrations : Ken Sugimori & Global Link, collectées pour l'app de 2016.
- Pokédex G n'est pas affilié avec, sponsorisé, ou spécifiquement approuvé par Nintendo,
  Game Freak, Creatures et The Pokémon Company. Pokémon est une marque déposée de
  Nintendo Co., Ltd. Usage démonstratif et éducatif uniquement.

## Provenance

L'application d'origine (2016) est une app UWP distribuée par le Windows Store, conservée
dans `PokedexG.Uwp/`. Le rapport de modernisation — méthode, portes franchies, quirks figés,
preuves — est dans [`migration/report.md`](migration/report.md).

<!-- portfolio-techstack:start -->

## Tech Stack

- **.NET 10 · netcoreapp1.0**
- Microsoft.NET.Sdk
- Microsoft.NETCore.App
- System.Runtime.Serialization.Primitives
- Microsoft.NET.Sdk.Web
- Microsoft.AspNetCore.Mvc
- Microsoft.AspNetCore.Routing
- Microsoft.AspNetCore.Server.IISIntegration
- Microsoft.AspNetCore.Server.Kestrel

<!-- portfolio-techstack:end -->

<!-- portfolio-roadmap:start -->

## Roadmap

Planned work and known limitations are tracked in the [open issues](https://github.com/phmatray/pokedexg/issues). Contributions toward them are welcome.

<!-- portfolio-roadmap:end -->

## License

MIT

---

<!-- portfolio-sections:start -->

## Contributing

Contributions are welcome. Open an issue first to discuss any significant change.

1. Fork the repository and create your branch (`git checkout -b feat/my-feature`)
2. Commit your changes (`git commit -m 'feat: ...'`)
3. Push the branch and open a Pull Request

<!-- portfolio-sections:end -->
