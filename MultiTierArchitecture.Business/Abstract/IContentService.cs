using MultiTierArchitecture.Entities;

namespace MultiTierArchitecture.Business.Abstract
{
    public interface IContentService
    {
        Task AddAsync(Content content);
        Task<IEnumerable<Content>> GetAllAsync(); // Tüm içerikleri getir
        Task<Content> GetByIdAsync(int id); // ID'ye göre içerik bul
        Task UpdateAsync(Content content); // İçeriği güncelle
        Task DeleteAsync(int id); // İçeriği sil
    }
}
