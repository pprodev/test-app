namespace MyProject;
using app.Investment;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        var timer = Stopwatch.StartNew();

        /*
         * Large dataset 
         */
        
        var startingCapital = 1000000;//variable S
        var maxInvestments = 90000;//variable L
        var portfolioSize = 100000; //Number of projects that will be randomly generated
        
        var p_list = Utility.GenerateNumberOfRandomProjects(portfolioSize);
        startingCapital = p_list.Min(p => p.CapitalRequirement);//set the value of the starting capital to the smallest investment in the randomly generated portfolio.

        /*
         * Small dataset 
         */

        // var startingCapital = 2;//variable S
        // var maxInvestments = 3;//variable L
        //
        // var p_list = Utility.GenerateSimpleProjects();
        // foreach (var project in p_list)
        //     Console.WriteLine($"Project Name: {project.Name} ; Capital Required: {project.CapitalRequirement:n0} ; Expected Profit: {project.ExpectedProfit:n0}");
        //
        Console.WriteLine($"Projects generated in - {timer.ElapsedMilliseconds:n0} ms");
        
        var strategy = new InvestmentStrategy(startingCapital, new ProjectPortfolio(p_list), maxInvestments);
        strategy.DetermineOptimalInvestmentStrategy();
        Console.WriteLine(strategy.PrintInvestmentStrategy());
        
        timer.Stop();
        Console.WriteLine($"Total execution time - {timer.ElapsedMilliseconds:n0} ms");
    }
}

