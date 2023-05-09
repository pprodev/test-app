namespace app.Investment;

public static class Constants
{
    //variable S
    public const int MIN_STARTING_CAPITAL = 1;
    public const int MAX_STARTING_CAPITAL = 1000000000; //1BN

    //variable L
    public const int MIN_NUMBER_OF_PROJECTS = 1;
    public const int MAX_NUMBER_OF_PROJECTS = 100000; //100K
    
    //Capital required for a project
    public const int MIN_CAPITAL_REQUIREMENT = 1;
    public const int MAX_CAPITAL_REQUIREMENT = 1000000000; //1BN

    //Profit from a project
    public const int MIN_EXPECTED_PROFIT = 1;
    public const int MAX_EXPECTED_PROFIT = 1000000000; //1BN

    //Size of P
    public const int MIN_PROJECT_PORTFOLIO_SIZE = 1;
    public const int MAX_PROJECT_PORTFOLIO_SIZE = 100000; //100K
}