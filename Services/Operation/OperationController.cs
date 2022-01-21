using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountantAppWebAPI.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AccountantAppWebAPI
{
	[ApiController]
	[Route("api/operations")]
	public class OperationController : ControllerBase
	{
		private readonly IOperationService operationService;

		private readonly IMapper mapper;

		public OperationController(IOperationService operationService, IMapper mapper)
		{
			this.operationService = operationService;
			this.mapper = mapper;
		}

		[HttpGet]
		public IQueryable<OperationDto> GetOperations()
		{
			var operations = operationService.GetOperations();

			return mapper.ProjectTo<OperationDto>(operations)
				.OrderByDescending(op => op.Executed);
		}

		[HttpGet("{id}")]
		public Operation GetOperation(int id)
		{
			return operationService.GetOperation(id);
		}

		[HttpPost]
		public async Task<Microsoft.AspNetCore.Mvc.ActionResult> SaveOperation(Operation operation)
		{
			await operationService.CreateOperation(operation, new CancellationToken(default));

			return Ok(operation);
		}

		[HttpDelete("{id}")]
		public async Task<Microsoft.AspNetCore.Mvc.ActionResult> DeleteOperation(int id)
		{
			await operationService.DeleteOperation(id, new CancellationToken(default));

			return Ok();
		}
	}
}
