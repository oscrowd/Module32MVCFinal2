using Module32MVCFinal2.Models.Db.Entities;

namespace Module32MVCFinal2.Models.Db.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);

        Task<Request[]> GetRequests();
    }
}
