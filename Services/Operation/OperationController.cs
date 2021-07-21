using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AccountantAppWebAPI
{
	[ApiController]
	[Route("api/operations")]
	public class OperationController : ControllerBase
	{
		private readonly IModelContext modelContext;

		public OperationController(IModelContext modelContext)
		{
			this.modelContext =
				modelContext ?? throw new ArgumentNullException(nameof(modelContext));
		}

		[HttpGet]
		public JsonResult GetOperations()
		{
			var operations = modelContext.OperationRepository.GetAll().ToArray();

			return new JsonResult(operations);
		}

		[HttpGet("{id}")]
		public JsonResult GetOperation(int id)
		{
			var operation = modelContext.OperationRepository.GetById(id);

			return new JsonResult(operation);
		}

		[HttpPost]
		public JsonResult SaveOperation(Operation operation)
		{
			operation.Executed = DateTime.Now;
			OperationBuilder.CreateOperation(modelContext, operation);

			modelContext.OperationRepository.Insert(operation);
			modelContext.OperationRepository.SaveChanges();

			return new JsonResult(operation);
		}

		[HttpPut]
		public JsonResult EditOperation(Operation operation)
		{
			modelContext.OperationRepository.Update(operation);
			modelContext.OperationRepository.SaveChanges();

			return new JsonResult(operation);
		}

		[HttpDelete("{id}")]
		public JsonResult DeleteOperation(int id)
		{
			OperationBuilder.DeleteOperation(modelContext, id);

			modelContext.OperationRepository.Delete(id);
			modelContext.OperationRepository.SaveChanges();

			return new JsonResult(StatusCode(200));
		}
	}
}
