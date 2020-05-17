using Festival.Data.Models;

namespace Festival.Data.Repositories
{
    public interface ILoggingRepository
    {
        void Add(ExceptionLogger log);
        void Save();
    }
}