namespace Ads.Models;

public class AdDetail
{
    public int AdDetailID { get; set; }
    public int AdID { get; set; }
    public Ad Ad { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}