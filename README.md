# Atelier QA Playwright

## Setup rapide (copy-paste time)

Installer Playwright CLI 
```
dotnet tool install --global Microsoft.Playwright.CLI
playwright.cmd install
```

Cloner ce repository
```
git clone https://github.com/pjerem/AtelierPlaywright.git
```

Créer une classe de tests et copier-coller le contenu de `LuccaEstPresentSurWikipedia.cs`.

Si votre BU a déjà des tests de QA en C# dans son repo, vous pouvez, si vous le souhaitez, copier coller le .csproj dans votre QA existante.

Dans le cadre de cet atelier, nous vous conseillons de lancer vos tests sur une instance locale de dev en .ilucca.local afin de vous épargner la gestion de la problématique du login / mot de passe.

## Gagner du temps avec la codegen
```
npx playwright codegen https://moninstance.ilucca.local
```

## Debug
> Oh mon Dieu, je lance mes tests mais il ne se passe rien.

Par défaut, Playwright exécute les tests en mode Headless.
Pour pouvoir voir ce qu'il se pass en direct et profiter des outils de débug de Playwright, vous devez setter la variable d'environnement PWDEBUG à 1
```
set PWDEBUG=1; # Pour CMD, à adapter à votre environnement / IDE
```

## J'ai besoin d'aide

On est dispo pour ça. Nous découvrons aussi Playwright et sommes encore loin d'être des experts, mais nous nous ferons un plaisir de galérer avec vous à comprendre pourquoi ce purin de sélecteur CSS n'est pas matché.

La doc de Playwright .NET : https://playwright.dev/dotnet/ .\
Attention, le support de Playwright pour dotnet est encore experimental.