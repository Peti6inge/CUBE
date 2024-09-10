public class Piege
{
    // Attributs
    private Jeu.PiegeType type;
    private bool isHost;
    Case myCase;
    Case? myCaseFinale;

    // Constructeur // DONE
    public Piege(Jeu.PiegeType type, bool isHost, Case myCase, Case? myCaseFinale = null)
    {
        this.type = type;
        this.isHost = isHost;
        this.myCase = myCase;
        this.myCaseFinale = myCaseFinale;

        if (isHost)
            myCase.piegeHost = this;
        else
            myCase.piegeClient = this;

        if (myCaseFinale != null)
        {
            if (isHost)
            {
                myCaseFinale.piegeHost = this;
                foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                    c.piegeHost = this;
            }
            else
            {
                myCaseFinale.piegeClient = this;
                foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                    c.piegeClient = this;
            }
        }
    }

    // Méthodes publiques
    public Jeu.EtatType activer(Object cible) // DONE
    {
        switch (type)
        {
            case Jeu.PiegeType.PiegeLineaire:
                return activerPiegeLineaire(cible);
            case Jeu.PiegeType.PiegeALoup:
                return activerPiegeALoup(cible);
            case Jeu.PiegeType.CaseTerrifiante:
                return activerCaseTerrifiante(cible);
            default:
                return Jeu.EtatType.ok;
        }
    }

    public Jeu.EtatType activerPiegeLineaire(Object cible) // DONE
    {
        if (myCaseFinale == null)
            return Jeu.EtatType.ok;
        if (isHost)
        {
            myCase.piegeHost = null;
            myCaseFinale.piegeHost = null;
            foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                c.piegeHost = null;

            return Jeu.roninjaHost.infligeDegats(1, cible);
        }
        else
        {
            myCase.piegeClient = null;
            myCaseFinale.piegeClient = null;
            foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                c.piegeClient = null;

            return Jeu.roninjaClient.infligeDegats(1, cible);
        }
    }

    public Jeu.EtatType activerPiegeALoup(Object cible) // DONE
    {
        if (isHost)
        {
            myCase.piegeHost = null;
            return Jeu.roninjaHost.infligeDegats(3, cible);
        }
        else
        {
            myCase.piegeClient = null;
            return Jeu.roninjaClient.infligeDegats(3, cible);
        }
    }

    public Jeu.EtatType activerCaseTerrifiante(Object cible) // DONE
    {
        if (cible is Perso)
            ((Perso)cible).passeTour = true;

        if (isHost)
            myCase.piegeHost = null;
        else
            myCase.piegeClient = null;
        return Jeu.EtatType.ok;
    }

    public void estDetruit() // DONE
    {
        if (isHost)
            myCase.piegeHost = null;
        else
            myCase.piegeClient = null;

        if (myCaseFinale != null)
        {
            if (isHost)
            {
                myCaseFinale.piegeHost = null;
                foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                    c.piegeHost = null;
            }
            else
            {
                myCaseFinale.piegeClient = null;
                foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                    c.piegeClient = null;
            }
        }
    }
}
