using Festival.Data.Models;

namespace Festival.Data.Repositories
{
    public class LoggingRepository : ILoggingRepository
    {
        private readonly FestivalContext _context;

        public LoggingRepository(FestivalContext context)
        {
            _context = context;
        }

        public void Add(ExceptionLogger log)
        {
            _context.ExceptionLoggers.Add(log);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}