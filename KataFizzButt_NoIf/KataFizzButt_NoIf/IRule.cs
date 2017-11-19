namespace KataFizzButt_NoIf
{
    public interface IRule
    {
        string Apply(int number);
        bool DoesApply(int number);
    }
}