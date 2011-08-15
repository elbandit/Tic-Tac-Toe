namespace Wrox.BDD.Domain
{
    public class EmptyPlayingSquare : Square
    {
        public bool contains_token_matching(Token o_token)
        {
            return false;
        }
    }
}