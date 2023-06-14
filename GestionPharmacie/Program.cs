using System;
using System.Collections.Generic;

// Classe pour représenter un médicament
public class Medicament
{
    public string Nom { get; set; }
    public string Code { get; set; }
    public decimal Prix { get; set; }
    public int QuantiteStock { get; set; }
}

// Classe pour gérer le stock de médicaments
public class Stock
{
    private List<Medicament> medicaments;

    public Stock()
    {
        medicaments = new List<Medicament>();
    }

    // Ajouter un médicament dans le stock
    public void AjouterMedicament(Medicament medicament)
    {
        medicaments.Add(medicament);
    }

    // Rechercher un médicament par son code
    public Medicament RechercherMedicament(string code)
    {
        return medicaments.Find(m => m.Code == code);
    }

    // Vérifier la disponibilité d'un médicament dans le stock
    public bool VerifierDisponibilite(string code, int quantite)
    {
        Medicament medicament = RechercherMedicament(code);
        return (medicament != null && medicament.QuantiteStock >= quantite);
    }

    // Mettre à jour la quantité de médicaments dans le stock
    public void MettreAJourQuantite(string code, int quantite)
    {
        Medicament medicament = RechercherMedicament(code);
        if (medicament != null)
        {
            medicament.QuantiteStock += quantite;
        }
    }
}

// Classe principale du programme
public class Program
{
    static void Main(string[] args)
    {
        Stock stock = new Stock();

        while (true)
        {
            AfficherMenu();

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterMedicament(stock);
                    break;
                case "2":
                    RechercherMedicament(stock);
                    break;
                case "3":
                    VerifierDisponibilite(stock);
                    break;
                case "4":
                    MettreAJourQuantite(stock);
                    break;
                case "5":
                    Console.WriteLine("Au revoir !");
                    return;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Affiche le menu des options
    static void AfficherMenu()
    {
        Console.WriteLine("                          °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
        Console.WriteLine("                          °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
              Console.WriteLine("                                  °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
                       Console.WriteLine("                                        °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
        Console.WriteLine("                                            Bienvenue dans l'application                    ");
                       Console.WriteLine("                                        °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
              Console.WriteLine("                                  °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
        Console.WriteLine("                          °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
        Console.WriteLine("                          °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");



        Console.WriteLine("          === Menu ===");
        Console.WriteLine("          1. Ajouter un médicament");
        Console.WriteLine("          2. Rechercher un médicament par son code");
        Console.WriteLine("          3. Disponibilité d'un médicament");
        Console.WriteLine("          4. Mis à jour des médicaments");
        Console.WriteLine("          5. Quitter l'Application");
        Console.Write("Choisir une option : ");
    }

    // Méthode pour ajouter un médicament
    static void AjouterMedicament(Stock stock)
    {
        Console.WriteLine("=== Ajouter un médicament ===");
        Console.Write("Nom : ");
        string nom = Console.ReadLine();
        Console.Write("Code : ");
        string code = Console.ReadLine();
        Console.Write("Prix : ");
        decimal prix = decimal.Parse(Console.ReadLine());
        Console.Write("Quantité en stock : ");
        int quantiteStock = int.Parse(Console.ReadLine());

        Medicament medicament = new Medicament
        {
            Nom = nom,
            Code = code,
            Prix = prix,
            QuantiteStock = quantiteStock
        };

        stock.AjouterMedicament(medicament);
        Console.WriteLine("Médicament ajouté avec succès !");
    }

    // Méthode pour rechercher un médicament par code
    static void RechercherMedicament(Stock stock)
    {
        Console.WriteLine("=== Rechercher un médicament par code ===");
        Console.Write("Code : ");
        string code = Console.ReadLine();

        Medicament medicament = stock.RechercherMedicament(code);

        if (medicament != null)
        {
            Console.WriteLine("Médicament trouvé : " + medicament.Nom);
            Console.WriteLine("Code : " +medicament.Code);
            Console.WriteLine("Prix : " +medicament.Prix);
            Console.WriteLine("Quantité : " +medicament.QuantiteStock);
        }
        else
        {
            Console.WriteLine("Médicament non trouvé.");
        }
    }

    // Méthode pour vérifier la disponibilité d'un médicament
    static void VerifierDisponibilite(Stock stock)
    {
        Console.WriteLine("=== Vérifier la disponibilité d'un médicament ===");
        Console.Write("Entrez le code du médicament : ");
        string code = Console.ReadLine();
        Console.Write("Quelle quantité souhaitez vous ? : ");
        int quantite = int.Parse(Console.ReadLine());

        bool disponibilite = stock.VerifierDisponibilite(code, quantite);

        if (disponibilite)
        {
            Console.WriteLine("Le médicament est disponible en quantité suffisante.");
        }
        else
        {
            Console.WriteLine("Le médicament n'est pas disponible en quantité suffisante.");
        }
    }

    // Méthode pour mettre à jour la quantité de médicaments dans le stock
    static void MettreAJourQuantite(Stock stock)
    {
        Console.WriteLine("=== Mise à jour de la quantité de médicaments ===");
        Console.Write("Code : ");
        string code = Console.ReadLine();
        Console.Write("Nouvelle quantité : ");
        int quantite = int.Parse(Console.ReadLine());

        stock.MettreAJourQuantite(code, quantite);
        Console.WriteLine("Quantité mise à jour avec succès !");
    }
}

