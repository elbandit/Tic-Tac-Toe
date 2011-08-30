using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public static class Tokens
    {
        public static Token x_token { get { return new Token("X"); } }
        public static Token o_token { get { return new Token("O"); } }
    }

    public class Token : IEquatable<Token>
    {
        public string value { get; set; }

        public Token(string value)
        {
            this.value = value;
        }

        public bool Equals(Token other)
        {
            return this.value == other.value;
        }

        public override string ToString()
        {
            return value;
        }
    }

}
