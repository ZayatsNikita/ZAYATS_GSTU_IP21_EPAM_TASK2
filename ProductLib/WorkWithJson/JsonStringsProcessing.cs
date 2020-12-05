using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ProductLib
{
    internal static class ProcessingStrings
    {
        internal static string[] SearchInformationBeetwinBrakets(string source)
        {
            Regex regex = new Regex(@"(?<data>{\r\n[\s\S]+?})");
            MatchCollection matches = regex.Matches(source);
            if (matches.Count != 0)
                return matches.Select(x => x.Value).ToArray();
            else throw new ProductExceptions.InvalidDataException();
        }

        internal static Product[] ConvertStringArrayToProductArray(string[] array)
        {
            List<Product> listOfProducts = new List<Product>();
            Regex productSearch = new Regex(@"\r\n\s*""TypeOfProduct"": ""(?<pType>[^""]+)"",\r\n\s*""PurchasePrice"": (?<pPrice>\d+[.]?\d*),\r\n\s*""Name"": ""(?<pName>[^""]+)"",\r\n\s*""MarkUp"": (?<pMarkUp>\d+[.]?\d*),\r\n\s*""Amount"": (?<pAmount>\d+)");
            for (int index = 0; index < array.Length; index++)
            {
                Match match = productSearch.Match(array[index]);
                if (match.Success)
                {

                    double price = Double.Parse(match.Groups["pPrice"].Value.Replace('.', ','));
                    double markup = Double.Parse(match.Groups["pMarkUp"].Value.Replace('.', ','));
                    int amoint = Int32.Parse(match.Groups["pAmount"].Value);
                    if (ProductValidation.Validation.IsProduct(match.Groups["pType"].Value, match.Groups["pName"].Value, price, markup, amoint))
                    {
                        Type type = Type.GetType("ProductLib." + match.Groups["pType"].Value);
                        Product pr = (Product)JsonSerializer.Deserialize(array[index], type);
                        listOfProducts.Add(pr);
                    }
                }
            }
            if (listOfProducts.Count == 0)
                throw new ProductExceptions.InvalidDataException();
            return listOfProducts.ToArray();
        }

    }
}
