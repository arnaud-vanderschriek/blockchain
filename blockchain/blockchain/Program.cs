using System;
using System.Security.Cryptography;
using System.Text;

public class Block
{
    public int Index { get; set; }
    public DateTime Timestamp { get; set; }
    public string PreviousHash { get; set; }
    public string Hash { get; set; }
    public string Data { get; set; }

    public Block(int index, string previousHash, string data)
    {
        Index = index;
        Timestamp = DateTime.Now;
        PreviousHash = previousHash;
        Data = data;
        Hash = CalculateHash();
    }

    public string CalculateHash()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            string rawData = Index + Timestamp + PreviousHash + Data;
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
