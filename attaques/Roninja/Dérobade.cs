public class Derobade : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Derobade(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.derobade;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (cible is Perso) // La cible est un ennemi avec une pierre
        {
            Perso ciblePerso = (Perso)cible;
            perso.pierre = ciblePerso.pierre;
            ciblePerso.pierre = null;
        }
        else if (cible is bool) // La cible est invisible
        {
            Perso? ciblePerso = (bool)cible ? myCase.persoOver() : myCase.perso();
            if (ciblePerso != null)
            {
                perso.pierre = ciblePerso.pierre;
                ciblePerso.pierre = null;
            }
        }
        else if (cible is Pierre) // La cible est une pierre alliée
        {
            Pierre ciblePierre = (Pierre)cible;
            perso.pierre = ciblePierre;
            myCase.removePierre(ciblePierre);
        }
    }
}
