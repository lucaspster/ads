using Ads.Models;

public class Ad
{
    public int AdID { get; set; }
    public string UserID { get; set; } // Alterado para string
    public User User { get; set; }
    public int CategoryID { get; set; }
    public Category Category { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Location { get; set; }
    public string Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}