using Newtonsoft.Json;
using System.Net;

namespace BindyBot.TwitchApi.Models;

public class BadRequestResponse
{
    [JsonProperty(PropertyName = "status")]
    public HttpStatusCode StatusCode { get; protected set; }

    [JsonProperty(PropertyName = "message")]
    public string? Message { get; protected set; }
}
