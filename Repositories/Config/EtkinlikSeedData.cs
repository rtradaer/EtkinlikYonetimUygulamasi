using Entities.Models;

namespace Repositories.Config;

public static class EtkinlikSeedData
{
    public static Etkinlik GetEtkinlikler(int index)
    {

        Etkinlik[] etkinlikler =
        {
                new Etkinlik
                {
                    Id = 1,
                    Title = "Yazılım Zirvesi 2025",
                    ShortDescription = "Yazılım dünyasının önde gelen isimleriyle buluşma.",
                    LongDescription = "Yazılım sektöründeki en güncel gelişmelerin konuşulacağı, atölye ve panellerin düzenleneceği büyük bir etkinlik.",
                    ImageUrl = string.Empty,
                    StartDate = new DateTime(2025, 9, 10, 10, 0, 0),
                    EndDate = new DateTime(2025, 9, 10, 18, 0, 0),
                    CreatedAt = DateTime.Now.AddDays(-10),
                    IsActive = true
                },
                new Etkinlik
                {
                    Id = 2,
                    Title = "Girişimcilik Atölyesi",
                    ShortDescription = "Girişimcilik üzerine uygulamalı eğitim.",
                    LongDescription = "Katılımcılar, iş fikri geliştirme ve sunum teknikleri üzerine eğitim alacaklar.",
                    ImageUrl = string.Empty,
                    StartDate = new DateTime(2025, 10, 5, 13, 0, 0),
                    EndDate = new DateTime(2025, 10, 5, 17, 0, 0),
                    CreatedAt = DateTime.Now.AddDays(-7),
                    IsActive = true
                },
                new Etkinlik
                {
                    Id = 3,
                    Title = "Teknoloji ve Sanat Sergisi",
                    ShortDescription = "Teknoloji ile sanatın buluştuğu sergi.",
                    LongDescription = "Yenilikçi sanat eserlerinin ve teknolojik ürünlerin sergileneceği bir etkinlik.",
                    ImageUrl = string.Empty,
                    StartDate = new DateTime(2025, 11, 20, 11, 0, 0),
                    EndDate = new DateTime(2025, 11, 20, 19, 0, 0),
                    CreatedAt = DateTime.Now.AddDays(-5),
                    IsActive = true
                },
                new Etkinlik
                {
                    Id = 4,
                    Title = "Kariyer Günü",
                    ShortDescription = "Farklı sektörlerden firmalarla tanışma fırsatı.",
                    LongDescription = "Katılımcılar, firmalarla birebir görüşme ve iş/staj başvurusu yapma imkanı bulacaklar.",
                    ImageUrl = string.Empty,
                    StartDate = new DateTime(2025, 9, 25, 9, 0, 0),
                    EndDate = new DateTime(2025, 9, 25, 17, 0, 0),
                    CreatedAt = DateTime.Now.AddDays(-3),
                    IsActive = true
                },
                new Etkinlik
                {
                    Id = 5,
                    Title = "Mobil Uygulama Geliştirme Eğitimi",
                    ShortDescription = "Mobil uygulama geliştirme temelleri.",
                    LongDescription = "Katılımcılar, mobil uygulama geliştirme süreçlerini uygulamalı olarak öğrenecekler.",
                    ImageUrl = string.Empty,
                    StartDate = new DateTime(2025, 12, 2, 14, 0, 0),
                    EndDate = new DateTime(2025, 12, 2, 18, 0, 0),
                    CreatedAt = DateTime.Now.AddDays(-2),
                    IsActive = true
                },
                new Etkinlik
                {
                    Id = 6,
                    Title = "Yapay Zeka Paneli",
                    ShortDescription = "Yapay zeka alanındaki güncel gelişmeler.",
                    LongDescription = "Uzman konuşmacılarla yapay zeka teknolojilerinin bugünü ve geleceği tartışılacak.",
                    ImageUrl = string.Empty,
                    StartDate = new DateTime(2025, 9, 15, 15, 0, 0),
                    EndDate = new DateTime(2025, 9, 15, 18, 0, 0),
                    CreatedAt = DateTime.Now.AddDays(-1),
                    IsActive = true
                }
            };

        return etkinlikler[index];
    }
}
