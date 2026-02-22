# Sudoku Solver - C# Architecture DDD

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-6.0-blue.svg)](https://dotnet.microsoft.com/)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](http://makeapullrequest.com)
[![CI Build](https://github.com/dev-fali/SudokuSolver/actions/workflows/ci.yml/badge.svg)](https://github.com/dev-fali/SudokuSolver/actions/workflows/ci.yml)
---

## 🌐 Language / Langue

- [English](#english)
- [Français](#français)

---

<a name="english"></a>

# 🇬🇧 English Version

## 📋 Table of Contents

- [Features](#features-eng)
- [Installation](#installation-eng)
- [Usage](#usage-eng)
- [Design Patterns](#design-patterns-eng)
- [Tests](#tests-fr)
- [Contributing](#contributing-eng)


<a name="features-eng"></a>
### ✨ Features

- **Rich domain modeling**: Domain model with explicit business rules
- **Multiple solving strategies**:
  - Classic backtracking
  - Backtracking with Minimum Remaining Values (MRV)
- **Extensible architecture**: Easy to add new constraints or heuristics
- **Separation of concerns**: Clear separation between UI, infrastructure, and business logic
- **Business exception handling**: Validation of invalid grids

<a name="installation-eng"></a>
### 🚀 Installation

# Clone the repository
git clone https://github.com/dev-fali/Soduku_solver.git

# Navigate to folder
cd Soduku_solver

# Restore packages
dotnet restore

# Build the project
dotnet build

<a name="usage-eng"></a>
Put your sudoku grid line by line
Run the solver:
dotnet run --project ConsoleApp
<a name="design-patterns-eng"></a>

🎯 Design Patterns Used
Strategy Pattern: For selection and ordering heuristics

Factory Pattern: SolverFactory to create solvers

Repository Pattern: Grid reading/writing

Dependency Injection: Interfaces for strategies

Domain Model: Rich domain modeling

<a name="testing-eng"></a>
# Run unit tests
dotnet test

# With code coverage
dotnet test /p:CollectCoverage=true
<a name="contributing-eng"></a>

🤝 Contributing
Fork the project

Create a branch (git checkout -b feature/AmazingFeature)

Commit changes (git commit -m 'Add AmazingFeature')

Push to branch (git push origin feature/AmazingFeature)

Open a Pull Request


Français
<a name="français"></a>

📋 Table des matières

- [Fonctionnalités](#features-fr)
- [Installation](#installation-fr)
- [Utilisation](#utilisation-fr)
- [Design Patterns](#patterns-fr)
- [Testing](#tests-fr)
- [Contribuer](#contribuer-fr)

<a name="fonctionnalites-fr"></a>

✨ Fonctionnalités
Modélisation métier riche : Domain model avec règles métier explicites

Multiples stratégies de résolution :

Backtracking classique

Backtracking avec Minimum Remaining Values (MRV)

Architecture extensible : Facile d'ajouter de nouvelles contraintes ou heuristiques

Séparation des préoccupations : UI, infrastructure et métier clairement séparés

Gestion des exceptions métier : Validation des grilles invalides

<a name="installation-fr"></a>

🚀 Installation
# Cloner le repository
git clone https://github.com/dev-fali/Soduku_solver.git

# Naviguer dans le dossier
cd Soduku_solver

# Restaurer les packages
dotnet restore

# Builder le projet
dotnet build

<a name="utilisation-fr"></a>
Entrer la grille de sudoku ligne par ligne

Lancer le solveur :
dotnet run --project ConsoleApp
<a name="patterns-fr"></a>

🎯 Patterns de conception utilisés
Strategy Pattern : Pour les heuristiques de sélection et d'ordre

Factory Pattern : SolverFactory pour créer les solveurs

Repository Pattern : Lecture/écriture de grilles

Dependency Injection : Interfaces pour les stratégies

Domain Model : Modélisation riche du domaine

<a name="tests-fr"></a>

🧪 Tests

# Exécuter les tests unitaires
dotnet test

# Avec couverture de code
dotnet test /p:CollectCoverage=true

<a name="contribuer-fr"></a>

🤝 Contribuer
Fork le projet

Créer une branche (git checkout -b feature/AmazingFeature)

Commit les changements (git commit -m 'Add AmazingFeature')

Push la branche (git push origin feature/AmazingFeature)

Ouvrir une Pull Request


