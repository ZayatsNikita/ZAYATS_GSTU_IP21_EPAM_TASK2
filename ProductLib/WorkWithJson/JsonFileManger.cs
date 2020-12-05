using System;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using ProductLib.ProductExceptions;

namespace ProductLib
{
    /// <summary>
    /// Class for reading product data in a JSON file and reading information from it
    /// </summary>
    public class JsonFileManger
    {
        /// <summary>
        /// Reads data from a file to an array
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>Array of products.
        /// <para>
        /// If the file is found, but the data was not read,
        /// or data do not exist, a zero-length array is returned
        /// </para>
        /// </returns>
        /// <exception cref="FileNotFoundException">Throw if the file is not found</exception>
        public static Product[] ReadDataFromFile(string path)
        {
            if (path == null)
                throw new NullReferenceException();
            if (File.Exists(path))
            {
                string res = File.ReadAllText(path);
                if ((res?.Length ?? 0) < 10)
                    throw new ProductExceptions.InvalidDataException();
                else
                {
                    string[] resArray = ProcessingStrings.SearchInformationBeetwinBrakets(res);
                    return ProcessingStrings.ConvertStringArrayToProductArray(resArray);
                }
            }
            else throw new FileNotFoundException();
        }
        /// <summary>
        /// Writing data from an array to a file in JSON format
        /// </summary>
        /// <remarks>If the specified file does not exist, a new file is created.
        /// If it exists, the old information is erased and a new one is written.</remarks>
        /// <param name="array">Array of products to record</param>
        /// <param name="path">File path</param>
        /// <exception cref="FileNotFoundException">Throw if the specified file is not found</exception>
        public static void WriteDataToFile(Product[] array, string path)
        {
            if (path == null || array==null)
                throw new NullReferenceException();
            if (File.Exists(path))
            {
                JsonWriterOptions options = new JsonWriterOptions
                {
                    Indented = true
                };
                using (FileStream filesStream = new FileStream(path, FileMode.Create))
                {
                    using (Utf8JsonWriter writer = new Utf8JsonWriter(filesStream, options))
                    {
                        JsonSerializer.Serialize(writer, array);
                    }
                }
            }
            else throw new FileNotFoundException();
        }
    }
}