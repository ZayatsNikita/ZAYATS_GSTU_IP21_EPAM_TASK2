using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;


namespace ProductLib
{
    class JsonFileManger
    {
        public void WriteDataToFile(Product[] products, string path)
        {
            if (File.Exists(path))
            {
                JsonWriterOptions options = new JsonWriterOptions
                {
                    Indented = true
                };
                using (FileStream filesStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (Utf8JsonWriter writer = new Utf8JsonWriter(filesStream, options))
                    {
                        JsonSerializer.Serialize(writer, products);
                    }
                }
            }
            else throw new FileNotFoundException();
        }
        public Product[] ReadDataToFile(string path)
        {
            if (File.Exists(path))
            {
                var options = new JsonReaderOptions
                {
                    AllowTrailingCommas = true,
                    CommentHandling = JsonCommentHandling.Skip
                };
                using (FileStream filesStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] jsonUtf8Bytes = new byte[filesStream.Length];

                    filesStream.Read(jsonUtf8Bytes, 0, jsonUtf8Bytes.Length);

                    Utf8JsonReader reader = new Utf8JsonReader(jsonUtf8Bytes, options);

                    ProductCollection products = JsonSerializer.Deserialize<ProductCollection>(jsonUtf8Bytes);

                    int length = (products?.Length ?? 0);
                    Product[] productsArray = new Product[length];

                    for (int index = 0; index < length; index++)
                    {
                        try
                        {
                            productsArray[index] = ProductFactory.CreateProduct(products.Parameters[index], products.Products[index].PurchasePrice, products.Products[index].Name, products.Products[index].MarkUp, products.Products[index].Amount);
                        }
                        catch()
                    }
                    


                    Console.WriteLine();
                }
            }
            else throw new FileNotFoundException();
        }

        public void WriteDataToFile(ProductCollection collection, string path)
        {
            if (File.Exists(path))
            {
                JsonWriterOptions options = new JsonWriterOptions
                {
                    Indented = true
                };
                using (FileStream filesStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (Utf8JsonWriter writer = new Utf8JsonWriter(filesStream, options))
                    {
                        JsonSerializer.Serialize(writer, collection);
                    }
                }
            }
            else throw new FileNotFoundException();
        }
    }
}
