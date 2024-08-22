public class DragNDrop : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public DragNDrop(Perso perso)
        : base(perso)
    {
        cout = 1;
        porteeMin = 0;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.dragNDrop;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (perso.pierre != null) // Le perso dépose la pierre
        {
            perso.dropPierre(myCase);
        }
        else // Le perso récupère la pierre
        {
            if (cible is Pierre) // cas 1 : La case contient une pierre adverse
            {
                Pierre ciblePierre = (Pierre)cible;
                perso.pierre = ciblePierre;
                myCase.removePierre(ciblePierre);
            }
            else if (cible is Perso) // cas : La cible est un perso
            {
                Perso ciblePerso = (Perso)cible;
                perso.pierre = ciblePerso.pierre;
                ciblePerso.pierre = null;
            }
        }
    }
}
