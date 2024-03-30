using static System.Console;

WriteLine("Hello to Explorer Game.");
WriteLine("You have crossed the mountains and there is a valley ahead of you.");

var numbers = new[] { 12, 42, 23, 44, 65 };

var places = new Place[]
{new("forest",
    "You find yourself amidst the towering mountains, enveloped by a dense forest. The air is crisp, carrying the scent of pine and earth. Sunlight filters through the thick canopy above, casting dappled shadows on the forest floor. The sound of distant wildlife echoes softly, suggesting the presence of unseen creatures. A narrow path weaves through the trees, leading west to a mysterious cave and north down into a secluded valley.",
    "W=cave,N=valley"),

new("cave",
    "You step into the dimly lit confines of a cave. The air is cool and damp, the walls glistening with moisture. Echoes of your footsteps bounce off the rocky surfaces, amplifying the silence that envelops you. Stalactites and stalagmites form natural sculptures, creating an eerie, otherworldly landscape. The cave narrows to an exit to the east, leading back to the forest you came from.",
    "E=forest"),

new("valley",
    "You are in a lush, sprawling valley that unfolds beneath the shadow of the surrounding mountains. Vibrant green foliage blankets the landscape, dotted with wildflowers that sway gently in the breeze. In the distance, a quaint village emerges, its rooftops peeking through the greenery. A sense of peace pervades the air, inviting you to explore further. Paths lead south back towards the forest and north towards the heart of the village.",
    "S=forest,N=village"),

new("village",
    "You find yourself in the heart of a bustling village. Cobblestone streets wind between rows of charming, thatched-roof cottages. Villagers go about their day, their voices a blend of laughter, chatter, and the clinking of tools. The aroma of freshly baked bread and simmering stews wafts through the air, leading you towards a cozy tavern. The village opens up to the south back into the valley, while a path to the north leads to the ocean. An intriguing tavern invites exploration nearby.",
    "S=valley,N=ocean,I=tavern"),

new("ocean",
    "You arrive at the edge of the ocean, where the land meets the endless expanse of water. The rhythmic crash of waves against the shore fills the air, accompanied by the cries of seagulls overhead. The horizon stretches infinitely, a blend of blues and greens under the wide sky. The salt in the air is palpable, mingling with the scent of seaweed and sand. Behind you, to the south, lies the path back to the village.",
    "S=village"),

new("tavern",
    "You enter the tavern, a warm and welcoming space filled with the murmur of conversations and the clinking of glasses. The air is rich with the smell of roasting meat and spiced ale. Around you, patrons laugh and share stories, their faces illuminated by the flickering light of candles and hearths. The tavern keeper nods in greeting, standing behind a well-worn wooden bar. The only exit leads back outside, to the village.",
    "O=village")
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

