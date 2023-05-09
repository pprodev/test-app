using System.Text;

namespace app.tests;

public class InvestmentStrategy_UnitTests
{
    // GIVEN a ProjectPortfolio
    // WHEN I specify a maximum number of projects to invest in AND a starting investment capital
    // THEN I want to see what are the best Projects to invest in AND the total investment return
    [Fact]
    public void InvestmentStrategy_SmallNumberOfProjects()
    {
        //Arrange
        var projectPortfolio = new ProjectPortfolio(new[]
        {
            new Project("P1", 1, 1),
            new Project("P2", 3, 2),
            new Project("P3", 4, 3),
            new Project("P4", 5, 4),
            new Project("P5", 6, 5)
        }.ToList());
        var startingCapital = 2;
        var investmentLimit = 3;
        var expectedOutput = new StringBuilder();
        expectedOutput.AppendLine($"Selected Projects P1,P2,P4 with capital 1,3,5");
        expectedOutput.AppendLine($"Selected Profits 1,2,4");
        expectedOutput.AppendLine($"Optimal Investment Strategy returns = {startingCapital} + 1 + 2 + 4 = 9");

        //Act
        var strategy = new InvestmentStrategy(startingCapital, projectPortfolio, investmentLimit);
        strategy.DetermineOptimalInvestmentStrategy();
        var actualOutput = strategy.PrintInvestmentStrategy();

        //Assert
        Assert.Equal(expectedOutput.ToString(), actualOutput);
    }

}