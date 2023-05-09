using System.Text;

namespace app.Investment;

public class InvestmentStrategy
{
    private readonly int startingCapital;
    private readonly ProjectPortfolio projectPortfolio;
    private readonly int maximumNumberOfInvestments;

    private ProjectPortfolio investedProjects;
    private long totalCapital;//includes the starting capital + SUM of all profits for invested projects
    
    public InvestmentStrategy(int startingCapital, ProjectPortfolio availableProjects, int maximumNumberOfInvestments)
    {
        if (startingCapital < Constants.MIN_STARTING_CAPITAL || 
            startingCapital > Constants.MAX_STARTING_CAPITAL)
            throw new ArgumentOutOfRangeException($"Starting Capital (var S) should be between {Constants.MIN_STARTING_CAPITAL:n0} and {Constants.MAX_STARTING_CAPITAL:n0}");

        if (maximumNumberOfInvestments < Constants.MIN_NUMBER_OF_PROJECTS || 
            maximumNumberOfInvestments > Constants.MAX_NUMBER_OF_PROJECTS)
            throw new ArgumentOutOfRangeException($"Maximum Number of Investments (var L) should be between {Constants.MIN_NUMBER_OF_PROJECTS:n0} and {Constants.MAX_NUMBER_OF_PROJECTS:n0}");
        
        this.startingCapital = startingCapital;
        this.projectPortfolio = availableProjects;
        this.maximumNumberOfInvestments = maximumNumberOfInvestments;

        investedProjects = new ProjectPortfolio();
        totalCapital = startingCapital;
    }

    public void DetermineOptimalInvestmentStrategy()
    {
        //investmentPortfolio stores all projects available for investment
        //starts with all projects available for investment, and eliminates a project at a time as they get invested in
        var investmentPortfolio = projectPortfolio;
        
        while (investedProjects.Projects.Count < maximumNumberOfInvestments)
        {
            var availableProjectsToInvestIn = investmentPortfolio.FilterProjectsByCapitalRequirement(totalCapital);
            var selectedProjectToInvestIn = availableProjectsToInvestIn.DetermineBestProjectToInvestIn();

            //even though we did not reach the maximum numbers of project we may want to take on,
            //there is no available project that we can take on with the capital that we have at our disposal
            if (selectedProjectToInvestIn == null)
            {
                //Console.WriteLine("No more projects to invest in with the capital we have right now");
                break;
            }
            else
            {
                investedProjects = investedProjects.AddProject(selectedProjectToInvestIn);
                totalCapital += selectedProjectToInvestIn.ExpectedProfit;
                investmentPortfolio = investmentPortfolio.CompleteProject(selectedProjectToInvestIn);

                if (investedProjects.Projects.Count % 5000 == 0)
                {
                    Console.WriteLine($"Found 1 project to invest in for a total of {investedProjects.Projects.Count}");
                }
            }
        }
    }

    public string PrintInvestmentStrategy()
    {
        var returnString = new StringBuilder();
        
        if (investedProjects.Projects.Count > 0)
        {
            var selectedProjectsNames = string.Join(",", investedProjects.Projects.Select(x => x.Name));
            var selectedProjectsCapital = string.Join(",", investedProjects.Projects.Select(x => x.CapitalRequirement));
            var selectedProfits = string.Join(",", investedProjects.Projects.Select(x => x.ExpectedProfit));
            var selectedReturns = string.Join(" + ", investedProjects.Projects.Select(x => x.ExpectedProfit));

            returnString.AppendLine(
                $"Selected Projects {selectedProjectsNames} with capital {selectedProjectsCapital}");

            returnString.AppendLine($"Selected Profits {selectedProfits}");
            returnString.AppendLine($"Optimal Investment Strategy returns = {startingCapital} + {selectedReturns} = {totalCapital}");
        }
        else
        {
            returnString.AppendLine("Selected Projects - no projects were selected ");
            returnString.AppendLine("Selected Profits - no profits made");
            returnString.AppendLine(
                $"Optimal Investment Strategy returns = {startingCapital} , which is your starting capital");
        }

        return returnString.ToString();
    }
}


