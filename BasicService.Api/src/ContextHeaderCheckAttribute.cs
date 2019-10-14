using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasicService.Api.Controllers
{
    class ContextHeaderCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            var userIdString = headers["user_id"];
            var transactionIdString = headers["transaction_id"];
            Guid userId, transactionId;

            Console.WriteLine($"User Id: {userIdString}");
            Console.WriteLine($"Transaction Id: {transactionIdString}");
            if (string.IsNullOrWhiteSpace(userIdString)
                || string.IsNullOrWhiteSpace(transactionIdString)
                || !Guid.TryParse(userIdString, out userId)
                || !Guid.TryParse(transactionIdString, out transactionId)
                )
            {
                context.Result = new UnauthorizedResult ();
            }
            else
            {
                var controller = context.Controller as MicroServiceControllerBase;
                controller.UserId = userId;
                controller.TransactionId = transactionId;
                base.OnActionExecuting(context);
            }
        }
    }
}
