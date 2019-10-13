// using System;
// using System.Runtime;
// using System.Web.Http;
// // using System.Web.Http.Filters;
// // using System.Web.Http.Controllers;

// namespace BasicService.Api.Controllers
// {

//     /// <summary>
//     /// Generic Basic Authentication filter that checks for basic authentication
//     /// headers and challenges for authentication if no authentication is provided
//     /// Sets the Thread Principle with a GenericAuthenticationPrincipal.
//     /// 
//     /// You can override the OnAuthorize method for custom auth logic that
//     /// might be application specific.    
//     /// </summary>
//     /// <remarks>Always remember that Basic Authentication passes username and passwords
//     /// from client to server in plain text, so make sure SSL is used with basic auth
//     /// to encode the Authorization header on all requests (not just the login).
//     /// </remarks>
//     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
//     public class BasicAuthenticationFilter : AuthorizationFilterAttribute
//     {
//         public BasicAuthenticationFilter()
//         { }


//         /// <summary>
//         /// Override to Web API filter method to handle Basic Auth check
//         /// </summary>
//         /// <param name="actionContext"></param>
//         public override void OnAuthorization(HttpActionContext actionContext)
//         {
//             if (Active)
//             {
//                 var identity = ParseAuthorizationHeader(actionContext);
//                 if (identity == null)
//                 {
//                     Challenge(actionContext);
//                     return;
//                 }


//                 if (!OnAuthorizeUser(identity.Name, identity.Password, actionContext))
//                 {
//                     Challenge(actionContext);
//                     return;
//                 }

//                 var principal = new GenericPrincipal(identity, null);

//                 Thread.CurrentPrincipal = principal;

//                 // inside of ASP.NET this is required
//                 //if (HttpContext.Current != null)
//                 //    HttpContext.Current.User = principal;

//                 base.OnAuthorization(actionContext);
//             }
//         }


//         private bool IsAuthorized(HttpActionContext actionContext)
//         {
//             var headers = actionContext.Request.Headers;
//             var userIdString = headers["user_id"];
//             var transactionIdString = headers["transaction_id"];
//             Guid userId, transactionId;

//             Console.WriteLine($"User Id: {userIdString}");
//             Console.WriteLine($"Transaction Id: {transactionIdString}");
//             if (string.IsNullOrWhiteSpace(userIdString)
//                 || string.IsNullOrWhiteSpace(transactionIdString)
//                 || !Guid.TryParse(userIdString, out userId)
//                 || !Guid.TryParse(transactionIdString, out transactionId)
//                 )
//             {
//                 return false;
//             }
//             return true;
//         }

//         /// <summary>
//         /// Base implementation for user authentication - you probably will
//         /// want to override this method for application specific logic.
//         /// 
//         /// The base implementation merely checks for username and password
//         /// present and set the Thread principal.
//         /// 
//         /// Override this method if you want to customize Authentication
//         /// and store user data as needed in a Thread Principle or other
//         /// Request specific storage.
//         /// </summary>
//         /// <param name="username"></param>
//         /// <param name="password"></param>
//         /// <param name="actionContext"></param>
//         /// <returns></returns>
//         protected virtual bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
//         {
//             if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//                 return false;

//             return true;
//         }

//         /// <summary>
//         /// Parses the Authorization header and creates user credentials
//         /// </summary>
//         /// <param name="actionContext"></param>
//         protected virtual BasicAuthenticationIdentity ParseAuthorizationHeader(HttpActionContext actionContext)
//         {

//             string authHeader = null;
//             var auth = actionContext.Request.Headers.Authorization;
//             if (auth != null && auth.Scheme == "Basic")
//                 authHeader = auth.Parameter;

//             if (string.IsNullOrEmpty(authHeader))
//                 return null;

//             authHeader = Encoding.Default.GetString(Convert.FromBase64String(authHeader));

//             var tokens = authHeader.Split(':', 2);
//             if (tokens.Length < 2)
//                 return null;

//             return new BasicAuthenticationIdentity(tokens[0], tokens[1]);
//         }


//         /// <summary>
//         /// Send the Authentication Challenge request
//         /// </summary>
//         /// <param name="message"></param>
//         /// <param name="actionContext"></param>
//         void Challenge(HttpActionContext actionContext)
//         {
//             var host = actionContext.Request.RequestUri.DnsSafeHost;
//             actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
//             actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", host));
//         }

//     }
// }