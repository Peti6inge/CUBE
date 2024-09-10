using System.Security.Cryptography;
using System.Text;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

class Tests
{
    private static IAmazonDynamoDB? dynamoDBClient;
    private static string c = "AKIAQKPILYLME7VMUU6F";
    private static string cs = "fkT1A+kfBdaAMeIkqyAfpn5HS+JZol+4ISHPs99I";

    private static string pseudo = "";
    private static string username = "";
    private static int score;
    private static Dictionary<Enum, bool> attaquesRoninja = new Dictionary<Enum, bool>
        {
            { Jeu.AttaqueType.acide, false },
            { Jeu.AttaqueType.attire, false },
            { Jeu.AttaqueType.brume, false },
            { Jeu.AttaqueType.clone, false },
            { Jeu.AttaqueType.couteauDeLancee, false },
            { Jeu.AttaqueType.derobadeDeLOmbre, false },
            { Jeu.AttaqueType.derobade, false },
            { Jeu.AttaqueType.entrave, false },
            { Jeu.AttaqueType.feinte, false },
            { Jeu.AttaqueType.invisibilite, true },
            { Jeu.AttaqueType.katana, false },
            { Jeu.AttaqueType.kunai, false },
            { Jeu.AttaqueType.memoire, false },
            { Jeu.AttaqueType.piegeALoup, true },
            { Jeu.AttaqueType.piegeLineaire, false },
            { Jeu.AttaqueType.pirouette, false },
            { Jeu.AttaqueType.poison, true },
            { Jeu.AttaqueType.repousse, false },
            { Jeu.AttaqueType.teleport, false }
        };
    private static Dictionary<Enum, bool> attaquesPiratitan = new Dictionary<Enum, bool>
        {
            { Jeu.AttaqueType.ancre, false},
            { Jeu.AttaqueType.bombe, true},
            { Jeu.AttaqueType.bondDuTitan, false},
            { Jeu.AttaqueType.chargeDuTitan, false},
            { Jeu.AttaqueType.coffre, false},
            { Jeu.AttaqueType.coupDeFeu, false},
            { Jeu.AttaqueType.etincelle, true},
            { Jeu.AttaqueType.flaque, false},
            { Jeu.AttaqueType.frappeDuPirate, false},
            { Jeu.AttaqueType.frappeDuTitan, false},
            { Jeu.AttaqueType.harpon, false},
            { Jeu.AttaqueType.invincibilite, false},
            { Jeu.AttaqueType.longueVue, false},
            { Jeu.AttaqueType.mouette, false},
            { Jeu.AttaqueType.planche, false},
            { Jeu.AttaqueType.porterDeposer, false},
            { Jeu.AttaqueType.poudre, true},
            { Jeu.AttaqueType.sabre, false},
            { Jeu.AttaqueType.tonneau, false}
        };
    private static Dictionary<Enum, bool> attaquesFantomage = new Dictionary<Enum, bool>
        {
            { Jeu.AttaqueType.bouleDeFeu, false},
            { Jeu.AttaqueType.bouletFantomatique, false},
            { Jeu.AttaqueType.buff, true},
            { Jeu.AttaqueType.caseDeRapatriement, false},
            { Jeu.AttaqueType.caseTerrifiante, false},
            { Jeu.AttaqueType.clairvoyance, false},
            { Jeu.AttaqueType.coupDeBaton, false},
            { Jeu.AttaqueType.crapeau, true},
            { Jeu.AttaqueType.eauVaseuse, false},
            { Jeu.AttaqueType.feuFollet, false},
            { Jeu.AttaqueType.gravite, false},
            { Jeu.AttaqueType.inversion, false},
            { Jeu.AttaqueType.jouvence, false},
            { Jeu.AttaqueType.mainsMaudites, false},
            { Jeu.AttaqueType.malediction, false},
            { Jeu.AttaqueType.rappel, false},
            { Jeu.AttaqueType.sortDeProtection, false},
            { Jeu.AttaqueType.transposition, true},
            { Jeu.AttaqueType.voileDInvisibilite, false}
        };
    private static Dictionary<Enum, bool> attaquesElfee = new Dictionary<Enum, bool>
        {
            { Jeu.AttaqueType.altruisme, false},
            { Jeu.AttaqueType.carosse, false},
            { Jeu.AttaqueType.coupDeBaguette, false},
            { Jeu.AttaqueType.derniereVolontee, false},
            { Jeu.AttaqueType.elixirAgressif, false},
            { Jeu.AttaqueType.envolAtterissage, true},
            { Jeu.AttaqueType.espritElfique, false},
            { Jeu.AttaqueType.esquive, false},
            { Jeu.AttaqueType.fleche, false},
            { Jeu.AttaqueType.flecheDeLumiere, false},
            { Jeu.AttaqueType.flechePatiente, false},
            { Jeu.AttaqueType.hautesHerbes, false},
            { Jeu.AttaqueType.miniaturisation, false},
            { Jeu.AttaqueType.petitSoin, false},
            { Jeu.AttaqueType.poudreBienfaisante, false},
            { Jeu.AttaqueType.poudreSoporifique, true},
            { Jeu.AttaqueType.poudreStimulante, true},
            { Jeu.AttaqueType.reanimation, false},
            { Jeu.AttaqueType.soinTotal, false}
        };
    private static Dictionary<Enum, bool> skinsRoninja = new Dictionary<Enum, bool>
        {
            { Jeu.SkinType.roninjaBasique, true}
        };
    private static Dictionary<Enum, bool> skinsPiratitan = new Dictionary<Enum, bool>
        {
            { Jeu.SkinType.piratitanBasique, true}
        };
    private static Dictionary<Enum, bool> skinsFantomage = new Dictionary<Enum, bool>
        {
            { Jeu.SkinType.fantomageBasique, true}
        };
    private static Dictionary<Enum, bool> skinsElfee = new Dictionary<Enum, bool>
        {
            { Jeu.SkinType.elfeeBasique, true}
        };

    public static async Task Main()
    {
        // Console.WriteLine("On essaie de créer un joueur qui existe déjà");
        // await createJoueur("admin", "password");

        // Console.WriteLine("\nOn essaie de créer un joueur qui n'existe pas");
        // await createJoueur("pseudo", "password");
        // afficherDonneesJoueur();

        // Console.WriteLine("\nOn essaie de se connecter avec un mauvais login");
        // await connectJoueur("wrongUsername", "password");

        // Console.WriteLine("\nOn essaie de se connecter avec un mauvais mot de passe");
        // await connectJoueur("pseudo", "wrongPassword");

        // Console.WriteLine("\nOn essaie de se connecter avec un bon login et un bon mot de passe");
        // await connectJoueur("pseudo", "password");
        // afficherDonneesJoueur();

        // Console.WriteLine("\nOn essaie de mettre à jour les données du joueur");
        // username = "pseudo@password";
        // score = 1000;
        // attaquesRoninja[Jeu.AttaqueType.acide] = true;
        // await updateJoueur();
        // afficherDonneesJoueur();

        Console.WriteLine("\nOn essaie de se connecter avec un bon login et un bon mot de passe");
        await connectJoueur("pseudo", "password");
        afficherDonneesJoueur();
    }

    public static void afficherDonneesJoueur()
    {
        Console.WriteLine("Les données du joueur test sont :");
        Console.WriteLine("Pseudo : " + pseudo);
        Console.WriteLine("Username : " + username);
        Console.WriteLine("Score : " + score);
        foreach (Jeu.AttaqueType attaque in attaquesRoninja.Keys)
        {
            if (attaquesRoninja[attaque])
                Console.WriteLine("Attaque Roninja : " + attaque);
        }
        foreach (Jeu.AttaqueType attaque in attaquesPiratitan.Keys)
        {
            if (attaquesPiratitan[attaque])
                Console.WriteLine("Attaque Piratitan : " + attaque);
        }
        foreach (Jeu.AttaqueType attaque in attaquesFantomage.Keys)
        {
            if (attaquesFantomage[attaque])
                Console.WriteLine("Attaque Fantomage : " + attaque);
        }
        foreach (Jeu.AttaqueType attaque in attaquesElfee.Keys)
        {
            if (attaquesElfee[attaque])
                Console.WriteLine("Attaque Elfee : " + attaque);
        }
        foreach (Jeu.SkinType skin in skinsRoninja.Keys)
        {
            if (skinsRoninja[skin])
                Console.WriteLine("Skin Roninja : " + skin);
        }
        foreach (Jeu.SkinType skin in skinsPiratitan.Keys)
        {
            if (skinsPiratitan[skin])
                Console.WriteLine("Skin Piratitan : " + skin);
        }
        foreach (Jeu.SkinType skin in skinsFantomage.Keys)
        {
            if (skinsFantomage[skin])
                Console.WriteLine("Skin Fantomage : " + skin);
        }
        foreach (Jeu.SkinType skin in skinsElfee.Keys)
        {
            if (skinsElfee[skin])
                Console.WriteLine("Skin Elfee : " + skin);
        }
    }






    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Algorithme de communication en BDD ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public static async Task createJoueur(string givenPseudo, string givenPassword) // TODO : Gérer le cas où le pseudo est déjà utilisé
    {
        // On se connecte à la BDD
        var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(c, cs);
        dynamoDBClient = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.EUWest3);

        // On teste si le pseudo est déjà utilisé
        var request1 = new GetItemRequest
        {
            TableName = "CubePlayers",
            Key = new Dictionary<string, AttributeValue>
            {
                {
                    "username",
                    new AttributeValue { S = givenPseudo}
                }
            }
        };
        var response1 = await dynamoDBClient.GetItemAsync(request1);

        // Si le pseudo est déjà utilisé, on arrête
        if (response1.Item.Count > 0)
        {
            Console.WriteLine("Ce pseudo est déjà utilisé");
            return;
        }

        // On assigne localement les valeurs du joueur
        username = givenPseudo + "@" + givenPassword;
        pseudo = givenPseudo;
        score = 500;

        // On crée un pseudo en BDD
        var request = new UpdateItemRequest
        {
            TableName = "CubePlayers",
            Key = new Dictionary<string, AttributeValue>
            {
                {
                    "username",
                    new AttributeValue { S = givenPseudo}
                }
            }
        };
        var response2 = dynamoDBClient.UpdateItemAsync(request);

        // On envoie les données en BDD
        await updateJoueur();
    }

    public static async Task updateJoueur()
    {
        // On chiffre les données
        string usernameChiffre = Chiffrer(username, true);
        string scoreChiffre = Chiffrer(score);
        string attaquesRoninjaChiffre = Chiffrer(codageSortSkins(attaquesRoninja));
        string attaquesPiratitanChiffre = Chiffrer(codageSortSkins(attaquesPiratitan));
        string attaquesFantomageChiffre = Chiffrer(codageSortSkins(attaquesFantomage));
        string attaquesElfeeChiffre = Chiffrer(codageSortSkins(attaquesElfee));
        string skinsRoninjaChiffre = Chiffrer(codageSortSkins(skinsRoninja));
        string skinsPiratitanChiffre = Chiffrer(codageSortSkins(skinsPiratitan));
        string skinsFantomageChiffre = Chiffrer(codageSortSkins(skinsFantomage));
        string skinsElfeeChiffre = Chiffrer(codageSortSkins(skinsElfee));

        // On envoie les données en BDD
        var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(c, cs);
        dynamoDBClient = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.EUWest3);
        var request = new UpdateItemRequest
        {
            TableName = "CubePlayers",
            Key = new Dictionary<string, AttributeValue>
            {
                {
                    "username",
                    new AttributeValue { S = usernameChiffre}
                }
            },
            AttributeUpdates = new Dictionary<string, AttributeValueUpdate>
            {
                {
                    "score",
                    new AttributeValueUpdate
                    {
                        Value = new AttributeValue { S = scoreChiffre },
                        Action = "PUT"
                    }
                },
                {
                    "attaquesRoninja",
                    new AttributeValueUpdate
                    {
                        Value = new AttributeValue { S = attaquesRoninjaChiffre },
                        Action = "PUT"
                    }
                },
                {
                    "attaquesPiratitan",
                    new AttributeValueUpdate
                    {
                        Value = new AttributeValue { S = attaquesPiratitanChiffre },
                        Action = "PUT"
                    }
                },
                {
                    "attaquesFantomage",
                    new AttributeValueUpdate
                    {
                        Value = new AttributeValue { S = attaquesFantomageChiffre },
                        Action = "PUT"
                    }
                },
                {
                    "attaquesElfee",
                    new AttributeValueUpdate
                    {
                        Value = new AttributeValue { S = attaquesElfeeChiffre },
                        Action = "PUT"
                    }
                },
                {
                    "skinsRoninja",
                    new AttributeValueUpdate
                    {
                        Value = new AttributeValue { S = skinsRoninjaChiffre },
                        Action = "PUT"
                    }
                },
                {
                    "skinsPiratitan",
                    new AttributeValueUpdate
                    {
                        Value = new AttributeValue { S = skinsPiratitanChiffre },
                        Action = "PUT"
                    }
                },
                {
                    "skinsFantomage",
                    new AttributeValueUpdate
                    {
                        Value = new AttributeValue { S = skinsFantomageChiffre },
                        Action = "PUT"
                    }
                },
                {
                    "skinsElfee",
                    new AttributeValueUpdate
                    {
                        Value = new AttributeValue { S = skinsElfeeChiffre },
                        Action = "PUT"
                    }
                }
            }
        };
        var response = await dynamoDBClient.UpdateItemAsync(request);
    }

    public static async Task connectJoueur(string givenPseudo, string givenPassword)
    {
        // On se connecte à la BDD
        var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(c, cs);
        dynamoDBClient = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.EUWest3);

        // On chiffre les données
        string usernameChiffre = Chiffrer(givenPseudo + "@" + givenPassword, true);

        // On récupère les données en BDD
        var request = new GetItemRequest
        {
            TableName = "CubePlayers",
            Key = new Dictionary<string, AttributeValue>
            {
                {
                    "username",
                    new AttributeValue { S = usernameChiffre}
                }
            }
        };
        var response = await dynamoDBClient.GetItemAsync(request);

        // Si le pseudo ou le mot de passe est incorrect, on arrête
        if (response.Item.Count == 0)
        {
            Console.WriteLine("Mauvais pseudo ou mot de passe");
            return;
        }

        // On déchiffre les données
        pseudo = givenPseudo;
        username = givenPseudo + "@" + givenPassword;
        score = int.Parse(Dechiffrer(response.Item["score"].S));
        decodageSortSkins(attaquesRoninja, long.Parse(Dechiffrer(response.Item["attaquesRoninja"].S)));
        decodageSortSkins(attaquesPiratitan, long.Parse(Dechiffrer(response.Item["attaquesPiratitan"].S)));
        decodageSortSkins(attaquesFantomage, long.Parse(Dechiffrer(response.Item["attaquesFantomage"].S)));
        decodageSortSkins(attaquesElfee, long.Parse(Dechiffrer(response.Item["attaquesElfee"].S)));
        decodageSortSkins(skinsRoninja, long.Parse(Dechiffrer(response.Item["skinsRoninja"].S)));
        decodageSortSkins(skinsPiratitan, long.Parse(Dechiffrer(response.Item["skinsPiratitan"].S)));
        decodageSortSkins(skinsFantomage, long.Parse(Dechiffrer(response.Item["skinsFantomage"].S)));
        decodageSortSkins(skinsElfee, long.Parse(Dechiffrer(response.Item["skinsElfee"].S)));

    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ Algorithme de communication en BDD ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑









    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Algorithme de codage des sortsSkins ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public static long codageSortSkins(Dictionary<Enum, bool> sortSkin)
    {
        long res = 0;
        long i = 1;
        foreach (bool val in sortSkin.Values)
        {
            res += val ? i : 0;
            i *= 2;
        }
        return res;
    }

    public static void decodageSortSkins(Dictionary<Enum, bool> sortSkin, long sort)
    {
        int i = 1;
        foreach (Enum val in sortSkin.Keys)
        {
            sortSkin[val] = IsBitSet(sort, i);
            i++;
        }
    }

    private static bool IsBitSet(long number, int bitPosition)
    {
        return (number & (1L << (bitPosition - 1))) != 0;
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ Algorithme de codage des sortsSkins ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑







    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Algorithme de chiffrement ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    private static string cle = "64ry1h6r1sdt6gh1st6gh1se6tg1sdth!";
    private static byte[] ivFixe = new byte[16] {
    0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77,
    0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF
    };

    private static string Chiffrer(long valeurClair)
    {
        return Chiffrer(valeurClair.ToString());
    }

    private static string Chiffrer(string texteClair, bool username = false)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.GenerateIV();
            string myKey = username ? texteClair : cle;
            byte[] myIv = username ? ivFixe : aesAlg.IV;

            // Convertir la clé en bytes
            byte[] cleBytes = Encoding.UTF8.GetBytes(myKey);
            Array.Resize(ref cleBytes, 32); // Ajuster la taille de la clé à 256 bits (32 octets)

            aesAlg.Key = cleBytes;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, myIv);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                // Ecriture de l'IV d'abord pour le récupérer lors du déchiffrement
                msEncrypt.Write(myIv, 0, myIv.Length);

                using (
                    CryptoStream csEncrypt = new CryptoStream(
                        msEncrypt,
                        encryptor,
                        CryptoStreamMode.Write
                    )
                )
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    // Ecrire les données chiffrées dans le flux
                    swEncrypt.Write(texteClair);
                }

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    private static string Dechiffrer(string texteChiffre)
    {
        byte[] fullCipher = Convert.FromBase64String(texteChiffre);

        using (Aes aesAlg = Aes.Create())
        {
            byte[] iv = new byte[aesAlg.BlockSize / 8];
            byte[] cipherText = new byte[fullCipher.Length - iv.Length];

            // Séparer l'IV du texte chiffré
            Array.Copy(fullCipher, iv, iv.Length);
            Array.Copy(fullCipher, iv.Length, cipherText, 0, cipherText.Length);

            byte[] cleBytes = Encoding.UTF8.GetBytes(cle);
            Array.Resize(ref cleBytes, 32); // Ajuster la taille de la clé à 256 bits (32 octets)

            aesAlg.Key = cleBytes;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            using (
                CryptoStream csDecrypt = new CryptoStream(
                    msDecrypt,
                    decryptor,
                    CryptoStreamMode.Read
                )
            )
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                // Lire les données déchiffrées du flux
                return srDecrypt.ReadToEnd();
            }
        }
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ Algorithme de chiffrement ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑






    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ POUR DEBOGAGE ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    private static void showGrid()
    {
        String faceNorth = Jeu.north.toString();
        String faceSouth = Jeu.south.toString();
        String faceEast = Jeu.east.toString();
        String faceWest = Jeu.west.toString();
        String faceHost = Jeu.host.toString();
        String faceClient = Jeu.client.toString();
        String grid = "                               ________________\n";
        for (int i = 0; i < 8; i++)
        {
            grid += "                              |";
            grid += faceClient.Substring(i * 17, 16);
            grid += "|\n";
        }
        grid += "                               ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾\n";
        grid += "________________     ________________     ________________     ________________\n";
        for (int i = 0; i < 8; i++)
        {
            grid += faceSouth.Substring(i * 17, 16);
            grid += "|   |";
            grid += faceWest.Substring(i * 17, 16);
            grid += "|   |";
            grid += faceNorth.Substring(i * 17, 16);
            grid += "|   |";
            grid += faceEast.Substring(i * 17, 16);
            grid += "\n";
        }
        grid += "‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾\n";
        grid += "                               ________________\n";
        for (int i = 0; i < 8; i++)
        {
            grid += "                              |";
            grid += faceHost.Substring(i * 17, 16);
            grid += "|\n";
        }
        grid += "                               ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾";
        Console.WriteLine(grid);
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ POUR DEBOGAGE ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
}
