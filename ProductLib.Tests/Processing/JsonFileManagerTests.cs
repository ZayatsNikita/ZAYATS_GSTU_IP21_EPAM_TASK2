using NUnit.Framework;
using System;
using System.IO;


namespace ProductLib.Tests
{
    [TestFixture]
    class JsonFileManagerTests
    {
        [TestCase(@"..\..\..\JsonForReadDataFromTest1.json")]
        [TestCase(@"..\..\..\JsonForReadDataFromTest2.json")]
        public void ReadDataFromFileTest_FileWithoutNecessaryInformation_InvalidDataException(string path)
        {
            bool actual=false;
            try
            {
                Product[] products = JsonFileManger.ReadDataFromFile(path);
            }
            catch (ProductExceptions.InvalidDataException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void ReadWriteDataTest_ProductArraySendToFile_GettingTheInitialArray()
        {
            //bool actual = true;

            Electronics electronics = new ProductLib.Electronics(10.23, "Samsung s6", 127.3, 10);
            
            Clothes clothes = new Clothes(5.21, "kofta n7", 16, 10);
            
            Food food = new Food(67.83, "mi band 5", 17, 1);

            

            Electronics meizu = new Electronics(473.6, "meizu note 9", 150, 1);
            
            Product[] arrayToSendToFile = new Product[] { electronics, null, electronics, null, clothes, null, meizu, null, food, null };

            Product[] excpected = new Product[] { electronics, electronics, clothes, meizu, food };

            JsonFileManger.WriteDataToFile(arrayToSendToFile, @"..\..\..\data.json");
            
            Product[] actual = JsonFileManger.ReadDataFromFile(@"..\..\..\data.json");

            CollectionAssert.AreEquivalent(excpected, actual);
        }
        [Test]
        public void ReadDataFromFileTest_IncorectFilePath_NullReferenceExceptionThrow()
        {
            bool actual = false;
            try
            {
                JsonFileManger.ReadDataFromFile(null);
            }
            catch (NullReferenceException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void WriteDataToFileTests_IncorectFilePath_FileNotFoundExceptionThrow()
        {
            bool actual = false;
            Clothes clothes = new Clothes(5.21, "kofta n7", 16, 10);
            try
            {
                JsonFileManger.WriteDataToFile(new Product[] {clothes},@"D:\Learn\EPAM\task2\ClassLibrary1\data.jso");
            }
            catch (FileNotFoundException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        
        [Test]
        public void ReadDataFromFileTest_IncorectFilePath_FileNotFoundExceptionThrow()
        {
            bool actual = false;
            try
            {
                Product[] products = JsonFileManger.ReadDataFromFile( @"D:\Learn\EPAM\task2\ClassLibrary1\data.jso");
            }
            catch (FileNotFoundException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void WriteDataToFileTests_ArrayWhichIsReferencedToZero_NullReferenceExceptionThrow()
        {
            bool actual = false;
            try
            {
                JsonFileManger.WriteDataToFile(null, @"..\..\..\data.json");
            }
            catch (NullReferenceException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        public void WriteDataToFileTests_NullPath_NullReferenceExceptionThrow()
        {
            bool actual = false;
            try
            {
                JsonFileManger.WriteDataToFile(new Product[5],null);
            }
            catch (NullReferenceException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
    }
}
