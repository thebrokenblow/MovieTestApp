namespace Movie;

public class MovieStorage
{
    public static List<MyMovie> myMovies =
        [
        new()
        {
            Title = "Сталкер",
            URL="https://afisha-ekb.ru/media/events/21df6a4e9ba14260a610d5c9b7a349e5.jpg",
            Description = "Не для всех (пекник на обочине)",
            Cost = 200,
        },
        new()
        {
            Title = "Однажды в голливуде",
            URL="https://yandex.ru/images/search?text=%D0%BE%D0%B4%D0%BD%D0%B0%D0%B6%D0%B4%D1%8B+%D0%B2+%D0%B3%D0%BE%D0%BB%D0%BB%D0%B8%D0%B2%D1%83%D0%B4%D0%B5&pos=0&rpt=simage&img_url=https%3A%2F%2Fscontent-hel2-1.cdninstagram.com%2Fv%2Ft51.2885-15%2Fe35%2F81169366_2456091151168025_6252062298302015887_n.jpg%3F_nc_ht%3Dscontent-hel2-1.cdninstagram.com%26_nc_cat%3D105%26_nc_ohc%3DIefEcreWpVYAX8NVtza%26oh%3D099f3da587228179136a40088ef078d5%26oe%3D5F4B9C10&from=tabbar&lr=10746",
            Description = "Прикольный, но для одного раза",
            Cost = 350,
        }
        ]; 
        
}