Dans ce challenge, vous devez déterminer si un RIB est valide. Un RIB est composé de :

5 caractères pour le code banque,

5 caractères pour le code guichet,

11 caractères pour le numéro de compte,

2 chiffres pour la clé RIB Les caractères peuvent être soit :

des chiffres entre 0 et 9

des lettres non accentuées entre a et z ou A et Z

La clé RIB permet de détecter des erreurs dans la transcription du RIB. Sa valeur est calculée comme suit :

chaque lettre est remplacée par le chiffre correspondant (même chiffre pour les majuscules que pour les minuscules) : a, j => 1
b, k, s => 2

c, l, t => 3

d, m, u => 4

e, n, v => 5

f, o, w => 6

g, p, x => 7

h, q, y => 8

i, r, z => 9

On calcule la somme de : 89 × codedebanque + 15 × codeguichet + 3 × numérodecompte

La clé RIB est alors égale à 97 moins le modulo 97 de la somme précédente.

Votre programme va recevoir une série de RIB et va déterminer s'ils sont valides.

Données

Entrée

Une série de lignes contenant des données au format RIB, le code banque, le code guichet, le numéro de compte et la clef RIB sont séparés par des espaces.

Sortie

Une série de lignes contenant OK ou KO indiquant si la ligne correspondante du fichier d'entrée correspond à un RIB valide.

Fichiers de tests et de résultats attendus :

https://questionsacm.isograd.com/codecontest/sample_input_output/sample-AUee7ZtptxwNDNjH5sJ30I2WWMbwovKaeG37WF_gRZ0.zip

Petite erreur entre l'énoncé et leurs fichiers de tests, ces derniers ont 10 caractères pour le numéro de compte contrairement aux 11 annoncés

https://www.isograd.com/FR/solutionconcours.php
