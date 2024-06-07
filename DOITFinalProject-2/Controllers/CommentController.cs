using Application.Contracts.IServices;
using Application.Models.Main.Dtos.Comment;
using Application.Models.Main.Dtos.Topic;
using Application.Service.Implimentations.Services;
using DOITFinalProject_2.Responses;
using ForumProject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DOITFinalProject_2.Controllers
{
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private APIResponse _response;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
            _response = new();
        }
        [HttpGet("{userId:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CommentForGettingDtoMain>>> GetAllCommentsOfUser([FromRoute] string userId)
        {
            var result = await _commentService.GetAllCommentsOfUserAsync(userId);

            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPost("{topicId:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddComment([FromRoute] Guid topicId, [FromBody] CommentForCreatingDto commentForCreatingDto)
        {
            await _commentService.CreateCommentAsync(topicId,commentForCreatingDto);

            _response.Result = commentForCreatingDto;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPatch("{commentId:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateComment([FromRoute] Guid commentId, [FromBody] JsonPatchDocument<CommentForUpdatingDto> patchDocument)
        {
            await _commentService.UpdateCommentAsync(commentId, patchDocument);

            _response.Result = patchDocument;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Comment updated successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpDelete("{commentId:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid commentId)
        {
            await _commentService.DeleteCommentAsync(commentId);

            _response.Result = commentId;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }
    }
}
