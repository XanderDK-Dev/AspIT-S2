using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SalesPerson : Person
    {
        private decimal yearToDateSales;

        public SalesPerson(int id, string name, decimal yearToDateSales) : base(id, name)
        {
            YearToDateSales = yearToDateSales;
        }

        public decimal YearToDateSales
        {
            get => yearToDateSales;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "A sales cannot be negative");
                }
                else if (value != yearToDateSales)
                {
                    yearToDateSales = value;
                }
            }
        }
    }
}
