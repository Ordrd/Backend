using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdrdApi.DTO;
using OrdrdApi.Services.HistoryServ;
using System.Drawing.Printing;

namespace OrdrdApi.Controllers
{
    [Route("api/history")]
    [ApiController]
    [Authorize]
    public class HistoryController : ControllerBase
    {

        private readonly IHistoryService historyService;

        public HistoryController(IHistoryService historyService)
        {
            this.historyService = historyService;
        }

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<List<AdminOrderDto>>> GetHistory(int restaurantId, int page = 0, int pageSize = 20)
        {
            var result = await historyService.GetHistoryAsync(restaurantId, page, pageSize);
            List<AdminOrderDto> orderDtos = new List<AdminOrderDto>();
            result.ForEach(order => orderDtos.Add(AdminOrderDto.FromOrder(order)));
            return orderDtos;
        }

        [Route("find")]
        [HttpGet]
        public async Task<ActionResult<List<AdminOrderDto>>> FindInHistory(int restaurantId, string search)
        {
            var result = await historyService.FindInHistoryAsync(restaurantId, search);
            List<AdminOrderDto> orderDtos = new List<AdminOrderDto>();
            result.ForEach(order => orderDtos.Add(AdminOrderDto.FromOrder(order)));
            return orderDtos;
        }

    }
}
