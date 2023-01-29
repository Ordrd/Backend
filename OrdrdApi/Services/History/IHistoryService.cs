namespace OrdrdApi.Services.HistoryServ
{
    public interface IHistoryService
    {
        Task<List<Order>> GetHistoryAsync(int restaurantId, int page, int pageSize);
        Task<List<Order>> FindInHistoryAsync(int restaurantId, string search);
    }
}
