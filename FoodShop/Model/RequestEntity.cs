using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Parameters
    {
        public string FoodId { get; set; }
        public object qty { get; set; }

        [JsonProperty("no-input", NullValueHandling = NullValueHandling.Ignore)]
        public double NoInput { get; set; }

        [JsonProperty("no-match", NullValueHandling = NullValueHandling.Ignore)]
        public double NoMatch { get; set; }

        [JsonProperty("foodId.original", NullValueHandling = NullValueHandling.Ignore)]
        public string FoodIdOriginal { get; set; }
    }

    public class Text
    {
        [JsonProperty("Text", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Text2 { get; set; }
    }


    public class OutputContext
    {
        public string Name { get; set; }
        public Parameters Parameters { get; set; }
    }

    public class Intent
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }

    public class QueryResult
    {
        public string QueryText { get; set; }
        public Parameters Parameters { get; set; }
        public bool AllRequiredParamsPresent { get; set; }
        public string FulfillmentText { get; set; }
        public List<Object> FulfillmentMessages { get; set; }
        public List<OutputContext> OutputContexts { get; set; }
        public Intent Intent { get; set; }
        public double IntentDetectionConfidence { get; set; }
        public string LanguageCode { get; set; }
    }

    public class Message
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class Source
    {
        public string UserId { get; set; }
        public string Type { get; set; }
    }

    public class Data
    {
        public string Timestamp { get; set; }
        public Message Message { get; set; }
        public Source Source { get; set; }
        public string ReplyToken { get; set; }
        public string Type { get; set; }
    }

    public class Payload
    {
        public Data Data { get; set; }
    }

    public class OriginalDetectIntentRequest
    {
        public string Source { get; set; }
        public Payload Payload { get; set; }
    }

    public class RequestEntity
    {
        public string ResponseId { get; set; }
        public QueryResult QueryResult { get; set; }
        public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; }
        public string Session { get; set; }
    }






}
