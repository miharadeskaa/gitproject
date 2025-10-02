
//Créer un jeu de gestion de fruits au marché à l aide d' un tableau de chaînes de caractères.
//L'utilisateur peut ajouter au maximum 5 fruits , les retirer , les afficher et les rechercher.
//Gérer les doublons lors de l'ajout d'un fruit.
//Permettez à l'utilisateur de quitter le jeu via le menu.
/**
 * Programme de gestion d'un panier de fruits en console.
 *
 * Fonctionnalités :
 * 1. Ajouter un fruit au panier (maximum 5, pas de doublons, normalisation en minuscules).
 * 2. Retirer un fruit du panier (suppression par nom, normalisation en minuscules).
 * 3. Afficher les fruits du panier (affichage normal et trié par ordre alphabétique).
 * 4. Rechercher un fruit dans le panier (recherche par nom, normalisation en minuscules).
 * 5. Quitter le programme.
 *
 * Variables principales :
 * - fruits : tableau de chaînes de caractères pour stocker les fruits.
 * - count : entier représentant le nombre de fruits actuellement dans le panier.
 *
 * Utilisation :
 * - Menu interactif en boucle jusqu'à la sortie.
 * - Vérification des entrées utilisateur pour éviter les erreurs et doublons.
 * - Affichage des messages d'information et d'erreur selon les actions.
 */


using System;

class Program
{
    static string[] fruits = new string[5];
    static int count = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Ajouter un fruit");
            Console.WriteLine("2. Retirer un fruit");
            Console.WriteLine("3. Afficher les fruits");
            Console.WriteLine("4. Rechercher un fruit");
            Console.WriteLine("5. Quitter");
            Console.Write("Votre choix: ");
            string? choix = Console.ReadLine();

            if (choix == "1")
            {
                if (count == 5) // Le panier est plein
                {
                    Console.WriteLine("Le panier est rempli !");
                }
                else
                {
                    Console.Write("Entrez le nom du fruit à ajouter: ");
                    string? fruit = Console.ReadLine();

                    // Vérification 
                    if (fruit == null || fruit == "")
                    {
                        Console.WriteLine("Nom de fruit invalide.");
                        continue;
                    }

                    fruit = fruit.ToLower(); // normaliser en minuscules

                    bool doublon = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (fruits[i].ToLower() == fruit) // comparaison avec ==
                        {
                            doublon = true; // fruit déjà présent
                            break;
                        }
                    }
                    if (doublon)
                    {
                        Console.WriteLine("Ce fruit est déjà présent dans le panier.");
                    }
                    else
                    {
                        fruits[count] = fruit;
                        count++;
                        Console.WriteLine($"{fruit}  est ajouté au panier.");
                    }
                }
            }
            else if (choix == "2")
            {
                Console.Write("Entrez le nom du fruit à retirer: ");
                string? fruit = Console.ReadLine();

                if (fruit == null || fruit == "")
                {
                    Console.WriteLine("Nom de fruit inexistant dans le panier.");
                    continue;
                }

                fruit = fruit.ToLower();

                bool retire = false;
                for (int i = 0; i < count; i++)
                {
                    if (fruits[i].ToLower() == fruit)
                    {
                        for (int j = i; j < count - 1; j++)
                            fruits[j] = fruits[j + 1];

                        fruits[count - 1] = null!;
                        count--;
                        retire = true;
                        Console.WriteLine($"{fruit} retiré du panier.");
                        break;
                    }
                }
                if (!retire)
                    Console.WriteLine("Fruit non trouvé dans le panier.");
            }
            else if (choix == "3")
            {
                Console.WriteLine("Fruits dans le panier:");
                if (count == 0)
                    Console.WriteLine("Aucun fruit n' est dans le panier.");
                else
                {
                    for (int i = 0; i < count; i++)
                        Console.WriteLine($"- {fruits[i]}");
                }
                //dans l'ordre alphabétique
                Array.Sort(fruits, 0, count);
                Console.WriteLine("Fruits dans le panier dans l'ordre alphabétique:");
                for (int i = 0; i < count; i++)
                    Console.WriteLine($"- {fruits[i]}");

            }

            else if (choix == "4")
            {
                Console.Write("Recherche de fruits: ");
                string? fruit = Console.ReadLine();

                if (fruit == null || fruit == "")
                {
                    Console.WriteLine("Nom de fruit inexistant.");
                    continue;
                }

                fruit = fruit.ToLower();

                bool trouve = false;
                for (int i = 0; i < count; i++)
                {
                    if (fruits[i] == fruit)
                    {
                        trouve = true;
                        break;
                    }
                }
                Console.WriteLine(trouve ? "Fruit trouvé !" : "Fruit perdu.");
            }
            else if (choix == "5")
            {
                Console.WriteLine("Merci de votre visite !");
                break;
            }
            else
            {
                Console.WriteLine("Choix invalide. Veuillez réessayer.");
            }
        }
    }
}


