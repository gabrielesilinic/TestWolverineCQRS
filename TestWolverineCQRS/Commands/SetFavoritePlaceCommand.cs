namespace TestWolverineCQRS.Commands
{
    public static class FakeDatabase
    {
        public static string? FavoritePlace { get; set; }
    }
    public record SetFavoritePlaceCommand(string Place);

    public class SetFavoritePlaceCommandHandler
    {
        public static Task Handle(SetFavoritePlaceCommand command)
        {
            FakeDatabase.FavoritePlace = command.Place;
            return Task.CompletedTask;
        }
    }
}
