namespace app.tests;

public class ProjectPortfolio_UnitTests
{
    // GIVEN a ProjectPortfolio
    // WHEN I have a maximum capital requirement value that allows investing in at least one Project from the portfolio
    // THEN I want to get a list of projects that includes only the projects 
    // that have a capital requirement that is less or equal to my maximum value
    [Fact]
    public void ProjectPortfolio_ShouldFilterBasedOnMaximumCapitalRequirement()
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
        var capitalRequirement = 3;
        var expectedProjectPortfolioSize = 2;

        //Act
        var acceptedProjects = projectPortfolio.FilterProjectsByCapitalRequirement(capitalRequirement);

        //Assert
        Assert.Equal(expectedProjectPortfolioSize, acceptedProjects.Projects.Count);
    }
    
    // GIVEN a ProjectPortfolio
    // WHEN I have a maximum capital requirement value that will not allow me to invest in any project in the portfolio
    // THEN I want to get an empty list of projects
    [Fact]
    public void ProjectPortfolio_ShouldReturnEmptyListOfProjectsForCapitalInvestment()
    {
        //Arrange
        var projectPortfolio = new ProjectPortfolio(new[]
        {
            new Project("P1", 5, 1),
            new Project("P2", 3, 2),
            new Project("P3", 4, 3),
            new Project("P4", 5, 4),
            new Project("P5", 6, 5)
        }.ToList());
        var capitalRequirement = 2;
        var expectedProjectPortfolioSize = 0;

        //Act
        var acceptedProjects = projectPortfolio.FilterProjectsByCapitalRequirement(capitalRequirement);

        //Assert
        Assert.Equal(expectedProjectPortfolioSize, acceptedProjects.Projects.Count);
    }
    
    // GIVEN a ProjectPortfolio
    // WHEN I have am selecting the best investment
    // THEN I want to get the project that has the maximum ExpectedProfit
    [Fact]
    public void ProjectPortfolio_ShouldReturnProjectWithBiggestProfit()
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
        var expectedProjectProfit = 5;

        //Act
        var biggestReturnProject = projectPortfolio.DetermineBestProjectToInvestIn();

        //Assert
        Assert.Equal(expectedProjectProfit, biggestReturnProject.ExpectedProfit);
    }
    
    // GIVEN a ProjectPortfolio
    // WHEN a project is Completed
    // THEN I need a new ProjectPortfolio that does not include the completed project 
    [Fact]
    public void ProjectPortfolio_CompletingAProject_ShouldReturnProjectPortfolioWithoutTheCompletedProject()
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
        var completedProject = projectPortfolio.Projects[4];
        var expectedNumberOfProjects = 4;

        //Act
        var newProjectPortfolio = projectPortfolio.CompleteProject(completedProject);

        //Assert
        Assert.Equal(expectedNumberOfProjects, newProjectPortfolio.Projects.Count);
    }
    
    // GIVEN a ProjectPortfolio
    // WHEN a project is added
    // THEN the list of projects in the ProjectPortfolio increases by 1
    [Fact]
    public void ProjectPortfolio_AddProjectToPortfolio()
    {
        //Arrange
        var projectPortfolio = new ProjectPortfolio(new[]
        {
            new Project("P1", 1, 1),
            new Project("P2", 3, 2),
            new Project("P3", 4, 3),
            new Project("P4", 5, 4),
            
        }.ToList());
        var newProject = new Project("P5", 6, 5);
        var expectedNumberOfProjects = 5;

        //Act
        var newProjectPortfolio = projectPortfolio.AddProject(newProject);

        //Assert
        Assert.Equal(expectedNumberOfProjects, newProjectPortfolio.Projects.Count);
    }
}