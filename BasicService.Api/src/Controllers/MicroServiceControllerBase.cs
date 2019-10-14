using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BasicService.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BasicService.Api.Controllers
{
    public abstract class MicroServiceControllerBase : ControllerBase
    {
        public Guid UserId { get; set; }
        public Guid TransactionId { get; set; }

        public MicroServiceControllerBase()
        {
        }

        protected bool IsAuthorized()
        {
            var headers = this.Request.Headers;
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
                return false;
            }
            return true;
        }
    }

}