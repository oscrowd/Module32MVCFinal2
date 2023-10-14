using Module32MVCFinal2.Models.Db.Entities;

namespace Module32MVCFinal2.Models.Db.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
