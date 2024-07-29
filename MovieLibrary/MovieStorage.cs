namespace MovieLibrary;

public class MovieStorage
{
    public static List<Movie> Movies =
        [
        
            new()
            {
                Id = 1,
                Title = "Сталкер",
                URL="https://afisha-ekb.ru/media/events/21df6a4e9ba14260a610d5c9b7a349e5.jpg",
                Description = "Фильм-притча о путешествии в Зону необъяснимого. Загадочное небесное тело после падения на Землю образовало Зону — территорию загадочных аномалий, в которой пропадают люди.",
                Cost = 200,
            },
            new()
            {
                Id = 2,
                Title = "Крёстный отец",
                URL="https://avatars.mds.yandex.net/get-kinopoisk-post-img/1539913/10f4f311eaa6c49f6f4302c8f3f580d8/1920x1080",
                Description = "Эпическая гангстерская сага оскароносного режиссера Фрэнсиса Форда Копполы по роману Марио Пьюзо 1969 года.",
                Cost = 350,
            },
            new()
            {
                Id = 3,
                Title = "Криминальное чтиво",
                URL="https://www.kinonews.ru/insimgs/shotimg/shotimg27055_1.jpg",
                Description = "Двое бандитов Винсент Вега и Джулс Винфилд ведут философские беседы в перерывах между разборками и решением проблем с должниками криминального босса Марселласа Уоллеса.",
                Cost = 300,
            },
            new()
            {
                Id = 4,
                Title = "Побег из шоушенка",
                URL="https://www.film.ru/sites/default/files/movies/frames/The-Shawshank-Redemption-03.jpg",
                Description = "Это американский драматический фильм режиссёра и сценариста Фрэнка Дарабонта, снятый по мотивам повести Стивена Кинга.",
                Cost = 300,
            }
        ]; 
}