namespace Apple.JsonDto;

public class AppleQuality
{

    public string Message { get; set; }
    public string Quality { get; set; }

    public AppleQuality(string m, string q)
    {
        Message = m;
        Quality = q;

    }
    
}