public class Esquive : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Esquive(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.esquive;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        perso.esquive = true;
    }
}