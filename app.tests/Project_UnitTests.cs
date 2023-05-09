namespace app.tests;


public class Project_UnitTests
{
    [Fact]
    public void Project_ShouldNotAcceptEmptyName()
    {
        //Arrange
        var projectName = string.Empty;
        var capitalRequirement = 1;
        var expectedProfit = 1;

        //Act
        var action = () => new Project(projectName, capitalRequirement, expectedProfit); 

        //Assert
        var caughtException = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal("Project Name cannot be empty (Parameter 'Name')", caughtException.Message);
    }
}

