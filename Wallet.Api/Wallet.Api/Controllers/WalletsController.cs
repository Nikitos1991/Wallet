using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wallet.Api.Commands.AddFunds;
using Wallet.Api.Commands.RemoveFunds;

namespace Wallet.Api.Controllers
{
    [ApiController]
    [Route("wallets")]
    public class WalletsController : ControllerBase
    {
        private readonly ILogger<WalletsController> _logger;
        private readonly IMediator _mediator;


        public WalletsController(IMediator mediator, ILogger<WalletsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalletAsync()
        {
            return Ok(await Task.FromResult(1));
        }

        [HttpPost("{id}/funds")]
        public async Task<IActionResult> AddFundsAsync(Guid id, [FromBody] AddFundsRequest request)
        {
            request.WalletId = id;
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("{id}/funds")]
        public async Task<IActionResult> RemoveFundsAsync(Guid id, [FromBody] RemoveFundsRequest request)
        {
            request.WalletId = id;
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWalletAsync(Guid id)
        {
            return Ok(await Task.FromResult(1));
        }
    }
}