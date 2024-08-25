public class DerobadeDeLOmbre : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public DerobadeDeLOmbre(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 0;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.derobadeDeLOmbre;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (cible is Perso) // La cible est un allié avec une pierre ombre
        {
            Perso ciblePerso = (Perso)cible;
            perso.pierre = ciblePerso.pierre;
            ciblePerso.pierre = null;
        }
        else if (cible is Pierre) // La cible est une pierre ombre adverse
        {
            Pierre ciblePierre = (Pierre)cible;
            perso.pierre = ciblePierre;
            myCase.removePierre(ciblePierre);
        }
    }
}
