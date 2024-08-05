using blockchain;
using System;

class Program
{
    static void Main(string[] args)
    {
        Blockchain blockchain = new Blockchain();
        int difficulty = 2;

        Console.WriteLine("Mining block 1...");
        blockchain.AddBlock(new Block(1, "", "Block 1 Data"), difficulty);

        Console.WriteLine("Mining block 2...");
        blockchain.AddBlock(new Block(2, "", "Block 2 Data"), difficulty);

        Console.WriteLine("Is blockchain valid? " + blockchain.IsChainValid());

        foreach (var block in blockchain.Chain)
        {
            Console.WriteLine($"Index: {block.Index}, Timestamp: {block.Timestamp}, Data: {block.Data}, Hash: {block.Hash}, PreviousHash: {block.PreviousHash}, Nonce: {block.Nonce}");
        }
    }
}
