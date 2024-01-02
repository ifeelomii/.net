namespace DAL;
using BOL;
public static class ProductDal{
    public static async Task<List<Product>> ProductListDal(){
        List<Product> list = new List<Product>();
        await Task.Run(() =>
        {
            list.Add(new Product(1, "Rose", "Red"));
            list.Add(new Product(2, "Lavender", "Purple"));
            list.Add(new Product(3, "Dandelions", "White"));
            list.Add(new Product(4, "Sunflowers", "Yellow"));
        });
        return list;
    }
}