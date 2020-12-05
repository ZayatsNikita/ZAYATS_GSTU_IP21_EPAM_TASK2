using System.Linq;

namespace ProductLib.ProductValidation
{
    /// <summary>
    /// A class used for data validation.
    /// </summary>
    internal class Validation
    {
        /// <summary>
        /// Static constructor for initializing a list that stores the names of allowed products
        /// </summary>
        static Validation()
        {
            //typesOfProduct = typeof(Product).Assembly.ExportedTypes.Where(x => x.BaseType == typeof(Product)).Select(x=>x.Name).ToArray();
            typesOfProduct = typeof(ProductModels).GetEnumNames();
        }
        private static string[] typesOfProduct;
        /// <summary>
        /// Checks data for the ability to create a product.
        /// </summary>
        /// <param name="pPrice">Purchase price of product.</param>
        /// <param name="name">Name of product.</param>
        /// <param name="markup">Mark-up of product.</param>
        /// <param name="amount">Amount of product.</param>
        /// <param name="typeOfProduct">The type of product you want to create</param>
        /// <returns>Returns true if you can create such a product, false otherwise</returns>
        public static bool IsProduct(string typeOfProduct, string name, double pPrice, double markup, int amount)
        {
            foreach(string source in typesOfProduct)
            {
                if(source==typeOfProduct)
                {
                    return (pPrice > 0 && markup > 0 && amount > 0 && name != null);
                }
            }
            return false;
        }
    }
}
