namespace BetPrediction.Models;

public class BaseListModel<TItemModel>
{
    public List<TItemModel> Items { get; set; }
    
    public int TotalItemsCount { get; set; }
}