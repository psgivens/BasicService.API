// using System;
// using System.Security.Principal;

// namespace BasicService.Api.Controllers
// {

//     public class BasicAuthenticationIdentity : GenericIdentity
//     {
//         public BasicAuthenticationIdentity(Guid userId, Guid transactionId)
//             : base(userId, "Context")
//         {
//             this.UserId = userId;
//             this.TransactionId = transactionId;
//         } /// 

//         public Guid UserId { get; set; }
//         public Guid TransactionId { get; set; }
//     }
// }