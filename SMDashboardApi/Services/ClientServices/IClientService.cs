namespace SMDashboardApi.Services.ClientServices;

public interface IClientService
{
    PaginatedResponse<Client> GetAllClients(int pageIndex, int pageSize);
    Task<Client?> GetClientById(int id);
    Task<List<int>> GetClientIdList();
    Task<Client?> AddClient(Client client);
    Task<Client?> UpdateClient(Client client);
    Task<Client?> DeleteClient(int id);
}
