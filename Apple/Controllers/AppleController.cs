using Microsoft.AspNetCore.Mvc;
using Apple.JsonDto;
using Apple.Services;
namespace Apple.Controllers;

public class AppleController : Controller
{
    private RabbitTestProducer _test;

    public AppleController(RabbitTestProducer rb)
    {

        _test = rb;

    }
    // [HttpGet("Apple")]
    // public AppleQuality Index()
    // {
    //     var task = _test.Initialize();
    //     AppleFeaturesDto json = new AppleFeaturesDto()
    //     {
    //         size= .0f,
    //         weight=2.0f,
    //         sweetness = 1.0f,
    //         crunchiness = 1.0f,
    //         juiciness = 2.0f,
    //         ripeness = 4.0f,
    //         acidity = 9.0f
    //         
    //
    //     };
    //     task.ContinueWith(_ =>
    //     {
    //         _test.Produce(json);
    //     });
    //
    //     return new AppleQuality("hello dude ", "bad");
    //
    //
    // }

    [HttpPost("Apple")]
    public AppleQuality ApplePost([FromBody] AppleFeaturesDto apple)
    {
        var task = _test.Initialize();
        task.ContinueWith(_ =>
        {
            _test.Produce(apple);
        });
        return new AppleQuality("sucess", "Prayash");
    }
}