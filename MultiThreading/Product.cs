namespace BOL;

public class Product{
    public int? Product_Id{ get; set; }
    public string? Product_Name{ get; set; }
    public string? Product_Colour{ get; set; }

    public Product():this(0,"flower","Colour"){}
    public Product(int id, string name, string colour){
        this.Product_Id = id;
        this.Product_Name = name;
        this.Product_Colour = colour;
    }
}