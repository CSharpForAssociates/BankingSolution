namespace BankingDomain
{
    public interface IProvideTheCutoffClock
    {
        bool BeforeCutoff();
    }
}