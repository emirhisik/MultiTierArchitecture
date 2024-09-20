using MultiTierArchitecture.Business.Abstract;
using MultiTierArchitecture.DataAccess.Abstract;
using MultiTierArchitecture.Entities;

namespace MultiTierArchitecture.Business.Concrete
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;

        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }
        public async Task AddAsync(Content content)
        {
            try
            {
                await _contentRepository.AddAsync(content);
                await _contentRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Hata mesajını loglayın veya döndürün
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }
        // Tüm içerikleri asenkron olarak getirme işlemi
        public async Task<IEnumerable<Content>> GetAllAsync()
        {
            return await _contentRepository.GetAllAsync();
        }
        public async Task<Content> GetByIdAsync(int id)
        {
            return await _contentRepository.GetByIdAsync(id); // ID'ye göre içerik bul
        }

        public async Task UpdateAsync(Content content)
        {
            _contentRepository.Update(content); // İçeriği güncelle
            await _contentRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var content = await GetByIdAsync(id); // Önce içerik bul
            if (content != null)
            {
                _contentRepository.Delete(content); // İçeriği sil
                await _contentRepository.SaveChangesAsync();
            }
        }
    }
}
