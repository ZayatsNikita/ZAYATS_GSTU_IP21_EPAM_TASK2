using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib
{
    class Program
    {
        public static void Main()
        {
            Electronics electronics = new Electronics(10.23,"Samsung s6",127.3,10);
            
            Wear wear = new Wear(5.21,"kofta n7",16,10);

            Food food = new Food(67.83,"mi band 5",17,1);

            Electronics meizu = new Electronics(473.6, "meizu note 9", 150, 1);

            Product[] array = new Product[] {electronics,electronics, wear, meizu, food };

            JsonFileManger jsonFileManger = new JsonFileManger();
            ProductCollection collection = new ProductCollection();
            collection.Add(array);
            array = null;
            jsonFileManger.WriteDataToFile(collection, @"D:\Learn\EPAM\task2\ClassLibrary1\data.json");
            array =jsonFileManger.ReadDataToFile(@"D:\Learn\EPAM\task2\ClassLibrary1\data.json");

        }
    }
}
