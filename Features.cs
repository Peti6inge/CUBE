using System.Security.Cryptography;

class Tests
{
    static void Main()
    {
        algoChiffrementSort();
    }

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Algorithme de codage des sorts ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    
    public enum AttaqueType
    {
        carosse,
        bombe,
        espritElfique,
        crapeau,
        mouette,
        tonneau,
        coffre,
        clone,
        dragAndDrop,
        ancre,
        bondDuTitan,
        chargeDuTitan,
        coupDeFeu,
        etincelle,
        flaque,
        frappeDuPirate,
        frappeDuTitan,
        harpon,
        invincibilite,
        longueVue,
        planche,
        porterDeposer,
        poudre,
        sabre,
        altruisme,
        coupDeBaguette,
        derniereVolontee,
        elixirAgressif,
        envolAtterissage,
        esquive,
        fleche,
        flecheDeLumiere,
        flechePatiente,
        hautesHerbes,
        miniaturisation,
        petitSoin,
        poudreBienfaisante,
        poudreSoporifique,
        poudreStimulante,
        reanimation,
        soinTotal,
        acide,
        attire,
        brume,
        couteauDeLancee,
        derobadeDeLOmbre,
        derobade,
        entrave,
        feinte,
        invisibilite,
        katana,
        kunai,
        memoire,
        piegeALoup,
        piegeLineaire,
        pirouette,
        poison,
        repousse,
        teleport,
        bouleDeFeu,
        bouletFantomatique,
        buff,
        caseDeRapatriement,
        caseTerrifiante,
        clairvoyance,
        coupDeBaton,
        eauVaseuse,
        feuFollet,
        gravite,
        inversion,
        jouvence,
        mainsMaudites,
        malediction,
        rappel,
        sortDeProtection,
        transposition,
        voileDInvisibilite,
        none
    }

    public static void algoCodageSort() { }

    public static int codageSort(List<AttaqueType>) { }

    public static List<AttaqueType> decodageSort(int sort) { }

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
