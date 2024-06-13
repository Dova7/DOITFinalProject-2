using Application.Service.Exceptions;
using DOITFinalProject_2.Responses;
using System;
using System.Net;

namespace DOITFinalProject_2.MiddleWare
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {

                await HandelException(context, ex);
            }
        }

        private Task HandelException(HttpContext context, Exception ex)
        {
            APIResponse response = new APIResponse();

            switch (ex)
            {
                case
                    CommentNotFoundException commentNotFoundException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                    response.IsSuccess = false;
                    response.Message = commentNotFoundException.Message;
                    response.Result = null!;
                    break;
                case
                    UserNotFoundException userNotFoundException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                    response.IsSuccess = false;
                    response.Message = userNotFoundException.Message;
                    response.Result = null!;
                    break;
                case
                    TopicNotFoundException topicNotFoundException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                    response.IsSuccess = false;
                    response.Message = topicNotFoundException.Message;
                    response.Result = null!;
                    break;
                case
                    RegistrationFailureException registrationFailureException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    response.IsSuccess = false;
                    response.Message = registrationFailureException.Message;
                    response.Result = null!;
                    break;
                case
                    TopicIsInactiveException topicIsInactiveException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    response.IsSuccess = false;
                    response.Message = topicIsInactiveException.Message;
                    response.Result = null!;
                    break;
                case
                    InvalidUserException invalidNotFoundException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    response.IsSuccess = false;
                    response.Message = invalidNotFoundException.Message;
                    response.Result = null!;
                    break;
                case
                    ArgumentNullException argumentException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    response.IsSuccess = false;
                    response.Message = argumentException.Message;
                    response.Result = null!;
                    break;
                case
                    ArgumentException argumentException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    response.IsSuccess = false;
                    response.Message = argumentException.Message;
                    response.Result = null!;
                    break;
                case
                    KeyNotFoundException keyNotFoundAccessException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                    response.IsSuccess = false;
                    response.Message = keyNotFoundAccessException.Message;
                    response.Result = null!;
                    break;
                case
                    UnauthorizedAccessException unauthorizedAccessException:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    response.IsSuccess = false;
                    response.Message = unauthorizedAccessException.Message;
                    response.Result = null!;
                    break;                
                case
                    Exception exception:
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    response.IsSuccess = false;
                    response.Message = ex.Message;
                    response.Result = null!;
                    break;

            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = response.StatusCode;

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
