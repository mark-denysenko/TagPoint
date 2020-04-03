using Domain.Post;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Post
{
    internal static class PostsSeed
    {
        public static void SeedPosts(this ModelBuilder builder)
        {
            builder.Entity<PostEntity>(x =>
            {
                // KPI
                x.HasData(new
                {
                    Id = 1L,
                    PointId = 1L,
                    UserId = 1L,
                    Message = "Один з найкращих навчальних закладів України! Дуже пишаюся своє альма-матер."
                });

                // hostel 20
                x.HasData(new
                {
                    Id = 2L,
                    PointId = 2L,
                    UserId = 1L,
                    Message = "Гуртожиток для студентів КПІ різних факультетів. Одна з трьох так званих \"книжок\". Не найсприятливіші умови для проживання, але обирати не доводиться."
                });

                // polyana
                x.HasData(new
                {
                    Id = 3L,
                    PointId = 3L,
                    UserId = 1L,
                    Message = "Одне з найвідоміших місць для відпочинку студентів! Але потрібно бути обережним з відпочинком та не втрачати голову! Дівчатам краще не ходити тут вночі! Бережіть себе!"
                });

                // Poltava
                x.HasData(new
                {
                    Id = 4L,
                    PointId = 4L,
                    UserId = 1L,
                    Message = "Рідне місто! Завжди залишає тільки теплі враження та допомгає відпочити!"
                });

                // Odessa
                x.HasData(new
                {
                    Id = 5L,
                    PointId = 5L,
                    UserId = 1L,
                    Message = "Колоритне місто біля Чорного моря. Дуже смачна риба та пиво!"
                });

                // Lviv
                x.HasData(new
                {
                    Id = 6L,
                    PointId = 6L,
                    UserId = 1L,
                    Message = "Мабуть єдине місце у світі, що наскрізь пропахло кавоя та шоколадом. Обожнюю!"
                });

                // Black Sea Treasure
                x.HasData(new
                {
                    Id = 7L,
                    PointId = 7L,
                    UserId = 1L,
                    Message = "За старою легендою, ось тут на дні розташовні скарби піратів, що грабували королів ..."
                });


                // Poltava Galushki
                x.HasData(new
                {
                    Id = 8L,
                    PointId = 4L,
                    UserId = 1L,
                    Message = "Тут готують найсмачніші галушки!!!"
                });
            });
        }
    }
}
