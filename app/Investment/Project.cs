namespace app.Investment;

public class Project
{
    public readonly string Name;
    public readonly int CapitalRequirement;
    public readonly int ExpectedProfit;

    public Project(string name, int capitalRequirement, int expectedProfit)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Name", "Project Name cannot be empty");

        if (capitalRequirement < Constants.MIN_CAPITAL_REQUIREMENT || 
            capitalRequirement > Constants.MAX_CAPITAL_REQUIREMENT)
            throw new ArgumentOutOfRangeException($"Capital Requirement should be between {Constants.MIN_CAPITAL_REQUIREMENT:n0} and {Constants.MAX_CAPITAL_REQUIREMENT:n0}");
        
        if (expectedProfit < Constants.MIN_EXPECTED_PROFIT || 
            expectedProfit > Constants.MAX_EXPECTED_PROFIT)
            throw new ArgumentOutOfRangeException($"Expected Profit should be between {Constants.MIN_EXPECTED_PROFIT:n0} and {Constants.MAX_EXPECTED_PROFIT:n0}");
        
        Name = name;
        CapitalRequirement = capitalRequirement;
        ExpectedProfit = expectedProfit;
    }
}
