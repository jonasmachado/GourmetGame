using JogoGourmet.Services;

namespace JogoGourmet.Domain
{
    public class Node
    {
        public required string Dish { get; set; }

        public Node? Parent { get; set; }

        public Node? PositiveBranch { get; set; }

        public Node? NegativeBranch { get; set; }

        public bool IsLeafNode => PositiveBranch is null && NegativeBranch is null;
    }
}
