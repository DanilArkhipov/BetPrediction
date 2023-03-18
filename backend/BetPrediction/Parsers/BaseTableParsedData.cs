namespace Parsers;

public class BaseTableParsedData<TParsedModel>
{
    public List<TParsedModel> ParsedDataList { get; }
    public  bool IsSuccessfulParsed { get; }
    
    public string ErrorMessage { get; }

    public BaseTableParsedData(List<TParsedModel> parsedDataList)
    {
        ParsedDataList = parsedDataList;
        IsSuccessfulParsed = true;
    }

    public BaseTableParsedData(string errorMessage)
    {
        IsSuccessfulParsed = false;
        ErrorMessage = errorMessage;
    }
}