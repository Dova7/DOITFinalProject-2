using Application.Contracts.IServices;
using Application.Models.Main.Dtos.Topic;
using DOITFinalProject_2.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DOITFinalProject_2.Controllers
{
    [Route("api/Topics")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private APIResponse _response;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
            _response = new();

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TopicForGettingDto>>> GetAllTopics()
        {
            var result = await _topicService.GetAllTopicsAsync();

            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpGet("{userId:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TopicForGettingDto>>> GetAllTopicsOfUser([FromRoute] string userId)
        {
            var result = await _topicService.GetAllTopicsOfUserAsync(userId);

            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddTopic([FromBody] TopicForCreatingDto topicForCreatingDto)
        {
            await _topicService.CreateTopicAsync(topicForCreatingDto);

            _response.Result = topicForCreatingDto;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPatch("{topicId:guid}/user")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTopicUser([FromRoute] Guid topicId, [FromBody] JsonPatchDocument<TopicForUpdatingDtoUser> patchDocument)
        {
            await _topicService.UpdateTopicAsyncUser(topicId, patchDocument);

            _response.Result = patchDocument;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Topic updated successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPatch("{topicId:guid}/admin")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTopicAdmin([FromRoute] Guid topicId, [FromBody] JsonPatchDocument<TopicForUpdatingDtoAdmin> patchDocument)
        {
            await _topicService.UpdateTopicAsyncAdmin(topicId, patchDocument);

            _response.Result = patchDocument;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Topic updated successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpDelete("{topicId:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTopic([FromRoute] Guid topicId)
        {
            await _topicService.DeleteTopicAsync(topicId);

            _response.Result = topicId;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }
    }
}
