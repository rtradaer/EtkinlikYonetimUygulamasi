using Entities.Models;

namespace Repositories.Config;

public static class EtkinlikSeedData
{
    public static Etkinlik[] GetEtkinlikler()
    {


        Etkinlik[] etkinlikler =
        {
            new Etkinlik
            {
                Id = 1,
                Title = "Yazılım Zirvesi 2025",
                ShortDescription = "Yazılım dünyasının önde gelen isimleriyle buluşma.",
                LongDescription = "Yazılım sektöründeki en güncel gelişmelerin konuşulacağı, atölye ve panellerin düzenleneceği büyük bir etkinlik.",
                ImageUrl = "/images/1.jpg",
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
                ImageUrl = "/images/2.jpg",
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
                ImageUrl = "/images/3.jpg",
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
                ImageUrl = "/images/4.jpg",
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
                ImageUrl = "/images/5.jpg",
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
                ImageUrl = "/images/6.jpg",
                StartDate = new DateTime(2025, 9, 15, 15, 0, 0),
                EndDate = new DateTime(2025, 9, 15, 18, 0, 0),
                CreatedAt = DateTime.Now.AddDays(-1),
                IsActive = true
            },
            new Etkinlik
            {
                Id = 7,
                Title = "Siber Güvenlik Semineri",
                ShortDescription = "Siber tehditler ve korunma yolları.",
                LongDescription = "Alanında uzman konuşmacılarla siber güvenlikte güncel tehditler ve alınabilecek önlemler tartışılacak.",
                ImageUrl = "/images/7.jpg",
                StartDate = new DateTime(2025, 10, 12, 10, 0, 0),
                EndDate = new DateTime(2025, 10, 12, 16, 0, 0),
                CreatedAt = DateTime.Now.AddDays(-8),
                IsActive = true
            },
            new Etkinlik
            {
                Id = 8,
                Title = "Veri Bilimi Çalıştayı",
                ShortDescription = "Veri analizi ve makine öğrenmesi uygulamaları.",
                LongDescription = "Katılımcılar, veri bilimi projelerinde kullanılan araçları ve teknikleri uygulamalı olarak öğrenecekler.",
                ImageUrl = "/images/8.jpg",
                StartDate = new DateTime(2025, 11, 5, 9, 0, 0),
                EndDate = new DateTime(2025, 11, 5, 17, 0, 0),
                CreatedAt = DateTime.Now.AddDays(-6),
                IsActive = true
            },
            new Etkinlik
            {
                Id = 9,
                Title = "Oyun Geliştirme Hackathonu",
                ShortDescription = "24 saatlik oyun geliştirme maratonu.",
                LongDescription = "Takımlar halinde katılımcılar, 24 saat boyunca kendi oyunlarını geliştirecekler ve jüriye sunacaklar.",
                ImageUrl = "/images/9.jpg",
                StartDate = new DateTime(2025, 12, 10, 12, 0, 0),
                EndDate = new DateTime(2025, 12, 11, 12, 0, 0),
                CreatedAt = DateTime.Now.AddDays(-4),
                IsActive = true
            },
            new Etkinlik
            {
                Id = 10,
                Title = "Yapay Zeka ile Görüntü İşleme",
                ShortDescription = "Görüntü işleme ve yapay zeka uygulamaları.",
                LongDescription = "Görüntü işleme alanında yapay zekanın kullanımı ve örnek projeler anlatılacak.",
                ImageUrl = "/images/10.jpg",
                StartDate = new DateTime(2025, 10, 20, 14, 0, 0),
                EndDate = new DateTime(2025, 10, 20, 18, 0, 0),
                CreatedAt = DateTime.Now.AddDays(-9),
                IsActive = true
            },
            new Etkinlik
            {
                Id = 11,
                Title = "Blockchain Teknolojileri Paneli",
                ShortDescription = "Blockchain ve kripto paralar üzerine panel.",
                LongDescription = "Blockchain teknolojisinin geleceği ve kripto paraların sektöre etkisi uzmanlar tarafından tartışılacak.",
                ImageUrl = "/images/11.jpg",
                StartDate = new DateTime(2025, 11, 15, 16, 0, 0),
                EndDate = new DateTime(2025, 11, 15, 19, 0, 0),
                CreatedAt = DateTime.Now.AddDays(-7),
                IsActive = true
            }
        };

        return etkinlikler;
    }
}
