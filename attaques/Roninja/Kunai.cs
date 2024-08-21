public class Kunai : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Kunai(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = "persoEtInvocEnnemy";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}