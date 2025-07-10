using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classwork_GroupAgregate
{
    internal class Book
    {
        public string Name { get; set; }
        public string Autor { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Book(string name, string autor, int year, decimal price)
        {
            Name = name;
            Autor = autor;
            Year = year;
            Price = price;
        }

        public override string ToString()
        {
            return $"Название {Name}, Автор {Autor}, Год {Year}, Цена {Price}";
        }
    }
}
