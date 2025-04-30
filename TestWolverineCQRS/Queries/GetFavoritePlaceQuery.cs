namespace TestWolverineCQRS.Queries
{
    public record GetFavoritePlaceQuery();

    public record GetFavoritePlaceQueryResponse(string Place);

    public class GetFavoritePlaceQueryHandler
    {
        public static Task<GetFavoritePlaceQueryResponse> Handle(GetFavoritePlaceQuery query)
        {
            var response = new GetFavoritePlaceQueryResponse(
                Place: TestWolverineCQRS.Commands.FakeDatabase.FavoritePlace ?? "Unknown"
            );
            return Task.FromResult(response);
        }
    }
}
