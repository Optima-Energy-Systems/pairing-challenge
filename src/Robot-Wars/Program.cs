using RobotWars.Runner;
using RobotWars.Runner.Models;

Console.Write("Enter arena size (height width) (5 5): ");
var value = Console.ReadLine();
var size = string.IsNullOrEmpty(value) ? "5 5" : value;
var sizeSplit = size.Split(" ");
if (sizeSplit.Length != 2)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Please enter the size as height width");
    Console.ResetColor();
    return;
}

if(!int.TryParse(sizeSplit[0], out var height) || !int.TryParse(sizeSplit[1], out var width))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The height and width must be valid integer values");
    Console.ResetColor();
    return;
}

var arena = new Arena(height, width);
var numberOfRobots = 2;
var defaults = new[]
{
    (location: "1 2 N", movements: "LMLMLMLMM"),
    (location: "3 3 E", movements: "MMRMMRMRRM")
};

for(var i = 0; i < numberOfRobots; i++)
{
    (var location, var movements) = i < defaults.Length ? defaults[i] : (string.Empty, string.Empty);

    Console.WriteLine();
    Console.WriteLine($"Robot: {i + 1}");
    Console.Write($"Enter robot {i + 1}'s starting position and direction (x y N|S|E|W) {(string.IsNullOrEmpty(location) ? string.Empty : string.Format("({0})", location))}: ");
    var positionAndDirectionInput = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(positionAndDirectionInput))
        positionAndDirectionInput = location;

    var positionAndDirection = positionAndDirectionInput.Split(" ");
    if (positionAndDirection.Length != 3)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The position and direction must be formatted as x y N|S|E|W");
        Console.ResetColor();
        return;
    }

    if (!int.TryParse(positionAndDirection[0], out var x) || !int.TryParse(positionAndDirection[1], out var y) || !Helpers.ParseDirection(positionAndDirection[2], out Direction direction))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The position and direction must be formatted as x y N|S|E|W");
        Console.ResetColor();
        return;
    }

    var robot = new Robot(arena, x, y, direction);
    Console.Write($"Enter robot {i + 1}'s commands  {(string.IsNullOrEmpty(movements) ? string.Empty : string.Format("({0})", movements))}: ");
    var commands = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(commands))
        commands = movements;
    
    robot.Execute(commands);
}

Console.WriteLine();
Console.WriteLine("---   OUTPUT   ---");

foreach (var item in arena.Participants)
    Console.WriteLine(item);

Console.ReadLine();