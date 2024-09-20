using Microsoft.EntityFrameworkCore;
using MultiTierArchitecture.DataAccess.Abstract;
using MultiTierArchitecture.Entities;

namespace MultiTierArchitecture.DataAccess.Concrete
{
    public class ContentRepository : IContentRepository
    {
        private readonly AppDbContext _context;

        public ContentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Content content)
        {
            await _context.Contents.AddAsync(content);
        }
        public async Task<IEnumerable<Content>> GetAllAsync()
        {
            return await _context.Contents.ToListAsync();
        }
        public async Task<Content> GetByIdAsync(int id)
        {
            return await _context.Contents.FindAsync(id); // ID'ye göre içerik bul
        }

        public void Update(Content content)
        {
            _context.Contents.Update(content); // İçeriği güncelle
        }
        public void Delete(Content content)
        {
            _context.Contents.Remove(content); // İçeriği sil
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
