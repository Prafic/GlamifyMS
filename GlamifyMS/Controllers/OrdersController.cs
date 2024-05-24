using FinalProject.Repository.OrderRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrder ordercontext;
        public OrdersController(IOrder ordercontext)
        {
            this.ordercontext = ordercontext;

        }
        [HttpPost]
        [Route("AddOrder")]
        //[Authorize(Roles ="User")]

        public IActionResult BuyNow(int userId)
        {
            ordercontext.BuyNow(userId);
            return Ok();
        }
        [HttpGet]
        [Route("GetNetAmount")]
        public int GetNetAmount(int userId)
        {
            var result=ordercontext.GetNetAmount(userId);
            return result;

        }

        [HttpGet]
        [Route("GetTotalAmount")]

        public int GetTotalAmount(int userId)
        {
          var result1=ordercontext.GetTotalAmount(userId);
            return result1;
        }
    }

   
}
