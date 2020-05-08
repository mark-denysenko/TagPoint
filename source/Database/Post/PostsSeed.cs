using Domain.Post;
using Domain.Vote;
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
            SeedTags(builder);

            builder.Entity<PostEntity>(x =>
            {
                // KPI
                x.HasData(new
                {
                    Id = 1L,
                    PointId = 1L,
                    UserId = 2L,
                    Recommended = true,
                    Location = "КПІ",
                    Message = "Один з найкращих навчальних закладів України! Дуже пишаюся своє альма-матер."
                });

                // hostel 20
                x.HasData(new
                {
                    Id = 2L,
                    PointId = 2L,
                    UserId = 3L,
                    Recommended = true,
                    Location = "Гуртожиток 20",
                    Message = "Гуртожиток для студентів КПІ різних факультетів. Одна з трьох так званих \"книжок\". Не найсприятливіші умови для проживання, але обирати не доводиться."
                });

                // polyana
                x.HasData(new
                {
                    Id = 3L,
                    PointId = 3L,
                    UserId = 4L,
                    Recommended = true,
                    Location = "Сквер Поляна",
                    Message = "Одне з найвідоміших місць для відпочинку студентів! Але потрібно бути обережним з відпочинком та не втрачати голову! Дівчатам краще не ходити тут вночі! Бережіть себе!"
                });

                // Poltava
                x.HasData(new
                {
                    Id = 4L,
                    PointId = 4L,
                    UserId = 2L,
                    Recommended = true,
                    Location = "Полтава",
                    Message = "Рідне місто! Завжди залишає тільки теплі враження та допомгає відпочити!"
                });

                // Odessa
                x.HasData(new
                {
                    Id = 5L,
                    PointId = 5L,
                    UserId = 3L,
                    Recommended = true,
                    Location = "Одеса",
                    Message = "Колоритне місто біля Чорного моря. Дуже смачна риба та пиво!"
                });

                // Lviv
                x.HasData(new
                {
                    Id = 6L,
                    PointId = 6L,
                    UserId = 4L,
                    Recommended = true,
                    Location = "Львів",
                    Message = "Мабуть єдине місце у світі, що наскрізь пропахло кавою та шоколадом. Обожнюю!"
                });

                // Black Sea Treasure
                x.HasData(new
                {
                    Id = 7L,
                    PointId = 7L,
                    UserId = 2L,
                    Recommended = true,
                    Location = "Води Чорного моря",
                    Message = "Гарне місце для дайвінгу! Вода дуже чиста та велике різноманіття риб."
                });

                // Poltava Galushki
                x.HasData(new
                {
                    Id = 8L,
                    PointId = 4L,
                    UserId = 3L,
                    Recommended = true,
                    Location = "Полтава",
                    Message = "Тут готують найсмачніші галушки!!! Варто хоча б раз спробувати"
                });

                // hostel 20
                x.HasData(new
                {
                    Id = 9L,
                    PointId = 2L,
                    UserId = 1L,
                    Recommended = false,
                    Location = "Гуртожиток 20 (5 поверх)",
                    Message = "Живу у цьому гуртожитку вже достатньо довго і можу скзазати, що умови спартанські ..."
                });

                // Vokzal
                x.HasData(new
                {
                    Id = 10L,
                    PointId = 8L,
                    UserId = 3L,
                    Recommended = false,
                    Location = "Центральний вокзал",
                    Message = "Жахливе та неопртяне місце. Досить брудно та смердить. Шкода, що таким є головний вокзал країни."
                });
                x.HasData(new
                {
                    Id = 11L,
                    PointId = 8L,
                    UserId = 4L,
                    Recommended = true,
                    Location = "Площа вокзалу",
                    Message = "Чув багато про аферистів, але не надавав ніякої уваги, доки сам не зіштовхнувся."
                });
                x.HasData(new
                {
                    Id = 12L,
                    PointId = 8L,
                    UserId = 5L,
                    Recommended = true,
                    Location = "Площа вокзалу",
                    Message = "Поруч гарнорозвинена інфраструктура. А саме в пішій доступності знаходиться метро, заклади харчування, а також саме місто."
                });

                // Krest
                x.HasData(new
                {
                    Id = 13L,
                    PointId = 9L,
                    UserId = 6L,
                    Recommended = true,
                    Location = "вул. Крещатик",
                    Message = "Головна вулиця країни, де завжди вирує життя, а молодь гуляє цілодобово"
                });
                x.HasData(new
                {
                    Id = 14L,
                    PointId = 9L,
                    UserId = 7L,
                    Recommended = true,
                    Location = "Фонтани",
                    Message = "Обожнюю фонтани з підсвіткою. Це неймовірна атмосфера, що надихає і підіймає настрій!!!"
                });

                // Truhanov
                x.HasData(new
                {
                    Id = 15L,
                    PointId = 10L,
                    UserId = 8L,
                    Recommended = true,
                    Location = "Труханів острів",
                    Message = "Природній закуток у самому центрі міста. Ідеально для пробіжок та активного відпочинку!"
                });

                // Red university
                x.HasData(new
                {
                    Id = 16L,
                    PointId = 11L,
                    UserId = 9L,
                    Recommended = true,
                    Location = "Червона будівля",
                    Message = "Будівля з віковою історією. Навчила не один десяток поколінь українців та їх дітей"
                });

                // National Opera
                x.HasData(new
                {
                    Id = 17L,
                    PointId = 12L,
                    UserId = 10L,
                    Recommended = true,
                    Location = "Національна Опера",
                    Message = "Архітектура будівлі вражає с першого погляду, а внутрішнє оздоблення просто неперевершене"
                });

                // Hidropark
                x.HasData(new
                {
                    Id = 18L,
                    PointId = 13L,
                    UserId = 2L,
                    Recommended = false,
                    Location = "Гідропарк",
                    Message = "Дуже хотілось би, щоб Гідропарк був більш чистим та облаштованим"
                });

                // Petrovka
                x.HasData(new
                {
                    Id = 19L,
                    PointId = 14L,
                    UserId = 3L,
                    Recommended = true,
                    Location = "Ринок",
                    Message = "Люблю відвідувати місцевий ринок. Завжди можна знайти щось цікаве. Особоливо великий вибір книг!"
                });

                // Olympic stadium
                x.HasData(new
                {
                    Id = 20L,
                    PointId = 15L,
                    UserId = 4L,
                    Recommended = true,
                    Location = "стадіон \"Олімпійский\"",
                    Message = "Величезний стадіон. Був на матчі Шахтар-Динамо, то дуже сподобалося."
                });

                // Zhuliany
                x.HasData(new
                {
                    Id = 21L,
                    PointId = 16L,
                    UserId = 5L,
                    Recommended = true,
                    Location = "аеропорт Жуляни",
                    Message = "Сучасний аеропорт з достатньо кільксть місця та зручним розташуванням. Вже не раз доводилося користуватися, тому суб'єктивно дуже гарно!"
                });

                // Protasiv
                x.HasData(new
                {
                    Id = 22L,
                    PointId = 17L,
                    UserId = 6L,
                    Recommended = true,
                    Location = "Протасів Яр",
                    Message = "Взимку єдине місце, де можна хоча б на мить відчути драйв від катання на лижах або сноуборді!"
                });

                // NAU
                x.HasData(new
                {
                    Id = 23L,
                    PointId = 18L,
                    UserId = 7L,
                    Recommended = false,
                    Location = "НАУ",
                    Message = "Непоганий унівесритет, але якщо хочеш знань, то краще КПІ ..."
                });
                x.HasData(new
                {
                    Id = 24L,
                    PointId = 18L,
                    UserId = 8L,
                    Recommended = true,
                    Location = "Національний Авіаційний Університет",
                    Message = "Вищий навчальний заклад без особливих відзнак, є й кращі!"
                });

                // TSUM
                x.HasData(new
                {
                    Id = 25L,
                    PointId = 19L,
                    UserId = 9L,
                    Recommended = true,
                    Location = "ЦУМ",
                    Message = "Найбільший вибір люксових брендів у столиці. Інколи бувають знижки."
                });
                x.HasData(new
                {
                    Id = 26L,
                    PointId = 19L,
                    UserId = 10L,
                    Recommended = false,
                    Location = "ЦУМ",
                    Message = "Дуже дорого!!! Не для звичайних людей"
                });

                // Cycletrack
                x.HasData(new
                {
                    Id = 27L,
                    PointId = 20L,
                    UserId = 1L,
                    Recommended = true,
                    Location = "Київський велотрек",
                    Message = "Сучасний велотрек. Постійно тренуються різні покоління гонщиків. Також вдалося споглядати один з чемпіонатів. Можу сказати тільки, що пройшов на найвищому рівні"
                });
                x.HasData(new
                {
                    Id = 28L,
                    PointId = 20L,
                    UserId = 2L,
                    Recommended = true,
                    Location = "Київський велотрек",
                    Message = "Найулюбленіше місце для прогулянки. Обожнюююю"
                });

                // Nationa Circus
                x.HasData(new
                {
                    Id = 29L,
                    PointId = 21L,
                    UserId = 3L,
                    Recommended = true,
                    Location = "Національний цирк України",
                    Message = "Був приємно вражений рівнем видовища. Українські артисти були на висоті!"
                });

                // Shulia bridge
                x.HasData(new
                {
                    Id = 30L,
                    PointId = 22L,
                    UserId = 4L,
                    Recommended = false,
                    Location = "Шулявський міст",
                    Message = "Вічне будівництво, неможливо проїхати без затору =("
                });

                // Oceanarium
                x.HasData(new
                {
                    Id = 31L,
                    PointId = 23L,
                    UserId = 5L,
                    Recommended = true,
                    Location = "Океанаріум",
                    Message = "Захоплююча місце, де можна помилуватися мешканцями як прісних, так і морських водойм з різних куточків нашої планети. Крім того, що є можливість порадувати око, також ви зможете дізнатися цікаві факти про різних телефонах риб та інших мешканців водних глибин. Діти не залишаться байдужими від відвідування Океанаріума."
                });

                // Troya
                x.HasData(new
                {
                    Id = 32L,
                    PointId = 24L,
                    UserId = 6L,
                    Recommended = true,
                    Location = "Троєщина",
                    Message = "Троєщина - історична місцевість міста Києва на лівому березі Дніпра. Простягається вздовж річки Десенки в сторону річки Десна, поблизу урочища Бобровня. Є продовженням колишнього села Вигурівщина. Поселення тут існували з часів неоліту"
                });

                // Kyiv Pechersk LAvra
                x.HasData(new
                {
                    Id = 33L,
                    PointId = 25L,
                    UserId = 7L,
                    Recommended = true,
                    Location = "Києво-Печерська Лавра",
                    Message = "Один з перших по часу заснування монастирів Київської Русі. Одна з найважливіших православних святинь, третій Доля Богородиці. Печерський монастир був заснований в 1051 році при Ярославі Мудрому монахом Антонієм, родом з Любеча, і його учнем Феодосієм"
                });

                // Ocean Plaza
                x.HasData(new
                {
                    Id = 34L,
                    PointId = 26L,
                    UserId = 1L,
                    Recommended = true,
                    Location = "ТРЦ \"Ocean Plaza\"",
                    Message = "Найкраще місце для шопінгу у Києві. Величезна кількість магазинів та гарна ціна!"
                });
            });

            // Likes
            builder.Entity<LikeEntity>(x =>
            {
                x.HasData(new { UserId = 1L, PostId = 1L });
                x.HasData(new { UserId = 1L, PostId = 2L });
                x.HasData(new { UserId = 1L, PostId = 3L });
                x.HasData(new { UserId = 1L, PostId = 4L });
                x.HasData(new { UserId = 1L, PostId = 5L });
                x.HasData(new { UserId = 1L, PostId = 6L });
                x.HasData(new { UserId = 1L, PostId = 7L });
                x.HasData(new { UserId = 1L, PostId = 8L });
                x.HasData(new { UserId = 1L, PostId = 9L });
                x.HasData(new { UserId = 1L, PostId = 34L });

                x.HasData(new { UserId = 2L, PostId = 1L });
                x.HasData(new { UserId = 2L, PostId = 2L });
                x.HasData(new { UserId = 2L, PostId = 3L });
                x.HasData(new { UserId = 2L, PostId = 4L });
                x.HasData(new { UserId = 2L, PostId = 5L });
                x.HasData(new { UserId = 2L, PostId = 6L });
                x.HasData(new { UserId = 2L, PostId = 7L });
                x.HasData(new { UserId = 2L, PostId = 8L });
                x.HasData(new { UserId = 2L, PostId = 9L });
                x.HasData(new { UserId = 2L, PostId = 34L });

                x.HasData(new { UserId = 3L, PostId = 1L });
                x.HasData(new { UserId = 3L, PostId = 2L });
                x.HasData(new { UserId = 3L, PostId = 3L });
                x.HasData(new { UserId = 3L, PostId = 4L });
                x.HasData(new { UserId = 3L, PostId = 5L });
                x.HasData(new { UserId = 3L, PostId = 6L });
                x.HasData(new { UserId = 3L, PostId = 7L });
                x.HasData(new { UserId = 3L, PostId = 8L });
                x.HasData(new { UserId = 3L, PostId = 9L });
                x.HasData(new { UserId = 3L, PostId = 34L });

                x.HasData(new { UserId = 4L, PostId = 1L });
                x.HasData(new { UserId = 4L, PostId = 2L });
                x.HasData(new { UserId = 4L, PostId = 3L });
                x.HasData(new { UserId = 4L, PostId = 4L });
                x.HasData(new { UserId = 4L, PostId = 5L });
                x.HasData(new { UserId = 4L, PostId = 6L });
                x.HasData(new { UserId = 4L, PostId = 7L });
                x.HasData(new { UserId = 4L, PostId = 8L });
                x.HasData(new { UserId = 4L, PostId = 9L });
                x.HasData(new { UserId = 4L, PostId = 34L });

                x.HasData(new { UserId = 5L, PostId = 1L });
                x.HasData(new { UserId = 5L, PostId = 2L });
                x.HasData(new { UserId = 5L, PostId = 3L });
                x.HasData(new { UserId = 5L, PostId = 4L });
                x.HasData(new { UserId = 5L, PostId = 5L });
                x.HasData(new { UserId = 5L, PostId = 6L });
                x.HasData(new { UserId = 5L, PostId = 7L });
                x.HasData(new { UserId = 5L, PostId = 8L });
                x.HasData(new { UserId = 5L, PostId = 34L });

                x.HasData(new { UserId = 6L, PostId = 1L });
                x.HasData(new { UserId = 6L, PostId = 2L });
                x.HasData(new { UserId = 6L, PostId = 3L });
                x.HasData(new { UserId = 6L, PostId = 4L });
                x.HasData(new { UserId = 6L, PostId = 5L });
                x.HasData(new { UserId = 6L, PostId = 6L });
                x.HasData(new { UserId = 6L, PostId = 7L });
                x.HasData(new { UserId = 6L, PostId = 8L });
                x.HasData(new { UserId = 6L, PostId = 34L });

                x.HasData(new { UserId = 7L, PostId = 9L });
                x.HasData(new { UserId = 7L, PostId = 10L });
                x.HasData(new { UserId = 7L, PostId = 11L });
                x.HasData(new { UserId = 7L, PostId = 12L });
                x.HasData(new { UserId = 7L, PostId = 13L });
                x.HasData(new { UserId = 7L, PostId = 14L });
                x.HasData(new { UserId = 7L, PostId = 15L });
                x.HasData(new { UserId = 7L, PostId = 16L });
                x.HasData(new { UserId = 7L, PostId = 17L });

                x.HasData(new { UserId = 8L, PostId = 18L });
                x.HasData(new { UserId = 8L, PostId = 19L });
                x.HasData(new { UserId = 8L, PostId = 20L });
                x.HasData(new { UserId = 8L, PostId = 21L });
                x.HasData(new { UserId = 8L, PostId = 22L });
                x.HasData(new { UserId = 8L, PostId = 23L });
                x.HasData(new { UserId = 8L, PostId = 24L });
                x.HasData(new { UserId = 8L, PostId = 25L });
                x.HasData(new { UserId = 8L, PostId = 26L });

                x.HasData(new { UserId = 9L, PostId = 27L });
                x.HasData(new { UserId = 9L, PostId = 28L });
                x.HasData(new { UserId = 9L, PostId = 29L });
                x.HasData(new { UserId = 9L, PostId = 30L });
                x.HasData(new { UserId = 9L, PostId = 31L });
                x.HasData(new { UserId = 9L, PostId = 32L });
                x.HasData(new { UserId = 9L, PostId = 33L });
                x.HasData(new { UserId = 9L, PostId = 34L });
                x.HasData(new { UserId = 9L, PostId = 9L });

                x.HasData(new { UserId = 10L, PostId = 11L });
                x.HasData(new { UserId = 10L, PostId = 12L });
                x.HasData(new { UserId = 10L, PostId = 13L });
                x.HasData(new { UserId = 10L, PostId = 14L });
                x.HasData(new { UserId = 10L, PostId = 15L });
                x.HasData(new { UserId = 10L, PostId = 16L });
                x.HasData(new { UserId = 10L, PostId = 17L });
                x.HasData(new { UserId = 10L, PostId = 18L });
                x.HasData(new { UserId = 10L, PostId = 19L });

                x.HasData(new { UserId = 11L, PostId = 10L });
                x.HasData(new { UserId = 11L, PostId = 20L });
                x.HasData(new { UserId = 11L, PostId = 21L });
                x.HasData(new { UserId = 11L, PostId = 22L });
                x.HasData(new { UserId = 11L, PostId = 23L });
                x.HasData(new { UserId = 11L, PostId = 24L });
                x.HasData(new { UserId = 11L, PostId = 25L });
                x.HasData(new { UserId = 11L, PostId = 26L });
                x.HasData(new { UserId = 11L, PostId = 27L });

                x.HasData(new { UserId = 12L, PostId = 28L });
                x.HasData(new { UserId = 12L, PostId = 29L });
                x.HasData(new { UserId = 12L, PostId = 30L });
                x.HasData(new { UserId = 12L, PostId = 31L });
                x.HasData(new { UserId = 12L, PostId = 32L });
                x.HasData(new { UserId = 12L, PostId = 33L });
                x.HasData(new { UserId = 12L, PostId = 34L });
                x.HasData(new { UserId = 12L, PostId = 17L });
                x.HasData(new { UserId = 12L, PostId = 18L });

            });
        }

        private static void SeedTags(ModelBuilder builder)
        {
            builder.Entity<TagEntity>(x =>
            {
                x.HasData(new { Id = 1L, CreatedById = 1L, Tag = "чисто" });
                x.HasData(new { Id = 2L, CreatedById = 1L, Tag = "брудно" });
                x.HasData(new { Id = 3L, CreatedById = 1L, Tag = "неймовірно" });
                x.HasData(new { Id = 4L, CreatedById = 1L, Tag = "гарно" });
                x.HasData(new { Id = 5L, CreatedById = 1L, Tag = "романтично" });
                x.HasData(new { Id = 6L, CreatedById = 1L, Tag = "прогрес" });
                x.HasData(new { Id = 7L, CreatedById = 1L, Tag = "історія" });
                x.HasData(new { Id = 8L, CreatedById = 1L, Tag = "монумент" });
                x.HasData(new { Id = 9L, CreatedById = 1L, Tag = "пам'ятник" });
                x.HasData(new { Id = 10L, CreatedById = 1L, Tag = "креативно" });
                x.HasData(new { Id = 11L, CreatedById = 1L, Tag = "відпочинок" });
                x.HasData(new { Id = 12L, CreatedById = 1L, Tag = "робота" });
                x.HasData(new { Id = 13L, CreatedById = 1L, Tag = "площа" });
                x.HasData(new { Id = 14L, CreatedById = 1L, Tag = "харчування" });
                x.HasData(new { Id = 15L, CreatedById = 1L, Tag = "навчання" });
                x.HasData(new { Id = 16L, CreatedById = 1L, Tag = "університет" });
                x.HasData(new { Id = 17L, CreatedById = 1L, Tag = "стадіон" });
                x.HasData(new { Id = 18L, CreatedById = 1L, Tag = "вбиральня" });
                x.HasData(new { Id = 19L, CreatedById = 1L, Tag = "басейн" });
                x.HasData(new { Id = 20L, CreatedById = 1L, Tag = "зал" });
                x.HasData(new { Id = 21L, CreatedById = 1L, Tag = "спорт" });
                x.HasData(new { Id = 22L, CreatedById = 1L, Tag = "бар" });
                x.HasData(new { Id = 23L, CreatedById = 1L, Tag = "трц" });
                x.HasData(new { Id = 24L, CreatedById = 1L, Tag = "аеропорт" });
                x.HasData(new { Id = 25L, CreatedById = 1L, Tag = "вокзал" });
                x.HasData(new { Id = 26L, CreatedById = 1L, Tag = "магазин" });
                x.HasData(new { Id = 27L, CreatedById = 1L, Tag = "парк" });
                x.HasData(new { Id = 28L, CreatedById = 1L, Tag = "ліс" });
                x.HasData(new { Id = 29L, CreatedById = 1L, Tag = "море" });
                x.HasData(new { Id = 30L, CreatedById = 1L, Tag = "океан" });
                x.HasData(new { Id = 31L, CreatedById = 1L, Tag = "ресторан" });
                x.HasData(new { Id = 32L, CreatedById = 1L, Tag = "готель" });
                x.HasData(new { Id = 33L, CreatedById = 1L, Tag = "пристань" });
                x.HasData(new { Id = 34L, CreatedById = 1L, Tag = "причал" });
                x.HasData(new { Id = 35L, CreatedById = 1L, Tag = "дозвілля" });
                x.HasData(new { Id = 36L, CreatedById = 1L, Tag = "спортмайданчик" });
                x.HasData(new { Id = 37L, CreatedById = 1L, Tag = "музей" });
                x.HasData(new { Id = 38L, CreatedById = 1L, Tag = "заповідник" });
                x.HasData(new { Id = 39L, CreatedById = 1L, Tag = "порт" });
            });

            builder.Entity<PostTagEntity>(x =>
            {
                x.HasData(new { PostId = 1L, TagId = 7L });
                x.HasData(new { PostId = 1L, TagId = 16L });
                x.HasData(new { PostId = 2L, TagId = 2L });
                x.HasData(new { PostId = 3L, TagId = 9L });
                x.HasData(new { PostId = 3L, TagId = 11L });
                x.HasData(new { PostId = 4L, TagId = 1L });
                x.HasData(new { PostId = 4L, TagId = 3L });
                x.HasData(new { PostId = 5L, TagId = 4L });
                x.HasData(new { PostId = 5L, TagId = 29L });
                x.HasData(new { PostId = 6L, TagId = 3L });
                x.HasData(new { PostId = 6L, TagId = 13L });
                x.HasData(new { PostId = 7L, TagId = 29L });
                x.HasData(new { PostId = 8L, TagId = 1L });
                x.HasData(new { PostId = 8L, TagId = 7L });
                x.HasData(new { PostId = 9L, TagId = 2L });
                x.HasData(new { PostId = 10L, TagId = 2L });
                x.HasData(new { PostId = 11L, TagId = 2L });
                x.HasData(new { PostId = 12L, TagId = 13L });
                x.HasData(new { PostId = 13L, TagId = 3L });
                x.HasData(new { PostId = 13L, TagId = 13L });
                x.HasData(new { PostId = 14L, TagId = 3L });
                x.HasData(new { PostId = 14L, TagId = 8L });
                x.HasData(new { PostId = 15L, TagId = 5L });
                x.HasData(new { PostId = 15L, TagId = 11L });
                x.HasData(new { PostId = 16L, TagId = 7L });
                x.HasData(new { PostId = 17L, TagId = 7L });
                x.HasData(new { PostId = 18L, TagId = 27L });
                x.HasData(new { PostId = 19L, TagId = 10L });
                x.HasData(new { PostId = 20L, TagId = 17L });
                x.HasData(new { PostId = 21L, TagId = 24L });
                x.HasData(new { PostId = 22L, TagId = 11L });
                x.HasData(new { PostId = 23L, TagId = 16L });
                x.HasData(new { PostId = 24L, TagId = 16L });
                x.HasData(new { PostId = 25L, TagId = 11L });
                x.HasData(new { PostId = 25L, TagId = 23L });
                x.HasData(new { PostId = 26L, TagId = 4L });
                x.HasData(new { PostId = 27L, TagId = 21L });
                x.HasData(new { PostId = 28L, TagId = 1L });
                x.HasData(new { PostId = 29L, TagId = 11L });
                x.HasData(new { PostId = 30L, TagId = 2L });
                x.HasData(new { PostId = 31L, TagId = 1L });
                x.HasData(new { PostId = 31L, TagId = 11L });
                x.HasData(new { PostId = 32L, TagId = 6L });
                x.HasData(new { PostId = 33L, TagId = 7L });
                x.HasData(new { PostId = 34L, TagId = 23L });

            });
        }
    }
}
