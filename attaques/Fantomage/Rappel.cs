public class Rappel : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Rappel(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 0;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.rappel;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Perso? persoCible = (Perso?)cible;
        if (persoCible != null)
            persoCible.rappelSpawn();
    }
}
