using Microsoft.AspNetCore.Mvc;
using MultiTierArchitecture.Business.Abstract;
using MultiTierArchitecture.Entities;

namespace MultiTierArchitecture.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        // İçerik ekleme formunu getirmek için GET metodu
        [HttpGet]
        public IActionResult Add()
        {
            var contentModel = new Content(); // Boş bir Content nesnesi oluştur
            return View(contentModel); // Bu modeli View'a gönder
        }

        // İçerik ekleme işlemini işlemek için POST metodu
        [HttpPost]
        public async Task<IActionResult> Add(Content content)
        {
            if (ModelState.IsValid)
            {
                await _contentService.AddAsync(content); // İçeriği veri tabanına ekler
                return RedirectToAction("Index"); // Başarılı ekleme sonrası listeleme sayfasına yönlendirilir
            }

            // Eğer ModelState geçerli değilse, View'a model geri gönderilmeli
            return View(content); // Hatalı input olursa aynı form geri döner
        }

        // İçeriklerin listelenmesi için Index metodu
        public async Task<IActionResult> Index()
        {
            // await ile asenkron metodu bekle
            var contents = await _contentService.GetAllAsync();
            return View(contents); // Modeli View'a gönder
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var content = await _contentService.GetByIdAsync(id); // ID'ye göre içerik bul
            if (content == null)
            {
                return NotFound(); // Eğer içerik bulunamazsa 404 döndür
            }

            return View(content); // İçeriği View'a gönder
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Content content)
        {
            if (ModelState.IsValid)
            {
                await _contentService.UpdateAsync(content); // İçeriği güncelle
                return RedirectToAction("Index"); // Başarılı güncelleme sonrası listeleme sayfasına yönlendirilir
            }

            // Eğer ModelState geçerli değilse, form tekrar gösterilir
            return View(content);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var content = await _contentService.GetByIdAsync(id); // ID'ye göre içerik bul
            if (content == null)
            {
                return NotFound(); // Eğer içerik bulunamazsa 404 döndür
            }

            return View(content); // İçeriği silme onayı için View'a gönder
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var content = await _contentService.GetByIdAsync(id);
            if (content == null)
            {
                return NotFound(); // Eğer içerik bulunamazsa 404 döndür
            }

            await _contentService.DeleteAsync(id); // İçeriği sil
            return RedirectToAction("Index"); // Başarılı silme sonrası listeleme sayfasına yönlendirilir
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            if (upload != null && upload.Length > 0)
            {
                // Kayıt edilecek dizin (wwwroot altında admin/img klasörü)
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", upload.FileName);

                // Dosya kaydedilmeden önce aynı isimde bir dosya var mı kontrol edilir
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await upload.CopyToAsync(stream); // Dosya sunucuya kaydedilir
                    }
                }

                // Görselin URL'si (CKEditor'e geri döner)
                var url = $"/uploads/{upload.FileName}";

                return Json(new { url });
            }

            // Yükleme başarısızsa hata mesajı döner
            return Json(new { error = "Yükleme sırasında bir hata oluştu." });
        }

    }
}
