public class FlecheDeLumiere : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public FlecheDeLumiere(Perso perso) : base(perso)
    {
        cout = 4;
        porteeMin = 0;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.flecheDeLumiere";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (cible is Perso) // La cible est un allié avec une pierre lumière
        {
            Perso ciblePerso = (Perso)cible;
            perso.pierre = ciblePerso.pierre;
            ciblePerso.pierre = null;
        }
        else if (cible is Pierre) // La cible est une pierre lumière adverse
        {
            Pierre ciblePierre = (Pierre)cible;
            perso.pierre = ciblePierre;
            myCase.removePierre(ciblePierre);
        }
    }
}