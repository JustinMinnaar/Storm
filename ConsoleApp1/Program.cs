using static System.Console;

WriteLine("Hello to Explorer Game.");
WriteLine("You have crossed the mountains and there is a valley ahead of you.");

var numbers = new[] { 12, 42, 23, 44, 65 };

var places = new Place[]
{
    new("forest", "You are in the mountains.", "W=cave,N=valley"),
    new("cave", "You are in a cave.", "E=forest"),
    new("valley", "You are in the valley. You see a village.", "S=forest,N=village"),
    new("village", "You are in the village.", "S=valley,N=ocean"),
    new("ocean", "You are at the ocean.", "S=village"),
};

var currentPlace = places.First();

start:
WriteLine();
WriteLine(currentPlace.Name);
WriteLine(currentPlace.Description);

Write($"Which way do you want to go? {currentPlace.Paths}: ");
string? userResponse = ReadLine()?.ToUpper();

var paths = currentPlace.Paths.Split(',');
foreach (var path in paths)
{
    var pathParts = path.Split('=');
    if (pathParts[0] == userResponse)
    {
        var chosenPath = places.FirstOrDefault(p => p.Name == pathParts[1]);
        if (chosenPath != null)
        {
            currentPlace = chosenPath;
            goto start;
        }
        else
        {
            WriteLine("Invalid path.");
        }
        break;
    }
}
//var chosenPath = paths.FirstOrDefault(p => p.Split('=')[0] == userResponse);

