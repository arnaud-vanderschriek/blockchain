using System;
using System.Collections.Generic;

namespace Blockchain
{
public class Blockchain
{
    public List<Block> Chain { get; private set; }

    public Blockchain()
    {
        Chain = new List<Block> { CreateGenesisBlock() };
    }

    private Block CreateGenesisBlock()
    {
        return new Block(0, "0", "Genesis Block");
    }

    public Block GetLatestBlock()
    {
        return Chain[Chain.Count - 1];
    }

    public void AddBlock(Block newBlock, int difficulty)
    {
        newBlock.PreviousHash = GetLatestBlock().Hash;
        newBlock.MineBlock(difficulty);
        Chain.Add(newBlock);
    }

    public bool IsChainValid()
    {
        for (int i = 1; i < Chain.Count; i++)
        {
            Block currentBlock = Chain[i];
            Block previousBlock = Chain[i - 1];

            if (currentBlock.Hash != currentBlock.CalculateHash())
            {
                return false;
            }

            if (currentBlock.PreviousHash != previousBlock.Hash)
            {
                return false;
            }
        }
        return true;
    }
}

}
