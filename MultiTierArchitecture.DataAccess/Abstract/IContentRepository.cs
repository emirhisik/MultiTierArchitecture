using MultiTierArchitecture.Entities;

namespace MultiTierArchitecture.DataAccess.Abstract
{
    public interface IContentRepository
    {
        Task AddAsync(Content content);
        Task SaveChangesAsync();
        Task<Content> GetByIdAsync(int id); // ID'ye göre içerik bul
        void Update(Content content); // İçeriği güncelle
        void Delete(Content content); // İçeriği sil
        Task<IEnumerable<Content>> GetAllAsync(); // Tüm içerikleri getir
    }
}
