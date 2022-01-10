using Microsoft.EntityFrameworkCore;
using Projekti_TI_2_Posta.Domain.Entities;
using Projekti_TI_2_Posta.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Infrastructure.Presistence.Repository
{
    public class PorosiaRepository : IPorosiaRepository
    {
        private readonly PostaDbContext _db;
        public PorosiaRepository(PostaDbContext db)
        {
            _db = db;
        }
        public void CreatePorosi(Porosia porosia)
        {
            porosia.InsertData = DateTime.Now;
            porosia.Pagesa = 2;
            _db.Porosias.Add(porosia);
            porosia.ERegjistruar = false;
            _db.SaveChanges();
        }

        public void DeletePorosi(int id)
        {
            var porosia = _db.Porosias.FirstOrDefault(x => x.ID == id);
            _db.Porosias.Remove(porosia);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Porosia>> GetAllPorosi(string userid, string postierid,string search)
        {
            if(userid != null)
            {
                return await _db.Porosias.Where(x => x.UserID == userid).ToListAsync();
            }
            else if(postierid != null)
            {
                return await _db.Porosias.Where(x => x.PostierID == postierid).ToListAsync();
            }
            else if(search!= null)
            {
                return await _db.Porosias.Where(x => x.Emertimi.Contains(search)).ToListAsync();
            }
            return await _db.Porosias.ToListAsync();
        }

        public async Task<Porosia> GetPorosiaById(int id)
        {
            return await _db.Porosias.FindAsync(id);
        }

        public void UpdatePorosi(Porosia porosi)
        {
            porosi.LUD = DateTime.Now;
            _db.Porosias.Update(porosi);
            _db.SaveChanges();
        }
    }
}
