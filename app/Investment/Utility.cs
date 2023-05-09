namespace app.Investment;

public class Utility
{

    //generate sample (simple) Portfolio list
    public static List<Project> GenerateSimpleProjects()
    {
        return new[]
        {
            new Project("P1", 1, 1),
            new Project("P2", 3, 2),
            new Project("P3", 4, 3),
            new Project("P4", 5, 4),
            new Project("P5", 6, 5)
        }.ToList();
    }

    //generates a Project with a random value for capitalRequirement & expectedProfit
    public static Project GenerateRandomProject(string projectName)
    {
        var r = new Random();
        
        var randomCapitalRequirement = r.Next(Constants.MIN_CAPITAL_REQUIREMENT, Constants.MAX_CAPITAL_REQUIREMENT);
        var randomExpectedProfit = r.Next(Constants.MIN_EXPECTED_PROFIT, Constants.MAX_EXPECTED_PROFIT);

        return new Project(projectName, randomCapitalRequirement, randomExpectedProfit);
    }
    
    //generates a specified number of random Projects
    public static List<Project> GenerateNumberOfRandomProjects(int number)
    {
        var projects = new List<Project>(capacity:number);
        
        for (int i = 1; i <= number; i++)
        {
            projects.Add(GenerateRandomProject(i.ToString()));
        }

        return projects;
    }
}
