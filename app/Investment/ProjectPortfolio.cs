namespace app.Investment;

public class ProjectPortfolio
{
    private readonly List<Project> allProjects;

    public List<Project> Projects
    {
        get
        {
            return allProjects;
        }
    }

    public ProjectPortfolio(List<Project> projects)
    {
        if (projects == null)
            throw new ArgumentNullException("projects", "List of projects in the portfolio cannot be NULL");
        
        if (projects.Count < Constants.MIN_PROJECT_PORTFOLIO_SIZE || 
            projects.Count > Constants.MAX_PROJECT_PORTFOLIO_SIZE)
            throw new ArgumentOutOfRangeException($"Number of projects in the ProjectPortfolio should be between {Constants.MIN_PROJECT_PORTFOLIO_SIZE:n0} and {Constants.MAX_PROJECT_PORTFOLIO_SIZE:n0}");
        
        allProjects = projects;
    }

    //default ctor used to create an empty portfolio of projects that is used to track projects that have been selected for investment
    public ProjectPortfolio()
    {
        allProjects = new List<Project>();
    }

    public ProjectPortfolio FilterProjectsByCapitalRequirement(long maxCapitalRequirements)
    {
        var filteredProjects = allProjects.Where(
                project => project.CapitalRequirement <= maxCapitalRequirements)
            .ToList();
        
        if(filteredProjects.Count > 0)
            return new ProjectPortfolio(filteredProjects);

        return new ProjectPortfolio();
    }

    public Project? DetermineBestProjectToInvestIn()
    {
        return allProjects.MaxBy(project => project.ExpectedProfit);
    }

    public ProjectPortfolio CompleteProject(Project completedProject)
    {
        if (completedProject == null)
            throw new ArgumentNullException("completedProject", "Completed Project argument cannot be NULL");

        if (!allProjects.Exists(p => p == completedProject))
            return new ProjectPortfolio(allProjects);

        var newProjects = allProjects;
        newProjects.Remove(completedProject);
        
        return new ProjectPortfolio(newProjects);
    }

    public ProjectPortfolio AddProject(Project newProject)
    {
        var newProjects = allProjects;
        newProjects.Add(newProject);
        
        return new ProjectPortfolio(newProjects);
    }
}



