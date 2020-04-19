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
                    UserId = 2L,
                    Location = "КПІ",
                    Message = "Один з найкращих навчальних закладів України! Дуже пишаюся своє альма-матер."
                });

                // hostel 20
                x.HasData(new
                {
                    Id = 2L,
                    PointId = 2L,
                    UserId = 3L,
                    Location = "Гуртожиток 20",
                    Message = "Гуртожиток для студентів КПІ різних факультетів. Одна з трьох так званих \"книжок\". Не найсприятливіші умови для проживання, але обирати не доводиться."
                });

                // polyana
                x.HasData(new
                {
                    Id = 3L,
                    PointId = 3L,
                    UserId = 4L,
                    Location = "Сквер Поляна",
                    Message = "Одне з найвідоміших місць для відпочинку студентів! Але потрібно бути обережним з відпочинком та не втрачати голову! Дівчатам краще не ходити тут вночі! Бережіть себе!"
                });

                // Poltava
                x.HasData(new
                {
                    Id = 4L,
                    PointId = 4L,
                    UserId = 2L,
                    Location = "Полтава",
                    Message = "Рідне місто! Завжди залишає тільки теплі враження та допомгає відпочити!"
                });

                // Odessa
                x.HasData(new
                {
                    Id = 5L,
                    PointId = 5L,
                    UserId = 3L,
                    Location = "Одеса",
                    Message = "Колоритне місто біля Чорного моря. Дуже смачна риба та пиво!"
                });

                // Lviv
                x.HasData(new
                {
                    Id = 6L,
                    PointId = 6L,
                    UserId = 4L,
                    Location = "Львів",
                    Message = "Мабуть єдине місце у світі, що наскрізь пропахло кавоя та шоколадом. Обожнюю!"
                });

                // Black Sea Treasure
                x.HasData(new
                {
                    Id = 7L,
                    PointId = 7L,
                    UserId = 2L,
                    Location = "Води Чорного моря",
                    Message = "За старою легендою, ось тут на дні розташовні скарби піратів, що грабували королів ..."
                });

                // Poltava Galushki
                x.HasData(new
                {
                    Id = 8L,
                    PointId = 4L,
                    UserId = 3L,
                    Location = "Полтава",
                    Message = "Тут готують найсмачніші галушки!!!"
                });

                // hostel 20
                x.HasData(new
                {
                    Id = 9L,
                    PointId = 2L,
                    UserId = 1L,
                    Location = "Гуртожиток 20 (5 поверх)",
                    Message = "Живу у цьому гуртожитку вже достатньо довго і можу скзазати, що умови спартанські ..."
                });

                // Vokzal
                x.HasData(new
                {
                    Id = 10L,
                    PointId = 8L,
                    UserId = 3L,
                    Location = "",
                    Message = "Жахливе та неопртяне місце. Досить брудно та смердить. Шкода, що таким є головний вокзал країни."
                });
                x.HasData(new
                {
                    Id = 11L,
                    PointId = 8L,
                    UserId = 4L,
                    Location = "",
                    Message = "Чув багато про аферистів, але не надава ніякої уваги, доки сам не зіштовхнувся."
                });
                x.HasData(new
                {
                    Id = 12L,
                    PointId = 8L,
                    UserId = 5L,
                    Location = "",
                    Message = "Поруч гарнорозвинена інфраструктура. А саме в пішій доступності знаходиться метро, заклади харчування, а також саме місто."
                });

                // Krest
                x.HasData(new
                {
                    Id = 13L,
                    PointId = 9L,
                    UserId = 6L,
                    Location = "",
                    Message = "Головна вулиця країни, де завжди вирує життя, а молодь гуляє цілодобово"
                });
                x.HasData(new
                {
                    Id = 14L,
                    PointId = 9L,
                    UserId = 7L,
                    Location = "",
                    Message = "Обожнюю фонтани з підсвіткою. Це неймовірна атмосфера, що надихає і підіймає настрій!!!"
                });

                // Truhanov
                x.HasData(new
                {
                    Id = 15L,
                    PointId = 10L,
                    UserId = 8L,
                    Location = "",
                    Message = "Природній закуток у самому центрі міста. Ідеально для пробіжок та активного відпочинку!"
                });

                // Red university
                x.HasData(new
                {
                    Id = 16L,
                    PointId = 11L,
                    UserId = 9L,
                    Location = "",
                    Message = "Будівля з віковою історією. Навчила не один десяток поколінь українців та їх дітей"
                });

                // National Opera
                x.HasData(new
                {
                    Id = 17L,
                    PointId = 12L,
                    UserId = 10L,
                    Location = "",
                    Message = "Архітектура будівлі вражає с першого погляду, а внутрішнє оздоблення просто неперевершене"
                });

                // Hidropark
                x.HasData(new
                {
                    Id = 18L,
                    PointId = 13L,
                    UserId = 2L,
                    Location = "",
                    Message = "Дуже хотілось би, щоб Гідропарк був більш чистим та облаштованим"
                });

                // Petrovka
                x.HasData(new
                {
                    Id = 19L,
                    PointId = 14L,
                    UserId = 3L,
                    Location = "",
                    Message = "Люблю відвідувати місцевий ринок. Завжди можна знайти щось цікаве. Особоливо великий вибір книг!"
                });

                // Olympic stadium
                x.HasData(new
                {
                    Id = 20L,
                    PointId = 15L,
                    UserId = 4L,
                    Location = "",
                    Message = "Величезний стадіон. Був на матчі Шахтар-Динамо, то дуже сподобалося."
                });

                // Zhuliany
                x.HasData(new
                {
                    Id = 21L,
                    PointId = 16L,
                    UserId = 5L,
                    Location = "",
                    Message = ""
                });

                // Protasiv
                x.HasData(new
                {
                    Id = 22L,
                    PointId = 17L,
                    UserId = 6L,
                    Location = "",
                    Message = ""
                });

                // NAU
                x.HasData(new
                {
                    Id = 23L,
                    PointId = 18L,
                    UserId = 7L,
                    Location = "",
                    Message = ""
                });
                x.HasData(new
                {
                    Id = 24L,
                    PointId = 18L,
                    UserId = 8L,
                    Location = "",
                    Message = ""
                });

                // TSUM
                x.HasData(new
                {
                    Id = 25L,
                    PointId = 19L,
                    UserId = 9L,
                    Location = "",
                    Message = ""
                });
                x.HasData(new
                {
                    Id = 26L,
                    PointId = 19L,
                    UserId = 10L,
                    Location = "",
                    Message = ""
                });

                // Cycletrack
                x.HasData(new
                {
                    Id = 27L,
                    PointId = 20L,
                    UserId = 1L,
                    Location = "",
                    Message = ""
                });
                x.HasData(new
                {
                    Id = 28L,
                    PointId = 20L,
                    UserId = 2L,
                    Location = "",
                    Message = ""
                });

                // Nationa Circus
                x.HasData(new
                {
                    Id = 29L,
                    PointId = 21L,
                    UserId = 3L,
                    Location = "",
                    Message = ""
                });

                // Shulia bridge
                x.HasData(new
                {
                    Id = 30L,
                    PointId = 22L,
                    UserId = 4L,
                    Location = "",
                    Message = ""
                });

                // Oceanarium
                x.HasData(new
                {
                    Id = 31L,
                    PointId = 23L,
                    UserId = 5L,
                    Location = "",
                    Message = ""
                });

                // Troya
                x.HasData(new
                {
                    Id = 32L,
                    PointId = 24L,
                    UserId = 6L,
                    Location = "",
                    Message = ""
                });

                // Kyiv Pechersk LAvra
                x.HasData(new
                {
                    Id = 33L,
                    PointId = 25L,
                    UserId = 7L,
                    Location = "",
                    Message = ""
                });

                // Ocean Plaza
                x.HasData(new
                {
                    Id = 34L,
                    PointId = 26L,
                    UserId = 1L,
                    Location = "ТРЦ \"Ocean Plaza\"",
                    Message = "Найкраще місце для шопінгу у Києві. Величезна кількість магазинів та гарна ціна!"
                });
            });
        }
    }
}
