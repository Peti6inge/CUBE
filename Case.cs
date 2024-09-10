public class Case
{
    // Attributs // DONE
    public bool containsSimpleObstacle { get; set; }
    public bool containsDoubleObstacle { get; set; }
    public Jeu.DirectionType orientationDoubleObstacle { get; set; }
    public bool containsGlissante { get; set; }
    public bool containsCamouflage { get; set; }
    public bool containsTrou { get; set; }
    public bool containsGraviteFantomageHost { get; set; }
    public bool containsGraviteFantomageClient { get; set; }
    public bool containsBrumeRoninjaHost { get; set; }
    public bool containsBrumeRoninjaClient { get; set; }
    public Piege? piegeHost { get; set; }
    public Piege? piegeClient { get; set; }
    public InvocationSimpleBloquante? invocationSimpleBloquante { get; set; }
    public InvocationDoubleBloquante? invocationDoubleBloquante { get; set; }
    public bool containsPoudre { get; set; }
    public bool containsTableHost { get; set; }
    public bool containsTableClient { get; set; }
    public Jeu.SpawnType obstacleSpawn { get; set; }
    public Face face { get; set; }
    public int row { get; set; }
    public int col { get; set; }

    // Constructeur // DONE
    public Case(Jeu.CaseType type, Face face, int row, int col)
    {
        containsSimpleObstacle = false;
        containsDoubleObstacle = false;
        orientationDoubleObstacle = Jeu.DirectionType.none;
        containsGlissante = false;
        containsCamouflage = false;
        containsTrou = false;
        containsGraviteFantomageHost = false;
        containsGraviteFantomageClient = false;
        containsBrumeRoninjaHost = false;
        containsBrumeRoninjaClient = false;
        containsPoudre = false;
        containsTableHost = false;
        containsTableClient = false;
        obstacleSpawn = Jeu.SpawnType.none;
        this.face = face;
        this.row = row;
        this.col = col;

        switch (type)
        {
            case Jeu.CaseType.Vide:
                break;
            case Jeu.CaseType.SimpleObstacle:
                containsSimpleObstacle = true;
                break;
            case Jeu.CaseType.Table:
                if (face.name == Jeu.FaceType.Host)
                    containsTableHost = true;
                else
                    containsTableClient = true;
                break;
            case Jeu.CaseType.DoubleObstacleHaut:
                containsDoubleObstacle = true;
                orientationDoubleObstacle = Jeu.DirectionType.Up;
                break;
            case Jeu.CaseType.DoubleObstacleBas:
                containsDoubleObstacle = true;
                orientationDoubleObstacle = Jeu.DirectionType.Down;
                break;
            case Jeu.CaseType.DoubleObstacleGauche:
                containsDoubleObstacle = true;
                orientationDoubleObstacle = Jeu.DirectionType.Left;
                break;
            case Jeu.CaseType.DoubleObstacleDroite:
                containsDoubleObstacle = true;
                orientationDoubleObstacle = Jeu.DirectionType.Right;
                break;
            case Jeu.CaseType.Trou:
                containsTrou = true;
                break;
            case Jeu.CaseType.Camouflage:
                containsCamouflage = true;
                break;
            case Jeu.CaseType.Glissante:
                containsGlissante = true;
                break;
            case Jeu.CaseType.Roninja:
                obstacleSpawn = Jeu.SpawnType.Roninja;
                break;
            case Jeu.CaseType.Piratitan:
                obstacleSpawn = Jeu.SpawnType.Piratitan;
                break;
            case Jeu.CaseType.Fantomage:
                obstacleSpawn = Jeu.SpawnType.Fantomage;
                break;
            case Jeu.CaseType.Elfee:
                obstacleSpawn = Jeu.SpawnType.Elfee;
                break;
            default:
                break;
        }
    }

    // Méthodes public
    public bool seemsWalkable(Perso byPerso) // DONE
    {
        Perso? persoOverCandidat = persoOver();
        Perso? persoCandidat = perso();

        if (byPerso.myCase == null)
            return false;

        if (byPerso.harponne.Count != 0 && face != byPerso.myCase.face)
            return false;

        if (
            byPerso.porte != null
            && byPerso.porte.harponne.Count != 0
            && byPerso.porte.myCase != null
            && face != byPerso.porte.myCase.face
        )
            return false;

        if (byPerso.enVol)
        {
            if (
                (persoOverCandidat != null && persoOverCandidat.isVisibleForMe(byPerso.isHost))
                || obstacleSpawn != Jeu.SpawnType.none
                || containsTableHost
                || containsTableClient
            )
            {
                return false;
            }
        }
        else if (
            containsSimpleObstacle
            || containsDoubleObstacle
            || invocationSimpleBloquante != null
            || invocationDoubleBloquante != null
            || containsTableHost
            || containsTableClient
            || obstacleSpawn != Jeu.SpawnType.none
            || (persoCandidat != null && persoCandidat.isVisibleForMe(byPerso.isHost))
        )
        {
            return false;
        }
        else
        {
            if (
                byPerso.porte != null
                && persoOverCandidat != null
                && persoOverCandidat.isVisibleForMe(byPerso.isHost)
            )
            {
                return false;
            }
        }
        return true;
    }

    public bool isWalkable(Perso byPerso) // DONE
    {
        Perso? persoOverCandidat = persoOver();
        Perso? persoCandidat = perso();
        if (byPerso.myCase == null)
            return false;

        if (byPerso.harponne.Count != 0 && face != byPerso.myCase.face)
            return false;

        if (
            byPerso.porte != null
            && byPerso.porte.harponne.Count != 0
            && byPerso.porte.myCase != null
            && face != byPerso.porte.myCase.face
        )
            return false;

        if (byPerso.enVol)
        {
            if (
                persoOverCandidat != null
                || obstacleSpawn != Jeu.SpawnType.none
                || containsTableHost
                || containsTableClient
            )
                return false;
        }
        else if (
            containsSimpleObstacle
            || containsDoubleObstacle
            || invocationSimpleBloquante != null
            || invocationDoubleBloquante != null
            || containsTableHost
            || containsTableClient
            || obstacleSpawn != Jeu.SpawnType.none
            || persoCandidat != null
        )
        {
            return false;
        }
        else
        {
            if (byPerso.porte != null && persoOverCandidat != null)
                return false;
        }
        return true;
    }

    public bool persoLeaveCase(Perso byPerso) // DONE : renvoie true si le perso a quitté un camouflage et est désormais visible
    {
        bool leaveCamouflage =
            containsCamouflage
            && !byPerso.enVol
            && byPerso.invisibilite > 0
            && !byPerso.sousInvisibilite()
            && !byPerso.sousVoileDInvisibilite();

        face.maJEmbrumage();
        byPerso.myCase = null;
        return leaveCamouflage;
    }

    public Jeu.EtatType persoEnterCase(
        Perso byPerso,
        bool leaveCamouflage = false,
        bool crapeauHost = false,
        bool crapeauClient = false,
        bool newFace = false,
        Jeu.DirectionType direction = Jeu.DirectionType.none,
        bool respawn = false
    ) // DONE
    {
        byPerso.myCase = this;
        if (byPerso.porte != null)
            byPerso.porte.myCase = this;

        face.maJEmbrumage();

        if (leaveCamouflage)
        {
            if (containsCamouflage && !byPerso.enVol)
                entreCamouflage(byPerso);
            else
                byPerso.invisibilite = Math.Max(0, byPerso.invisibilite - 1);
        }
        else
        {
            if (containsCamouflage && !byPerso.enVol)
            {
                byPerso.invisibilite++;
                entreCamouflage(byPerso);
            }
        }

        if (byPerso.poudre)
            depotPoudre();

        Piege? piege1 = byPerso.isHost ? piegeClient : piegeHost;
        Piege? piege2 = byPerso.isHost ? piegeHost : piegeClient;

        if (piege1 != null && !byPerso.enVol)
        {
            Jeu.EtatType etatApresPiege = piege1.activer(byPerso);
            if (etatApresPiege != Jeu.EtatType.ok)
                return etatApresPiege;
        }
        if (piege2 != null && !byPerso.enVol)
        {
            Jeu.EtatType etatApresPiege = piege2.activer(byPerso);
            if (etatApresPiege != Jeu.EtatType.ok)
                return etatApresPiege;
        }

        if (newFace)
        {
            if (
                byPerso.porte != null
                && byPerso.porte.isVisibleForMe(!byPerso.isHost, caseDoitEtreOffBrume: true)
            )
                byPerso.porte.activerFlechesPatientes();
            else if (byPerso.isVisibleForMe(!byPerso.isHost, caseDoitEtreOffBrume: true))
            {
                Jeu.EtatType etatApresFlechesPatientes = byPerso.activerFlechesPatientes();
                if (etatApresFlechesPatientes != Jeu.EtatType.ok)
                    return etatApresFlechesPatientes;
            }
        }

        if (leaveCamouflage && byPerso.isVisibleForMe(!byPerso.isHost, caseDoitEtreOffBrume: true))
        {
            Jeu.EtatType etatApresFlechesPatientes = byPerso.activerFlechesPatientes();
            if (etatApresFlechesPatientes != Jeu.EtatType.ok)
                return etatApresFlechesPatientes;
        }


        if (
            containsCaseRappatriementFantomageHost()
            && byPerso.isHost
            && !byPerso.enVol
            && !byPerso.isAncre()
        )
        {
            Jeu.EtatType etatApresRappatriement = byPerso.rappelSpawn();
            if (etatApresRappatriement != Jeu.EtatType.ok)
                return etatApresRappatriement;
        }

        if (
            containsCaseRappatriementFantomageClient()
            && !byPerso.isHost
            && !byPerso.enVol
            && !byPerso.isAncre()
        )
        {
            Jeu.EtatType etatApresRappatriement = byPerso.rappelSpawn();
            if (etatApresRappatriement != Jeu.EtatType.ok)
                return etatApresRappatriement;
        }

        if (
            row != 0
            && (
                face.grid[row - 1, col].containsGraviteFantomageHost
                || face.grid[row - 1, col].containsGraviteFantomageClient
            )
            && !byPerso.enVol
            && !byPerso.isAncre()
            && !respawn
        )
        {
            Jeu.EtatType etatApresGravite = face.grid[row - 1, col].activerGravite(byPerso);
            if (etatApresGravite != Jeu.EtatType.ok)
                return etatApresGravite;
        }

        if (
            row != 7
            && (
                face.grid[row + 1, col].containsGraviteFantomageHost
                || face.grid[row + 1, col].containsGraviteFantomageClient
            )
            && !byPerso.enVol
            && !byPerso.isAncre()
            && !respawn
        )
        {
            Jeu.EtatType etatApresGravite = face.grid[row + 1, col].activerGravite(byPerso);
            if (etatApresGravite != Jeu.EtatType.ok)
                return etatApresGravite;
        }

        if (
            col != 0
            && (
                face.grid[row, col - 1].containsGraviteFantomageHost
                || face.grid[row, col - 1].containsGraviteFantomageClient
            )
            && !byPerso.enVol
            && !byPerso.isAncre()
            && !respawn
        )
        {
            Jeu.EtatType etatApresGravite = face.grid[row, col - 1].activerGravite(byPerso);
            if (etatApresGravite != Jeu.EtatType.ok)
                return etatApresGravite;
        }

        if (
            col != 7
            && (
                face.grid[row, col + 1].containsGraviteFantomageHost
                || face.grid[row, col + 1].containsGraviteFantomageClient
            )
            && !byPerso.enVol
            && !byPerso.isAncre()
            && !respawn
        )
        {
            Jeu.EtatType etatApresGravite = face.grid[row, col + 1].activerGravite(byPerso);
            if (etatApresGravite != Jeu.EtatType.ok)
                return etatApresGravite;
        }

        if (!crapeauHost && !respawn)
        {
            InvocationNonBloquante? crapeau = crapeauAActiver(byPerso, true);
            if (crapeau != null)
            {
                Jeu.EtatType etatApresCrapeau = crapeau.activerCrapeau(byPerso, crapeauHost: true, crapeauClient: crapeauClient);
                if (etatApresCrapeau != Jeu.EtatType.ok)
                    return etatApresCrapeau;
            }
        }
        if (!crapeauClient && !respawn)
        {
            InvocationNonBloquante? crapeau = crapeauAActiver(byPerso, false);
            if (crapeau != null)
            {
                Jeu.EtatType etatApresCrapeau = crapeau.activerCrapeau(byPerso, crapeauHost: crapeauHost, crapeauClient: true);
                if (etatApresCrapeau != Jeu.EtatType.ok)
                    return etatApresCrapeau;
            }
        }
        if (containsTrou && !byPerso.enVol)
            return byPerso.tombeDansTrou();

        if (containsGlissante && !byPerso.enVol && direction != Jeu.DirectionType.none)
        {
            if (!byPerso.isAncre() && byPerso.canMoveDirection(direction))
            {
                return byPerso.moveDirection(
                    direction,
                    glissade: true,
                    crapeauHost: crapeauHost,
                    crapeauClient: crapeauClient
                );
            }
        }
        return Jeu.EtatType.ok;
    }

    public bool accessibleFrom(Case myCase) // DONE : Renvoie si une case est accessible depuis une autre case
    {
        return seemsAccessibleFrom(myCase, true) && seemsAccessibleFrom(myCase, false);
    }

    public bool seemsAccessibleFrom(Case myCase, bool isHost) // DONE : Renvoie si une case semble accessible depuis une autre case pour l'hôte / le client
    {
        if (face != myCase.face)
            return false;

        foreach (Case c in GetLine(face, this, myCase))
        {
            if (
                c.containsSimpleObstacle
                || c.containsDoubleObstacle
                || c.invocationSimpleBloquante != null
                || c.invocationDoubleBloquante != null
                || c.containsTableHost
                || c.containsTableClient
                || c.obstacleSpawn != Jeu.SpawnType.none
            )
            {
                return false;
            }
            Perso? persoCandidat = c.perso();
            if (persoCandidat != null)
            {
                if (persoCandidat.isHost == isHost)
                {
                    return false;
                }
                else if (persoCandidat.isVisibleForMe(isHost))
                {
                    return false;
                }
                {
                    return false;
                }
            }
        }
        return true;
    }

    public int distance(Case myCase) // DONE : Renvoie la distance entre deux cases
    {
        return Math.Abs(row - myCase.row) + Math.Abs(col - myCase.col);
    }

    public bool isAlignedWith(Case myCase) // DONE : Renvoie si deux cases sont alignées
    {
        return row == myCase.row || col == myCase.col;
    }

    public InvocationSimpleBloquante? containsGrossePotion() // DONE
    {
        if (
            invocationSimpleBloquante != null
            && invocationSimpleBloquante.type == Jeu.InvocationType.GrossePotion
        )
        {
            return invocationSimpleBloquante;
        }
        else
        {
            return null;
        }
    }

    public InvocationDoubleBloquante? containsCarosse() // DONE
    {
        if (
            invocationDoubleBloquante != null
            && invocationDoubleBloquante.type == Jeu.InvocationType.Carosse
        )
        {
            return invocationDoubleBloquante;
        }
        else
        {
            return null;
        }
    }

    public Perso? elfeeEnVol() // DONE
    {
        if (Jeu.elfeeClient.enVol && Jeu.elfeeClient.myCase == this)
        {
            return Jeu.elfeeClient;
        }
        else if (Jeu.elfeeHost.enVol && Jeu.elfeeHost.myCase == this)
        {
            return Jeu.elfeeHost;
        }
        else
        {
            return null;
        }
    }

    public Perso? perso() // DONE
    {
        foreach (Perso myPerso in Jeu.Persos())
        {
            if (myPerso.myCase == this && !myPerso.isover())
            {
                return myPerso;
            }
        }
        return null;
    }

    public Perso? persoOver() // DONE
    {
        Perso? res = null;
        foreach (Perso myPerso in Jeu.Persos())
        {
            if (myPerso.myCase == this && (myPerso.estPortePar != null || myPerso.enVol))
            {
                res = myPerso;
            }
        }
        return res;
    }

    public bool containsCaseRappatriementFantomageHost() // DONE
    {
        if (
            Jeu.fantomageHost.attaques.ContainsKey(Features.AttaqueType.caseDeRapatriement)
            && (
                (CaseDeRapatriement)Jeu.fantomageHost.attaques[Features.AttaqueType.caseDeRapatriement]
            ).getCase() == this
        )
        {
            return true;
        }
        return false;
    }

    public bool containsCaseRappatriementFantomageClient() // DONE
    {
        if (
            Jeu.fantomageClient.attaques.ContainsKey(Features.AttaqueType.caseDeRapatriement)
            && (
                (CaseDeRapatriement)Jeu.fantomageClient.attaques[Features.AttaqueType.caseDeRapatriement]
            ).getCase() == this
        )
        {
            return true;
        }
        return false;
    }

    public bool containsCaseRappatriement() // DONE
    {
        return containsCaseRappatriementFantomageHost()
            || containsCaseRappatriementFantomageClient();
    }

    public void detruireCasesRappatriement() // DONE
    {
        if (containsCaseRappatriementFantomageHost())
        {
            (
                (CaseDeRapatriement)Jeu.fantomageHost.attaques[Features.AttaqueType.caseDeRapatriement]
            ).detruire();
        }
        if (containsCaseRappatriementFantomageClient())
        {
            (
                (CaseDeRapatriement)Jeu.fantomageClient.attaques[Features.AttaqueType.caseDeRapatriement]
            ).detruire();
        }
    }

    public List<InvocationNonBloquante> invocationsNonBloquantes() // DONE
    {
        List<InvocationNonBloquante> res = new List<InvocationNonBloquante>();
        foreach (InvocationNonBloquante candidate in Jeu.GetInvocationsNonBloquantes())
        {
            if (candidate.myCase == this)
            {
                res.Add(candidate);
            }
        }
        return res;
    }

    public List<InvocationNonBloquante> getBombes() // DONE
    {
        List<InvocationNonBloquante> res = new List<InvocationNonBloquante>();
        foreach (InvocationNonBloquante candidate in invocationsNonBloquantes())
        {
            if (candidate.type == Jeu.InvocationType.Bombe)
            {
                res.Add(candidate);
            }
        }
        return res;
    }

    public bool containsTPRoninjaHost() // DONE
    {
        return (
            Jeu.roninjaHost.attaques.ContainsKey(Features.AttaqueType.memoire)
            && ((Memoire)Jeu.roninjaHost.attaques[Features.AttaqueType.memoire]).getTp() == this
        );
    }

    public bool containsTPRoninjaClient() // DONE
    {
        return (
            Jeu.roninjaClient.attaques.ContainsKey(Features.AttaqueType.memoire)
            && ((Memoire)Jeu.roninjaClient.attaques[Features.AttaqueType.memoire]).getTp() == this
        );
    }

    public bool containsTPRoninja() // DONE
    {
        return containsTPRoninjaHost() || containsTPRoninjaClient();
    }

    public void detruireTPsRoninja() // DONE
    {
        if (containsTPRoninjaHost())
        {
            ((Memoire)Jeu.roninjaHost.attaques[Features.AttaqueType.memoire]).detruire();
        }
        if (containsTPRoninjaClient())
        {
            ((Memoire)Jeu.roninjaClient.attaques[Features.AttaqueType.memoire]).detruire();
        }
    }

    public IEnumerable<Case> GetLine(Face face, Case start, Case end, bool reverse = false) // DONE : Renvoie une liste de cases entre deux cases
    {
        int dx = Math.Abs(end.col - start.col);
        int dy = Math.Abs(end.row - start.row);

        int sx = start.col < end.col ? 1 : -1;
        int sy = start.row < end.row ? 1 : -1;

        int err = dx - dy;

        int x = start.col;
        int y = start.row;

        while (true)
        {
            if (start != face.grid[y, x] && end != face.grid[y, x])
            {
                yield return face.grid[y, x];
            }

            if (x == end.col && y == end.row)
                break;

            int e2 = 2 * err;
            if (e2 > -dy)
            {
                err -= dy;
                x += sx;
            }
            if (e2 < dx)
            {
                err += dx;
                y += sy;
            }
        }
        if (!reverse)
        {
            foreach (Case c in GetLine(face, end, start, true))
            {
                yield return c;
            }
        }
    }

    public List<Pierre> getContainsPierre() // DONE
    {
        List<Pierre>? res = new List<Pierre>();
        if (Jeu.pierrelumierehost.myCases.Contains(this))
        {
            res.Add(Jeu.pierrelumierehost);
        }
        if (Jeu.pierrelumiereclient.myCases.Contains(this))
        {
            res.Add(Jeu.pierrelumiereclient);
        }
        if (Jeu.pierreombrehost.myCases.Contains(this))
        {
            res.Add(Jeu.pierreombrehost);
        }
        if (Jeu.pierreombreclient.myCases.Contains(this))
        {
            res.Add(Jeu.pierreombreclient);
        }
        return res;
    }

    public Pierre? getContainsPierre(bool isHost) // DONE
    {
        Pierre? res = null;
        if (isHost)
        {
            if (Jeu.pierrelumierehost.myCases.Contains(this))
            {
                res = Jeu.pierrelumierehost;
            }
            if (Jeu.pierreombrehost.myCases.Contains(this))
            {
                res = Jeu.pierreombrehost;
            }
        }
        else
        {
            if (Jeu.pierrelumiereclient.myCases.Contains(this))
            {
                res = Jeu.pierrelumiereclient;
            }
            if (Jeu.pierreombreclient.myCases.Contains(this))
            {
                res = Jeu.pierreombreclient;
            }
        }
        return res;
    }

    public void addPierre(Pierre pierre, bool retourTable = false) // DONE
    {
        if (retourTable)
            pierre.myCases.Add(this);
        else if ((containsTableHost && pierre.isHost) || (containsTableClient && !pierre.isHost))
            Jeu.PierreToTable(pierre);
        else if ((containsTableHost && !pierre.isHost) || (containsTableClient && pierre.isHost))
            Jeu.EncaissePierre(pierre);
        else
            pierre.myCases.Add(this);
    }

    public bool pierreAddable() // DONE
    {
        return !containsSimpleObstacle
            && !containsDoubleObstacle
            && (obstacleSpawn != Jeu.SpawnType.none)
            && !containsTableHost
            && !containsTableClient;
    }

    public void tryToAddAround(Pierre pierre) // DONE
    {
        List<Case> candidates = getVoisins();
        foreach (Case c in candidates)
        {
            if (face == c.face && c.pierreAddable())
            {
                c.addPierre(pierre);
                return;
            }
        }
        Jeu.PierreToTable(pierre);
    }

    public void removePierre(Pierre pierre) // DONE
    {
        pierre.myCases.Clear();
    }

    public List<Case> casesAPortee(int porteeMin, int porteeMax) // DONE : Renvoie les cases à portée d'une case
    {
        List<Case> res = new List<Case>();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Case c = face.grid[i, j];
                if (c.distance(this) >= porteeMin && c.distance(this) <= porteeMax)
                {
                    res.Add(c);
                }
            }
        }
        return res;
    }

    public Case getDeuxiemeCaseDoubleObstacle() // DONE : Renvoie la deuxième case d'un double obstacle
    {
        if (containsDoubleObstacle)
        {
            switch (orientationDoubleObstacle)
            {
                case Jeu.DirectionType.Up:
                    return face.grid[row + 1, col];
                case Jeu.DirectionType.Down:
                    return face.grid[row - 1, col];
                case Jeu.DirectionType.Left:
                    return face.grid[row, col + 1];
                case Jeu.DirectionType.Right:
                    return face.grid[row, col - 1];
                default:
                    return this;
            }
        }
        else
        {
            return this;
        }
    }

    public Case nextCaseDirection(Jeu.DirectionType direction) // DONE
    {
        switch (direction)
        {
            case Jeu.DirectionType.Up:
                if (row == 0)
                {
                    switch (face.name)
                    {
                        case Jeu.FaceType.North:
                            return Jeu.client.grid[0, 7 - col];
                        case Jeu.FaceType.South:
                            return Jeu.client.grid[7, col];
                        case Jeu.FaceType.East:
                            return Jeu.client.grid[col, 0];
                        case Jeu.FaceType.West:
                            return Jeu.client.grid[7 - col, 7];
                        case Jeu.FaceType.Host:
                            return Jeu.north.grid[7, col];
                        case Jeu.FaceType.Client:
                            return Jeu.north.grid[0, 7 - col];
                        default:
                            return this;
                    }
                }
                else
                {
                    return face.grid[row - 1, col];
                }
            case Jeu.DirectionType.Down:
                if (row == 7)
                {
                    switch (face.name)
                    {
                        case Jeu.FaceType.North:
                            return Jeu.host.grid[0, col];
                        case Jeu.FaceType.South:
                            return Jeu.host.grid[7, 7 - col];
                        case Jeu.FaceType.East:
                            return Jeu.host.grid[col, 7];
                        case Jeu.FaceType.West:
                            return Jeu.host.grid[0, 7 - col];
                        case Jeu.FaceType.Host:
                            return Jeu.south.grid[7, 7 - col];
                        case Jeu.FaceType.Client:
                            return Jeu.south.grid[0, col];
                        default:
                            return this;
                    }
                }
                else
                {
                    return face.grid[row + 1, col];
                }
            case Jeu.DirectionType.Left:
                if (col == 0)
                {
                    switch (face.name)
                    {
                        case Jeu.FaceType.North:
                            return Jeu.west.grid[row, 7];
                        case Jeu.FaceType.South:
                            return Jeu.east.grid[row, 7];
                        case Jeu.FaceType.East:
                            return Jeu.north.grid[row, 7];
                        case Jeu.FaceType.West:
                            return Jeu.south.grid[row, 7];
                        case Jeu.FaceType.Host:
                            return Jeu.west.grid[7, 7 - row];
                        case Jeu.FaceType.Client:
                            return Jeu.east.grid[0, row];
                        default:
                            return this;
                    }
                }
                else
                {
                    return face.grid[row, col - 1];
                }
            case Jeu.DirectionType.Right:
                if (col == 7)
                {
                    switch (face.name)
                    {
                        case Jeu.FaceType.North:
                            return Jeu.east.grid[row, 0];
                        case Jeu.FaceType.South:
                            return Jeu.west.grid[row, 0];
                        case Jeu.FaceType.East:
                            return Jeu.south.grid[row, 0];
                        case Jeu.FaceType.West:
                            return Jeu.north.grid[row, 0];
                        case Jeu.FaceType.Host:
                            return Jeu.east.grid[7, row];
                        case Jeu.FaceType.Client:
                            return Jeu.west.grid[0, 7 - row];
                        default:
                            return this;
                    }
                }
                else
                {
                    return face.grid[row, col + 1];
                }
            default:
                return this;
        }
    }

    public List<Case> getVoisins() // DONE : Renvoie les cases voisines d'une case
    {
        return new List<Case>()
        {
            nextCaseDirection(Jeu.DirectionType.Up),
            nextCaseDirection(Jeu.DirectionType.Down),
            nextCaseDirection(Jeu.DirectionType.Left),
            nextCaseDirection(Jeu.DirectionType.Right),
        };
    }

    public void destroyObstacle() // DONE
    {
        if (containsSimpleObstacle)
        {
            containsSimpleObstacle = false;
        }
        else if (containsDoubleObstacle)
        {
            containsDoubleObstacle = false;
            getDeuxiemeCaseDoubleObstacle().containsDoubleObstacle = false;
        }
    }

    public bool isVisibleForMe(bool isHostPlayerWatching) // DONE
    {
        bool isBrume = isHostPlayerWatching ? containsBrumeRoninjaClient : containsBrumeRoninjaHost;
        return face.faceVisible(isHostPlayerWatching) && !isBrume;
    }

    public Jeu.DirectionType directionTo(Case myCase, bool directionInverse = false) // DONE
    {
        if (row == myCase.row)
        {
            if (col < myCase.col)
                return directionInverse ? Jeu.DirectionType.Left : Jeu.DirectionType.Right;
            else
                return directionInverse ? Jeu.DirectionType.Right : Jeu.DirectionType.Left;
        }
        else
        {
            if (row < myCase.row)
                return directionInverse ? Jeu.DirectionType.Up : Jeu.DirectionType.Down;
            else
                return directionInverse ? Jeu.DirectionType.Down : Jeu.DirectionType.Up;
        }
    }

    public Jeu.EtatType activerGravite(Perso p)
    {
        if (p.myCase == null)
            return Jeu.EtatType.ko;

        Jeu.DirectionType direction = p.myCase.directionTo(this);
        if (p.canMoveDirection(direction))
        {
            containsGraviteFantomageHost = false;
            containsGraviteFantomageClient = false;
            return p.moveDirection(direction, gravite: true);
        }
        return Jeu.EtatType.ok;
    }

    // Méthodes private

    private InvocationNonBloquante? crapeauAActiver(Perso byPerso, bool crapeauHost) // DONE : Renvoie le crapeau invoqué par le fantomage si le perso est sur la case
    {
        Perso? fantomageCrapeau = crapeauHost ? Jeu.fantomageHost : Jeu.fantomageClient;
        if (!fantomageCrapeau.entitesInvoquees().ContainsKey(Jeu.InvocationType.Crapeau))
            return null;
        else
        {
            InvocationNonBloquante crapeau = fantomageCrapeau.entitesInvoquees()[
                Jeu.InvocationType.Crapeau
            ];
            if (
                byPerso.myCase != null
                && crapeau.myCase.face == byPerso.myCase.face
                && isAlignedWith(crapeau.myCase)
                && distance(crapeau.myCase) >= 1
                && crapeau.myCase.seemsAccessibleFrom(byPerso.myCase, crapeau.isHost)
            )
                return crapeau;

            return null;
        }
    }

    private void entreCamouflage(Perso byPerso) // DONE
    {

    }

    private void depotPoudre() // DONE
    {
        containsPoudre = true;
    }

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ POUR DEBOGAGE ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public String toString() // DONE
    {
        Perso? persoCandidat = perso();
        if (persoCandidat != null)
        {
            return persoCandidat.type.ToString();
        }
        else if (containsSimpleObstacle)
        {
            return "□";
        }
        else if (containsDoubleObstacle)
        {
            return "□";
        }
        else if (containsTrou)
        {
            return "○";
        }
        else if (containsCamouflage)
        {
            return "?";
        }
        else if (containsGlissante)
        {
            return "s";
        }
        else if (containsTableClient || containsTableHost)
        {
            return "T";
        }
        else if (obstacleSpawn != Jeu.SpawnType.none)
        {
            return "X";
        }
        else
        {
            return " ";
        }
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ POUR DEBOGAGE ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
}
