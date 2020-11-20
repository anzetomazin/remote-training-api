using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemoteTrainingApi.Groups;
using RemoteTrainingApi.Groups.Models;
using RemoteTrainingApi.Workouts;
using RemoteTrainingApi.Workouts.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RemoteTrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGroupRepo _groupRepo;

        public GroupController(IHttpContextAccessor httpContextAccessor, IGroupRepo groupRepo)
        {
            _httpContextAccessor = httpContextAccessor;
            _groupRepo = groupRepo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [Authorize]
        public async Task<IActionResult> GetGroups()
        {
            try
            {
                //int providerId = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var result = await _groupRepo.GetGroups();
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        [HttpGet("{groupId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [Authorize]
        public async Task<IActionResult> GetGroup(int groupId)
        {
            try
            {
                int userId = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var result = await _groupRepo.GetGroup(groupId, userId);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [Authorize]
        public async Task<IActionResult> PostGroup([FromBody] GroupPost groupPost)
        {
            try
            {
                int userId = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var result = await _groupRepo.PostGroup(groupPost, userId);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        [HttpPost("{groupId}/Join")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [Authorize]
        public async Task<IActionResult> JoinGroup(int groupId)
        {
            try
            {
                int userId = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var result = await _groupRepo.JoinGroup(groupId, userId);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}
