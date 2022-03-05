using FoodShop.Model;
using Google.Cloud.Dialogflow.V2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        List<DBEntity> mockupdatabase = new List<DBEntity>()
        {
            new DBEntity()
            {
                 Id = "F1",
                 FoodName = "ข้าวผัดหมู",
                 Image = "https://img.wongnai.com/p/1968x0/2019/09/12/c435d77d141e4de9927fc1b4b8262752.jpg",
                 Price = 35
            },
            new DBEntity()
            {
                 Id = "F2",
                 FoodName = "ราดหน้าหมู",
                 Image = "https://img.wongnai.com/p/1968x0/2018/07/14/7ed32a73c9594f3cab8f25f6bbcc2d06.jpg",
                 Price = 45
            },
            new DBEntity()
            {
                 Id = "F3",
                 FoodName = "ข้าวกระเพราหมูสับ",
                 Image = "https://img.wongnai.com/p/1920x0/2020/09/01/67ba09fcb72845bc81fd413036e3f4eb.jpg",
                 Price = 50
            }
        };
        private readonly ILogger<BotController> _logger;

        public BotController(ILogger<BotController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ObjectResult HandShake()
        {
            return Ok("Server is Ready 🐈🐈🐈");
        }

        [HttpPost]
        public ObjectResult PredictProduct([FromBody]RequestEntity req)
        {
            var response = new ResponseEntity();
            var foodId = req?.QueryResult?.Parameters?.FoodId;
            var foodSelected = mockupdatabase.FirstOrDefault(x => x.Id == foodId);
            if (foodSelected != null) {
                var qty = 1;
                var qty_str = req?.QueryResult?.Parameters?.qty?.ToString();
                if (!string.IsNullOrEmpty(qty_str))
                {
                   decimal.TryParse(qty_str, out decimal qty_decimal);
                    if (qty_decimal < 1) { 
                        qty = 1;
                    }
                    else
                    {
                        qty = (int)qty_decimal;
                    }

                }
                
                response.fulfillmentMessages = new List<FulfillmentMessage>();
                response.fulfillmentMessages.Add(new FulfillmentMessage()
                {
                    payload = new PayloadResponse()
                    {
                        line = new Line()
                        {
                            text = $"รายการอาหาร: {foodSelected.FoodName}",
                            type = "text"
                        }
                    }
                });
                response.fulfillmentMessages.Add(new FulfillmentMessage()
                {
                    payload = new PayloadResponse()
                    {
                        line = new Line()
                        {
                            originalContentUrl = foodSelected.Image,
                            type = "image",
                            previewImageUrl = foodSelected.Image,
                        }
                    }
                });
                response.fulfillmentMessages.Add(new FulfillmentMessage()
                {
                    payload = new PayloadResponse()
                    {
                        line = new Line()
                        {
                            text = $"{foodSelected.FoodName} จำนวน {qty.ToString("N0")} กล่อง \n ราคา {(foodSelected.Price * qty).ToString("N0")} บาท \n ยืนยันการสั่งซื้อแจ้งที่อยู่มาได้เลยครับ",
                            type = "text"
                        }
                    }
                });
            }
            else
            {
                response.fulfillmentMessages.Add(new FulfillmentMessage()
                {
                    payload = new PayloadResponse()
                    {
                        line = new Line()
                        {
                            text = $"วันนี้ไม่มีเมนูนี้นะครับ",
                            type = "text"
                        }
                    }
                });
            }

            return Ok(response);
        }

    }
}
