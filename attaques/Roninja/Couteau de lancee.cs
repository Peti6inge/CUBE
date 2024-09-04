public class CouteauDeLancee : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public CouteauDeLancee(Perso perso)
        : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = true;
        aligne = true;
        typeCible = Jeu.CibleType.persoEtInvocEnnemy;
        limitParCible = 2;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 2);
    }
}
