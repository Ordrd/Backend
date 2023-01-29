using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdrdApi.DTO;
using OrdrdApi.Services.Infrastructure;
using OrdrdApi.Services.OrderServ;
using OrdrdApi.Services.UserServ;

namespace OrdrdApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IInfrastructureService infrastructureService;

        public OrderController(IOrderService orderService, IInfrastructureService infrastructureService)
        {
            this.orderService = orderService;
            this.infrastructureService = infrastructureService;
        }

        [AllowAnonymous]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto order)
        {
            await orderService.CreateOrderAsync(order);
            return Ok(order);
        }

        [Route("inQueue")]
        [HttpGet]
        public async Task<ActionResult<List<AdminOrderDto>>> GetOrdersInQueue(int restaurantId)
        {
            var result = await orderService.GetOrdersInQueueAsync(restaurantId);
            List<AdminOrderDto> orderDtos = new List<AdminOrderDto>();
            result.ForEach(order => orderDtos.Add(AdminOrderDto.FromOrder(order)));
            return Ok(orderDtos);
        }

        [Route("inProgress")]
        [HttpGet]
        public async Task<ActionResult<List<AdminOrderDto>>> GetOrdersInProgress(int restaurantId)
        {
            var result = await orderService.GetOrdersInProgressAsync(restaurantId);
            List<AdminOrderDto> orderDtos = new List<AdminOrderDto>();
            result.ForEach(order => orderDtos.Add(AdminOrderDto.FromOrder(order)));
            return Ok(orderDtos);
        }

        [Route("accept")]
        [HttpPut]
        public async Task<ActionResult> AcceptOrder(int orderId, int waitingTime)
        {
            await orderService.AcceptOrderAsync(orderId, waitingTime);
            return Ok();
        }

        [Route("decline")]
        [HttpPut]
        public async Task<ActionResult> DeclineOrder(int orderId, string reason) //Reason shoud be enum
        {
            await orderService.DeclineOrderAsync(orderId, reason);
            return Ok();
        }

        [Route("finish")]
        [HttpPut]
        public async Task<ActionResult> FinishOrder(int orderId)
        {
            await orderService.FinishOrderAsync(orderId);
            return Ok();
        }
    }
}