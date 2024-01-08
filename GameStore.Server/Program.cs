using GameStore.Server.Models;

List<Game> games = new()
    {
        new Game() 
        {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99M,
            ReleaseDate = new DateTime(1991, 2, 1)
        },
        new Game() 
        {
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "RPG",
            Price = 59.99M,
            ReleaseDate = new DateTime(2010, 9, 30)
        },
        new Game() 
        {
            Id = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 69.99M,
            ReleaseDate = new DateTime(2022, 9, 27)
        },
    };

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("/games");

// GET /games
group.MapGet("/", () => games);

// GET /games/{id}
group.MapGet("/{id}", (int id) => 
{
    Game? game = games.Find(x => x.Id == id);
    if (game is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(game);
})
.WithName("GetGame");

// POST /games
group.MapPost("/", (Game game) => 
{
    game.Id = games.Max(x => x.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game);
});

app.Run();
