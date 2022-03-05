using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Model
{
    public class Line
    {
        public string type { get; set; }
        public string text { get; set; }
        public string originalContentUrl { get; set; }
        public string previewImageUrl { get; set; }
    }

    public class PayloadResponse
    {
        public Line line { get; set; }
    }

    public class FulfillmentMessage
    {
        public PayloadResponse payload { get; set; }
    }

    public class ResponseEntity
    {
        public List<FulfillmentMessage> fulfillmentMessages { get; set; }
    }

}
