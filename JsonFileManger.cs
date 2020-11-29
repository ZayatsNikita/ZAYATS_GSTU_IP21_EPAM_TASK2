using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

//Пространство имен System.Text.Json содержит все точки входа и основные типы. Пространство имен
//System.Text.Json.Serialization содержит атрибуты и интерфейсы API для сложных сценариев и настройки,
//характерной для сериализации и десериализации. В примерах кода, приведенных в этой статье, для одного
//или обоих пространств имен необходимо добавить директивы  using :

namespace ProductLib
{
    class JsonFileManger
    {
       public void WriteDataToFile(IEnumerable<Product> products, string path)
       {
            if (File.Exists(path))
            {
                var options = new JsonWriterOptions
                {
                    Indented = true
                };
                using (FileStream filesStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (Utf8JsonWriter writer = new Utf8JsonWriter(filesStream, options))
                    {

                        foreach (Product product in products)
                        {
                            JsonSerializer.Serialize<Product>(writer, product);
                        }
                    }
                }
            }
            else throw new FileNotFoundException();
       }
       public void ReadDataToFile(IEnumerable<Product> products, string path)
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
                    filesStream.Read(jsonUtf8Bytes,0, jsonUtf8Bytes.Length);

                    Utf8JsonReader reader = new Utf8JsonReader(jsonUtf8Bytes, options);

                    var t = JsonSerializer.Deserialize<Product>(ref reader);
                    
                }
            }
            else throw new FileNotFoundException();
       }

    }
}
