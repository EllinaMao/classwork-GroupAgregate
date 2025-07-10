using static System.Runtime.InteropServices.JavaScript.JSType;

namespace classwork_GroupAgregate
{
    internal class Program
    {
        /*Group+Aggregate functions (Sum,Count, Average,Min,Max)*/
        static void Main(string[] args)
        {
            /*Кількість книжок 
            Кількість книжок з умовою: рік видання >2020
            Виведіть авторів без повторень
            Згрупуйте книжки по авторам
            Найдорожча книжка в кожного автора
            Сумма цін книжок кожного автора*/

            List<Book> books = [];
            books.Add(new Book("Убийство в коде", "Дарья Донцова", 1999, 20.32m));
            books.Add(new Book("Программирование для начинающих", "Павел Кузнецов", 2015, 35.50m));
            books.Add(new Book("Тайны алгоритмов", "Дарья Донцова", 2018, 42.99m));
            books.Add(new Book("C# на практике", "Дмитрий Ким", 2020, 55.00m));
            books.Add(new Book("Мастерство LINQ", "Павел Кузнецов", 2021, 48.75m));
            books.Add(new Book("Архитектура .NET", "Павел Кузнецов", 2017, 39.90m));
            books.Add(new Book("Современные паттерны", "Дарья Донцова", 2019, 44.10m));
            books.Add(new Book("Базы данных просто", "Мария Волкова", 2016, 29.99m));
            books.Add(new Book("Тестирование ПО", "Дмитрий Ким", 2022, 51.20m));
            books.Add(new Book("Искусственный интеллект", "Дарья Донцова", 2023, 60.00m));


            var countHowMany = books.Count();
            Console.WriteLine("Количество книг: {0}", countHowMany);
            countHowMany = books.Count;// linq вариант
            Console.WriteLine("Количество книг linq: {0}", countHowMany);




            var countHowManyyear2020 = books.Count(n=> n.Year>2020);
            Console.WriteLine("Количество книг c годом выпуска после 2020: {0}", countHowManyyear2020);

            Console.WriteLine("\nНажмите кнопку");
            Console.ReadKey();
            Console.Clear();

            var Autors = books.Select(a=> a.Autor).Distinct().ToList();
            Console.WriteLine("Список авторов книг без повторения:\n{0}", string.Join(",\n", Autors));

            Console.WriteLine("\nНажмите кнопку");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Группируем по авторам");
            var bookGroup = books.GroupBy(a => a.Autor);//тоже самое но через 

            foreach (IGrouping<string, Book> b in bookGroup)
            {
                Console.WriteLine(b.Key);
                Console.WriteLine(string.Join(",\n", b));
                Console.WriteLine();
            }


            Console.WriteLine("\nНажмите кнопку");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Сортировка по самой дорогой книге");
            var bookGroup2 = from a in books
                            group a by a.Autor into g
                            orderby g.Max(book => book.Price) descending
                            select g.OrderByDescending(book => book.Price).First();

            foreach (var book in bookGroup2)
            {
                Console.WriteLine($"{book.Autor}: {book.Name}, {book.Price}");
            }

            Console.WriteLine("\nНажмите кнопку");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Сумма цен книг авторов");
            // Выражение group phone by phone.Company into g определяет переменную g, которая будет содержать группу. 
            // С помощью этой переменной мы можем затем создать новый объект анонимного типа: 
            // select new { Name = g.Key, Count = g.Count() } 
            // Теперь результат запроса LINQ будет представлять набор объектов таких анонимных типов, 
            // у которых два свойства Name и Count

            var bookGroup3 = from a in books
                             group a by a.Autor into g
                             select new { Autor = g.Key, Sum = g.Sum(book => book.Price) };

            foreach (var book in bookGroup3)
            {
                Console.WriteLine($"{book.Autor}: {book.Sum}");
            }




        }












    }
}
