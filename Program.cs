using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeObjectsToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Child> children = new List<Child>();

            Child childOne = new Child
            {
                BoolPropertyBase = true,
                DoublePropertyBase = 2017,
                StringPropertyBase = "first base",
                BoolPropertyChild = true,
                DateTimePropertyChild = DateTime.Today,
                StringPropertyChild = "first child"
            };
            children.Add(childOne);

            Child childTwo = new Child
            {
                BoolPropertyBase = true,
                DoublePropertyBase = 2018,
                StringPropertyBase = "second base",
                BoolPropertyChild = true,
                DateTimePropertyChild = DateTime.Today.AddDays(1),
                StringPropertyChild = "second child",
                Brother = childOne
            };
            children.Add(childTwo);

            Child childThree = new Child
            {
                BoolPropertyBase = false,
                DoublePropertyBase = 2019,
                StringPropertyBase = "third base",
                BoolPropertyChild = false,
                DateTimePropertyChild = DateTime.Today.AddDays(2),
                StringPropertyChild = "third child",
                Brother = childTwo
            };
            children.Add(childThree);

            StaticMethods.SerializeToCsv<Child>(children, @"C:\temp\ExportExample.csv");

        }
    }
}
