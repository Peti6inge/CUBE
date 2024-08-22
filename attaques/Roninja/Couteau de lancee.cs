public class CouteauDeLancee : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public CouteauDeLancee(Perso perso)
        : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = true;
        aligne = true;
        typeCible = (int)Jeu.CibleType.persoEtInvocEnnemy;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 2);
    }
}
