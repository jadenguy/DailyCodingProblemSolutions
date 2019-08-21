using System;
using Common.Node;

namespace Common
{
    public static class Solution050
    {
        public static int Evaluate(this BinaryNode<string> node)
        {
            switch (node.Data)
            {
                case "+":
                    return node.Left.Evaluate() + node.Right.Evaluate();
                case "-":
                    return node.Left.Evaluate() - node.Right.Evaluate();
                case "*":
                    return node.Left.Evaluate() * node.Right.Evaluate();
                case "/":
                    return node.Left.Evaluate() / node.Right.Evaluate();
                // case "add":
                //     return node.Left.Evaluate() + node.Right.Evaluate();
                // case "subtract":
                //     return node.Left.Evaluate() - node.Right.Evaluate();
                // case "multiply":
                //     return node.Left.Evaluate() * node.Right.Evaluate();
                // case "divide":
                //     return node.Left.Evaluate() / node.Right.Evaluate();
                default:
                    return int.Parse(node.Data);
            }
        }
    }
}