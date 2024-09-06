using System.Security.Cryptography;

class Tests
{
    public static void Main()
    {
        
    }

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Algorithme de codage des sorts ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    private static Dictionary<Jeu.AttaqueType, bool>? attaquesRoninja;
    private static Dictionary<Jeu.AttaqueType, bool>? attaquesPiratitan;
    private static Dictionary<Jeu.AttaqueType, bool>? attaquesFantomage;
    private static Dictionary<Jeu.AttaqueType, bool>? attaquesElfee;

    public static void algoCodageSort() // TODO : Récupérer les sorts en BDD
    {
        attaquesPiratitan = new Dictionary<Jeu.AttaqueType, bool>
        {
            { Jeu.AttaqueType.ancre, false },
            { Jeu.AttaqueType.bombe, false },
            { Jeu.AttaqueType.bondDuTitan, false },
            { Jeu.AttaqueType.chargeDuTitan, false },
            { Jeu.AttaqueType.coffre, false },
            { Jeu.AttaqueType.coupDeFeu, false },
            { Jeu.AttaqueType.etincelle, false },
            { Jeu.AttaqueType.flaque, false },
            { Jeu.AttaqueType.frappeDuPirate, false },
            { Jeu.AttaqueType.frappeDuTitan, false },
            { Jeu.AttaqueType.harpon, false },
            { Jeu.AttaqueType.invincibilite, false },
            { Jeu.AttaqueType.longueVue, false },
            { Jeu.AttaqueType.mouette, false },
            { Jeu.AttaqueType.planche, false },
            { Jeu.AttaqueType.porterDeposer, false },
            { Jeu.AttaqueType.poudre, false },
            { Jeu.AttaqueType.sabre, false },
            { Jeu.AttaqueType.tonneau, false }
        };
        attaquesRoninja = new Dictionary<Jeu.AttaqueType, bool>
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
            { Jeu.AttaqueType.invisibilite, false },
            { Jeu.AttaqueType.katana, false },
            { Jeu.AttaqueType.kunai, false },
            { Jeu.AttaqueType.memoire, false },
            { Jeu.AttaqueType.piegeALoup, false },
            { Jeu.AttaqueType.piegeLineaire, false },
            { Jeu.AttaqueType.pirouette, false },
            { Jeu.AttaqueType.poison, false },
            { Jeu.AttaqueType.repousse, false },
            { Jeu.AttaqueType.teleport, false }
        };
        attaquesFantomage = new Dictionary<Jeu.AttaqueType, bool>
        {
            { Jeu.AttaqueType.bouleDeFeu, false },
            { Jeu.AttaqueType.bouletFantomatique, false },
            { Jeu.AttaqueType.buff, false },
            { Jeu.AttaqueType.caseDeRapatriement, false },
            { Jeu.AttaqueType.caseTerrifiante, false },
            { Jeu.AttaqueType.clairvoyance, false },
            { Jeu.AttaqueType.coupDeBaton, false },
            { Jeu.AttaqueType.crapeau, false },
            { Jeu.AttaqueType.eauVaseuse, false },
            { Jeu.AttaqueType.feuFollet, false },
            { Jeu.AttaqueType.gravite, false },
            { Jeu.AttaqueType.inversion, false },
            { Jeu.AttaqueType.jouvence, false },
            { Jeu.AttaqueType.mainsMaudites, false },
            { Jeu.AttaqueType.malediction, false },
            { Jeu.AttaqueType.rappel, false },
            { Jeu.AttaqueType.sortDeProtection, false },
            { Jeu.AttaqueType.transposition, false },
            { Jeu.AttaqueType.voileDInvisibilite, false }
        };
        attaquesElfee = new Dictionary<Jeu.AttaqueType, bool>
        {
            { Jeu.AttaqueType.altruisme, false },
            { Jeu.AttaqueType.carosse, false },
            { Jeu.AttaqueType.coupDeBaguette, false },
            { Jeu.AttaqueType.derniereVolontee, false },
            { Jeu.AttaqueType.elixirAgressif, false },
            { Jeu.AttaqueType.envolAtterissage, false },
            { Jeu.AttaqueType.espritElfique, false },
            { Jeu.AttaqueType.esquive, false },
            { Jeu.AttaqueType.fleche, false },
            { Jeu.AttaqueType.flecheDeLumiere, false },
            { Jeu.AttaqueType.flechePatiente, false },
            { Jeu.AttaqueType.hautesHerbes, false },
            { Jeu.AttaqueType.miniaturisation, false },
            { Jeu.AttaqueType.petitSoin, false },
            { Jeu.AttaqueType.poudreBienfaisante, false },
            { Jeu.AttaqueType.poudreSoporifique, false },
            { Jeu.AttaqueType.poudreStimulante, false },
            { Jeu.AttaqueType.reanimation, false },
            { Jeu.AttaqueType.soinTotal, false }
        };

        // Codage d'un sort
        long sort = codageSort(attaquesRoninja);

        // Décodage d'un sort (stockage dans les variables statiques)
        decodageSort(attaquesRoninja, sort);
    }

    public static long codageSort(Dictionary<Jeu.AttaqueType, bool> attaques)
    {
        long res = 0;
        long i = 1;
        foreach (bool attaque in attaques.Values)
        {
            res += attaque ? i : 0;
            i *= 2;
        }
        return res;
    }

    public static void decodageSort(Dictionary<Jeu.AttaqueType, bool> attaques, long sort)
    {
        int i = 1;
        foreach (Jeu.AttaqueType attaque in attaques.Keys)
        {
            attaques[attaque] = IsBitSet(sort, i);
            i++;
        }
    }

    private static bool IsBitSet(long number, int bitPosition)
    {
        return (number & (1L << (bitPosition - 1))) != 0;
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ Algorithme de codage des sorts ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Algorithme de chiffrement d'un int ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    public static void algoChiffrement()
    {
        byte[] key = new byte[]
        {
            0x2F,
            0x3C,
            0x6E,
            0x7A,
            0x9C,
            0x1A,
            0xA4,
            0xB2,
            0xE5,
            0x10,
            0x5D,
            0xD1,
            0xDA,
            0xEB,
            0xF0,
            0x21,
            0x32,
            0x8F,
            0xC3,
            0xFC,
            0x0D,
            0xA9,
            0xB8,
            0xC9,
            0x43,
            0x54,
            0x65,
            0x76,
            0x87,
            0x98,
            0x4B,
            0x1F
        };

        // Valeur à chiffrer
        int valeur = 123456789;

        // Chiffrement de valeur dans encryptedValue
        string encryptedValue = EncryptValue(valeur, key);

        // Déchiffrement de encryptedValue dans decryptedValue
        int decryptedValue = DecryptValue(encryptedValue, key);
    }

    public static string EncryptValue(int value, byte[] key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.GenerateIV();
            byte[] iv = aes.IV;
            Console.WriteLine("IV : " + BitConverter.ToString(iv).Replace("-", ""));

            using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, iv))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (
                        CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                    )
                    {
                        byte[] valueBytes = BitConverter.GetBytes(value);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(valueBytes); // Assurer l'ordre des octets pour BigEndian

                        // Ajouter du padding pour correspondre à la taille du bloc AES (16 octets)
                        byte[] paddedValue = PadData(valueBytes, aes.BlockSize / 8);

                        cs.Write(paddedValue, 0, paddedValue.Length);
                        cs.FlushFinalBlock();
                    }

                    byte[] encrypted = ms.ToArray();
                    byte[] result = new byte[iv.Length + encrypted.Length];
                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                    Buffer.BlockCopy(encrypted, 0, result, iv.Length, encrypted.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }
    }

    public static int DecryptValue(string encryptedText, byte[] key)
    {
        byte[] fullCipher = Convert.FromBase64String(encryptedText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            byte[] iv = new byte[aes.BlockSize / 8];
            byte[] cipherText = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipherText, 0, cipherText.Length);

            using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, iv))
            {
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] paddedValue = new byte[aes.BlockSize / 8];
                        cs.Read(paddedValue, 0, paddedValue.Length);

                        byte[] valueBytes = UnpadData(paddedValue, aes.BlockSize / 8);

                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(valueBytes);

                        return BitConverter.ToInt32(valueBytes, 0);
                    }
                }
            }
        }
    }

    private static byte[] PadData(byte[] data, int blockSize)
    {
        int paddingSize = blockSize - data.Length % blockSize;
        byte[] paddedData = new byte[data.Length + paddingSize];
        Array.Copy(data, paddedData, data.Length);
        for (int i = data.Length; i < paddedData.Length; i++)
            paddedData[i] = (byte)paddingSize;
        return paddedData;
    }

    private static byte[] UnpadData(byte[] data, int blockSize)
    {
        int paddingSize = data[data.Length - 1];
        byte[] unpaddedData = new byte[data.Length - paddingSize];
        Array.Copy(data, unpaddedData, unpaddedData.Length);
        return unpaddedData;
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ Algorithme de chiffrement d'un int ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
