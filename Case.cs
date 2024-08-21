public class Case
{
    // Attributs // DONE
    public bool containsSimpleObstacle { get; set; }
    public bool containsDoubleObstacle { get; set; }
    public string orientationDoubleObstacle { get; set; }
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
    public string obstacleSpawn { get; set; } // "Roninja" ou "Fantomage" ou "Elfee" ou "Piratitan"
    public Face face { get; set; }
    public int row { get; set; }
    public int col { get; set; }

    // Constructeur // DONE
    public Case(string type, Face face, int row, int col)
    {
        containsSimpleObstacle = false;
        containsDoubleObstacle = false;
        orientationDoubleObstacle = "";
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
        obstacleSpawn = "";
        this.face = face;
        this.row = row;
        this.col = col;

        switch (type)
        {
            case "Vide":
                break;
            case "SimpleObstacle":
                containsSimpleObstacle = true;
                break;
            case "Table":
                if (face.name == "Host")
                    containsTableHost = true;
                else
                    containsTableClient = true;
                break;
            case "DoubleObstacleHaut":
                containsDoubleObstacle = true;
                orientationDoubleObstacle = "Haut";
                break;
            case "DoubleObstacleBas":
                containsDoubleObstacle = true;
                orientationDoubleObstacle = "Bas";
                break;
            case "DoubleObstacleGauche":
                containsDoubleObstacle = true;
                orientationDoubleObstacle = "Gauche";
                break;
            case "DoubleObstacleDroite":
                containsDoubleObstacle = true;
                orientationDoubleObstacle = "Droite";
                break;
            case "Trou":
                containsTrou = true;
                break;
            case "Camouflage":
                containsCamouflage = true;
                break;
            case "Glissante":
                containsGlissante = true;
                break;
            default:
                obstacleSpawn = type;
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
                || obstacleSpawn != ""
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
            || obstacleSpawn != ""
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
                || obstacleSpawn != ""
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
            || obstacleSpawn != ""
            || persoCandidat != null
        )
        {
            return false;
        }
        else
        {
            if (byPerso.porte != null && persoOverCandidat != null)
            {
                return false;
            }
        }
        return true;
    }

    public void persoLeaveCase(Perso byPerso) // DONE
    {
        if (containsCamouflage && !byPerso.enVol)
        {
            quitteCamouflage(byPerso);
        }

        if (face.brumeHost && byPerso.isHost)
        {
            face.maJEmbrumage(true);
        }
        else if (face.brumeClient && !byPerso.isHost)
        {
            face.maJEmbrumage(false);
        }

        byPerso.myCase = null;
    }

    public void persoEnterCase(
        Perso byPerso,
        bool crapeauHost = false,
        bool crapeauClient = false,
        bool newFace = false,
        string? direction = null,
        bool respawn = false
    ) // DONE
    {
        byPerso.myCase = this;
        if (byPerso.porte != null)
            byPerso.porte.myCase = this;

        if (containsCamouflage && !byPerso.enVol)
            entreCamouflage(byPerso);

        if (face.brumeHost && byPerso.isHost)
            face.maJEmbrumage(true);
        else if (face.brumeClient && !byPerso.isHost)
            face.maJEmbrumage(false);

        if (
            byPerso.isVisibleForMe(
                !byPerso.isHost,
                faceDoitEtreVisible: true,
                caseDoitEtreOffBrume: true
            )
        )
            byPerso.temoinDePosition = null;

        if (byPerso.poudre)
            depotPoudre();

        if (piegeHost != null && !byPerso.enVol)
            piegeHost.activer(byPerso);

        if (piegeClient != null && !byPerso.enVol)
            piegeClient.activer(byPerso);

        if (face.flechesPatientesHost > 0 && !byPerso.isHost && newFace)
        {
            if (
                byPerso.porte != null
                && byPerso.porte.isVisibleForMe(true, caseDoitEtreOffBrume: true)
            )
                byPerso.porte.activerFlechesPatientes();
            else if (byPerso.isVisibleForMe(true, caseDoitEtreOffBrume: true))
                byPerso.activerFlechesPatientes();
        }
        else if (face.flechesPatientesClient > 0 && byPerso.isHost && newFace)
        {
            if (
                byPerso.porte != null
                && byPerso.porte.isVisibleForMe(false, caseDoitEtreOffBrume: true)
            )
                byPerso.porte.activerFlechesPatientes();
            else if (byPerso.isVisibleForMe(false, caseDoitEtreOffBrume: true))
                byPerso.activerFlechesPatientes();
        }

        if (
            containsCaseRappatriementFantomageHost()
            && byPerso.isHost
            && !byPerso.enVol
            && !byPerso.getAncre()
        )
        {
            ((CaseDeRapatriement)Jeu.fantomageHost.attaques["CaseDeRapatriement"]).activer(byPerso);
        }

        if (
            containsCaseRappatriementFantomageClient()
            && !byPerso.isHost
            && !byPerso.enVol
            && !byPerso.getAncre()
        )
        {
            ((CaseDeRapatriement)Jeu.fantomageClient.attaques["CaseDeRapatriement"]).activer(
                byPerso
            );
        }

        if (
            row != 0
            && (
                face.grid[row - 1, col].containsGraviteFantomageHost
                || face.grid[row - 1, col].containsGraviteFantomageClient
            )
            && !byPerso.enVol
            && !byPerso.getAncre()
            && !respawn
        )
        {
            Gravite.activer(byPerso, face.grid[row - 1, col]);
        }

        if (
            row != 7
            && (
                face.grid[row + 1, col].containsGraviteFantomageHost
                || face.grid[row + 1, col].containsGraviteFantomageClient
            )
            && !byPerso.enVol
            && !byPerso.getAncre()
            && !respawn
        )
        {
            Gravite.activer(byPerso, face.grid[row + 1, col]);
        }

        if (
            col != 0
            && (
                face.grid[row, col - 1].containsGraviteFantomageHost
                || face.grid[row, col - 1].containsGraviteFantomageClient
            )
            && !byPerso.enVol
            && !byPerso.getAncre()
            && !respawn
        )
        {
            Gravite.activer(byPerso, face.grid[row, col - 1]);
        }

        if (
            col != 7
            && (
                face.grid[row, col + 1].containsGraviteFantomageHost
                || face.grid[row, col + 1].containsGraviteFantomageClient
            )
            && !byPerso.enVol
            && !byPerso.getAncre()
            && !respawn
        )
        {
            Gravite.activer(byPerso, face.grid[row, col + 1]);
        }

        if (!crapeauHost && !respawn)
        {
            InvocationNonBloquante? crapeau = activerCrapeau(byPerso, true);
            if (crapeau != null)
            {
                crapeau.activer(byPerso);
            }
        }
        if (!crapeauClient && !respawn)
        {
            InvocationNonBloquante? crapeau = activerCrapeau(byPerso, false);
            if (crapeau != null)
            {
                crapeau.activer(byPerso);
            }
        }
        if (containsTrou && !byPerso.enVol)
        {
            byPerso.tombeDansTrou();
        }
        if (containsGlissante && !byPerso.enVol && direction != null)
        {
            if (!byPerso.getAncre() && byPerso.canMoveDirection(direction))
            {
                byPerso.moveDirection(direction, glissade: true);
            }
        }
    }

    public bool accessibleFrom(Case myCase) // DONE : Renvoie si une case est accessible depuis une autre case
    {
        return seemsAccessibleFrom(myCase, true) && seemsAccessibleFrom(myCase, false);
    }

    public bool seemsAccessibleFrom(Case myCase, bool isHost) // DONE : Renvoie si une case semble accessible depuis une autre case pour l'hôte / le client
    {
        if (face != myCase.face)
        {
            return false;
        }
        foreach (Case c in GetLine(face, this, myCase))
        {
            if (
                c.containsSimpleObstacle
                || c.containsDoubleObstacle
                || c.invocationSimpleBloquante != null
                || c.invocationDoubleBloquante != null
                || c.containsTableHost
                || c.containsTableClient
                || c.obstacleSpawn != ""
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
        if (invocationSimpleBloquante != null && invocationSimpleBloquante.type == "GrossePotion")
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
        if (invocationDoubleBloquante != null && invocationDoubleBloquante.type == "Carosse")
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
            if (myPerso.myCase == this && myPerso.enVol == false && myPerso.estPortePar() == null)
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
            Jeu.fantomageHost.attaques.ContainsKey("CaseDeRapatriement")
            && ((CaseDeRapatriement)Jeu.fantomageHost.attaques["CaseDeRapatriement"]).getCase()
                == this
        )
        {
            return true;
        }
        return false;
    }

    public bool containsCaseRappatriementFantomageClient() // DONE
    {
        if (
            Jeu.fantomageClient.attaques.ContainsKey("CaseDeRapatriement")
            && ((CaseDeRapatriement)Jeu.fantomageClient.attaques["CaseDeRapatriement"]).getCase()
                == this
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
            ((CaseDeRapatriement)Jeu.fantomageHost.attaques["CaseDeRapatriement"]).detruire();
        }
        if (containsCaseRappatriementFantomageClient())
        {
            ((CaseDeRapatriement)Jeu.fantomageClient.attaques["CaseDeRapatriement"]).detruire();
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
            if (candidate.type == "Bombe")
            {
                res.Add(candidate);
            }
        }
        return res;
    }

    public bool containsTPRoninjaHost() // DONE
    {
        return (
            Jeu.roninjaHost.attaques.ContainsKey("Memoire")
            && ((Memoire)Jeu.roninjaHost.attaques["Memoire"]).getTp() == this
        );
    }

    public bool containsTPRoninjaClient() // DONE
    {
        return (
            Jeu.roninjaClient.attaques.ContainsKey("Memoire")
            && ((Memoire)Jeu.roninjaClient.attaques["Memoire"]).getTp() == this
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
            ((Memoire)Jeu.roninjaHost.attaques["Memoire"]).detruire();
        }
        if (containsTPRoninjaClient())
        {
            ((Memoire)Jeu.roninjaClient.attaques["Memoire"]).detruire();
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
                case "Haut":
                    return face.grid[row + 1, col];
                case "Bas":
                    return face.grid[row - 1, col];
                case "Gauche":
                    return face.grid[row, col + 1];
                case "Droite":
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

    public Case nextCaseDirection(string direction) // DONE
    {
        switch (direction)
        {
            case "up":
                if (row == 0)
                {
                    switch (face.name)
                    {
                        case "north":
                            return Jeu.client.grid[0, 7 - col];
                        case "south":
                            return Jeu.client.grid[7, col];
                        case "east":
                            return Jeu.client.grid[col, 0];
                        case "west":
                            return Jeu.client.grid[7 - col, 7];
                        case "host":
                            return Jeu.north.grid[7, col];
                        case "client":
                            return Jeu.north.grid[0, 7 - col];
                        default:
                            return this;
                    }
                }
                else
                {
                    return face.grid[row - 1, col];
                }
            case "down":
                if (row == 7)
                {
                    switch (face.name)
                    {
                        case "north":
                            return Jeu.host.grid[0, col];
                        case "south":
                            return Jeu.host.grid[7, 7 - col];
                        case "east":
                            return Jeu.host.grid[col, 7];
                        case "west":
                            return Jeu.host.grid[0, 7 - col];
                        case "host":
                            return Jeu.south.grid[7, 7 - col];
                        case "client":
                            return Jeu.south.grid[0, col];
                        default:
                            return this;
                    }
                }
                else
                {
                    return face.grid[row + 1, col];
                }
            case "left":
                if (col == 0)
                {
                    switch (face.name)
                    {
                        case "north":
                            return Jeu.west.grid[row, 7];
                        case "south":
                            return Jeu.east.grid[row, 7];
                        case "east":
                            return Jeu.north.grid[row, 7];
                        case "west":
                            return Jeu.south.grid[row, 7];
                        case "host":
                            return Jeu.west.grid[7, 7 - row];
                        case "client":
                            return Jeu.east.grid[0, row];
                        default:
                            return this;
                    }
                }
                else
                {
                    return face.grid[row, col - 1];
                }
            case "right":
                if (col == 7)
                {
                    switch (face.name)
                    {
                        case "north":
                            return Jeu.east.grid[row, 0];
                        case "south":
                            return Jeu.west.grid[row, 0];
                        case "east":
                            return Jeu.south.grid[row, 0];
                        case "west":
                            return Jeu.north.grid[row, 0];
                        case "host":
                            return Jeu.east.grid[7, row];
                        case "client":
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
            nextCaseDirection("up"),
            nextCaseDirection("down"),
            nextCaseDirection("left"),
            nextCaseDirection("right")
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

    // Méthodes private

    private InvocationNonBloquante? activerCrapeau(Perso byPerso, bool crapeauHost) // DONE : Renvoie le crapeau invoqué par le fantomage si le perso est sur la case
    {
        Perso? fantomageCrapeau = crapeauHost ? Jeu.fantomageHost : Jeu.fantomageClient;
        if (
            (byPerso.type == "Fantomage" && byPerso.isHost == crapeauHost)
            || !fantomageCrapeau.entitesInvoquees().ContainsKey("Crapeau")
        )
        {
            return null;
        }
        else
        {
            InvocationNonBloquante crapeau = fantomageCrapeau.entitesInvoquees()["Crapeau"];
            if (
                byPerso.myCase != null
                && crapeau.myCase.face == byPerso.myCase.face
                && (crapeau.myCase.row == row || crapeau.myCase.col == col)
                && (
                    Math.Abs(crapeau.myCase.row - byPerso.myCase.row) >= 2
                    || Math.Abs(crapeau.myCase.col - byPerso.myCase.col) >= 2
                )
                && crapeau.myCase.seemsAccessibleFrom(byPerso.myCase, crapeau.isHost)
            )
            {
                return crapeau;
            }
            return null;
        }
    }

    private void quitteCamouflage(Perso byPerso) // DONE
    {
        byPerso.invisibilite = Math.Max(0, byPerso.invisibilite - 1);
        if (byPerso.invisibilite == 0)
            byPerso.reveal();
    }

    private void entreCamouflage(Perso byPerso) // DONE
    {
        byPerso.invisibilite++;
        if (byPerso.porte != null)
        {
            byPerso.porte.invisibilite++;
        }
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
            return persoCandidat.isHost
                ? persoCandidat.type.Substring(0, 1).ToUpper()
                : persoCandidat.type.Substring(0, 1).ToLower();
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
        else if (obstacleSpawn != "")
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
