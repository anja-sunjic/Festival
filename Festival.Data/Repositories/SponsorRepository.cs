using System;
using Festival.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class SponsorRepository : ISponzorRepository
    {
        private readonly FestivalContext context;

        public SponsorRepository(FestivalContext context)
        {
            this.context = context;
        }

        public void Add(Sponsor sponsor)
        {
            context.Sponsor.Add(sponsor);
            Save();
        }

        public void Delete(int id)
        {
            var sponsor = context.Sponsor.Find(id);
            if (sponsor == null) throw new Exception($"Can't find sponsor with Id: {id}");

            context.Sponsor.Remove(sponsor);
            Save();
        }

        public List<Sponsor> GetAll()
        {
            return context.Sponsor.ToList();
        }

        public Sponsor GetByID(int id)
        {
            Sponsor sponsor = null;
            if(sponsor == null) throw new Exception($"Can't find sponsor with Id: {id}");

            return sponsor;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
