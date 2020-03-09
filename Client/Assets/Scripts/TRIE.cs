using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Config;

public class TRIE
{
    public struct Letter
    {
        public const string Chars =  FoodData.TrieChild;
        public static implicit operator Letter(char c)
        {
            return new Letter() { Index = Chars.IndexOf(c) };
        }

        public int Index;
        public char ToChar()
        {
            return Chars[Index];
        }
        public override string ToString()
        {
            return Chars[Index].ToString();
        }
    }

    public class Node
    {
        public string Word;
        public List<int> m_idx = new List<int>();
        public bool IsTerminal { get { return Word != null; } }
        public Dictionary<Letter, Node> Edges = new Dictionary<Letter, Node>();
    }

    public Node Root = new Node();


    public void insert(List<string> words)
    {
        for (int w = 0; w < words.Count; w++)
        {
            var word = words[w];
            var node = Root;
            for (int len = 1; len <= word.Length; len++)
            {
                var letter = word[len - 1];
                Node next;
                if (!node.Edges.TryGetValue(letter, out next))
                {
                    next = new Node();
                    if (len == word.Length)
                    {
                        next.Word = word;
                    }
                    node.Edges.Add(letter, next);
                }
                next.m_idx.Add(w);
                node = next;
            }
        }
    }

    public Node find(Node r, string str)
    {
        var current = r;
        Node next= null;

        for (int i = 0; i < str.Length; i++) {
            if (!current.Edges.TryGetValue(str[i], out next)) {
                return null;
            }
            current = next;
        }
        return next;
    }
}