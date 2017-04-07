Skip to content
This repository
Search
Pull requests
Issues
Gist
 @Cid-Dev
 Sign out
 Watch 0
  Star 0
  Fork 0 Cid-Dev/BattleDev
 Code  Issues 0  Pull requests 0  Projects 0  Wiki  Pulse  Graphs  Settings
Branch: Question-5 Find file Copy pathBattleDev/README.md
5b36b4b  29 minutes ago
@Cid-Dev Cid-Dev Update README.md
1 contributor
RawBlameHistory     
104 lines (46 sloc)  2.79 KB
Soit un réseau social sur lequel on observe un certain nombre d'évènements de mise en relation entre des personnes. On peut aussi y déclarer des relations impossibles. Chaque personne est désignée par un identifiant unique de 1 à 16 caractères. Le format des évènements est le suivant :

PI + PJ : La personne PI déclare la relation avec la personne PJ (ce qui ne signifie pas que la personne PJ est en relation avec PI)

PI - PJ : la relation entre PI et PJ est impossible ( ce qui ne signifie pas que la relation entre PJ et PI soit impossible)

Lorsque les données contiennent à la fois une relation impossible et une déclaration de relation entre les mêmes personne, c'est la déclaration de relation impossible qui l'emporte (même si la déclaration de relation apparaît plus loin dans les données).

On peut alors déterminer le voisinage de distance d de la personne PI qui est définit comme suit :

PI elle-même (voisinage de distance 0)

Si d>=1, toutes les personnes pour qui PI a déclaré une relation sans en avoir déclaré la fin (voisinage de distance 1).

Si d >1, le voisinage de distance d contient en plus toutes les personnes des voisinages de distance d−1 de chacune des personnes du voisinage de distance 1.

Exemple:

a + b

b + c

b + d

a + e

a - c

a ? 2

Donne : a b d e car même si a est en relation avec c à travers b, sa relation avec c est impossible c.

De même, pour que deux personnes soient en relation à travers des "intermédiaires" il faut qu'aucune des relations entre les intermédiaires ne soit impossible ou qu'il existe un autre chemin avec d'autres intermédiaires pour relier ces deux personnes (et que dans cet autre chemin aucune relation ne soit impossible).

Exemple:

a + b

b + c

b + d

a + e

c + f

e + f

c - f

a ? 3

Donne : a b c d e f car même si a ne peut pas accéder à f à travers c, il peut le faire à travers e.

Exemple:

a + b

b + c

b + d

a + e

a - c

a - e

b - d

a ? 2

Donne : a b

Données

Entrée

Lignes 1 à n - 1 : n-1 déclarations de relation ou de fin de relation entres des personnes. Les identifiants et les signes + ou - sont séparés par des espaces. Les identifiants de personne sont des chaines contenant entre 1 et 16 caractères minuscules (entre a et z)

Ligne n : une question de la forme Pi ? d où Pi est un identifiant de personne et d est un entier représentant une distance de voisinage. L'identifiant, le signe ? et la distance sont séparés par des espaces.

Sortie

Les identifiants des personnes du voisinage de distance d de Pi triés par ordre alphabétiques et séparés par des espaces.

Fichiers de tests et résultats attendus :

https://questionsacm.isograd.com/codecontest/sample_input_output/sample-ifQwgKdQthI-HRF8NiD2RmibCNB_sJykE5ipbvNeTII.zip

https://www.isograd.com/FR/solutionconcours.php
