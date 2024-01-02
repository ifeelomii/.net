namespace BLL;

// using System.Net.Http.Headers;
using DAL;
using BOL;
using System.Threading;

public static class ProductService{
    public static async Task GetData(){
        await Task.Run(()=>{
            Console.WriteLine("Showing all Products");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        });
    }

    public static async Task<List<Product>> ProductList(){
        List<Product> list = await ProductDal.ProductListDal();
        var prod = list. ;
        return list;  
    }
}