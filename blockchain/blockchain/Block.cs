using System;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Data { get; set; }
        public int Nonce { get; set; }

        public Block(int index, string previousHash, string data)
        {
            Index = index;
            Timestamp = DateTime.Now;
            PreviousHash = previousHash;
            Data = data;
            Nonce = 0;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir chaque élément en chaîne de caractères avant de les concaténer
                string rawData = Index.ToString() + Timestamp.ToString() + PreviousHash + Data + Nonce.ToString();
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void MineBlock(int difficulty)
        {
            string target = new string('0', difficulty);
            while (Hash.Substring(0, difficulty) != target)
            {
                Nonce++;
                Hash = CalculateHash();
            }
            Console.WriteLine("Block mined: " + Hash);
        }
    }
}
