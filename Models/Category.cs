namespace Ads.Models;

public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public int? ParentCategoryID { get; set; }
}