using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VS.Task.API.ViewModels.Group.Request;
using VS.Task.API.ViewModels.Group.Response;
using VS.Task.API.ViewModels.Provider.Response;
using VS.Task.Business.Services.Contracts;

namespace VS.Task.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GroupResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<GroupResponse>>> List()
        {
            return Ok(_mapper.Map<IEnumerable<Business.Models.Group>, IEnumerable<GroupListResponse>>(await _groupService.List()));
        }

        [HttpGet("{id}", Name = nameof(GetGroupById))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<GroupResponse>> GetGroupById(long id)
        {
            var group = await _groupService.GetById(id);

            if (group == null) return NotFound();

            return Ok(_mapper.Map<Business.Models.Group, GroupResponse>(group));
        }

        [HttpGet("{id}/Providers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProviderResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<ProviderResponse>>> GetProviders(long id)
        {
            var group = await _groupService.GetById(id);

            if (group == null) return NotFound();

            return Ok(_mapper.Map<IEnumerable<Business.Models.Provider>>(group.Providers));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GroupResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<GroupResponse>> Create([FromBody] CreateGroupRequest request)
        {
            var result = await _groupService.Create(_mapper.Map<CreateGroupRequest, Business.Models.Group>(request));

            return CreatedAtRoute(nameof(GetGroupById), new { id = result.Id }, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> Update(UpdateGroupRequest request)
        {
            var group = await _groupService.GetById(request.Id);

            if (group == null) return NotFound();

            await _groupService.Update(_mapper.Map<UpdateGroupRequest, Business.Models.Group>(request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> Delete(long id)
        {
            var group = await _groupService.GetById(id);

            if (group == null) return NotFound();

            await _groupService.Delete(id);

            return NoContent();
        }
    }
}
