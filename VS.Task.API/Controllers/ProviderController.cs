using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VS.Task.API.ViewModels.Provider.Request;
using VS.Task.API.ViewModels.Provider.Response;
using VS.Task.Business.Services.Contracts;

namespace VS.Task.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public ProviderController(IGroupService groupService, IProviderService providerService, IMapper mapper)
        {
            _groupService = groupService;
            _providerService = providerService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProviderListResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<ProviderResponse>>> List()
        {
            return Ok(_mapper.Map<IEnumerable<Business.Models.Provider>, IEnumerable<ProviderListResponse>>(await _providerService.List()));
        }

        [HttpGet("{id}", Name = nameof(GetProviderById))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProviderResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<ProviderResponse>> GetProviderById(long id)
        {
            var provider = await _providerService.GetById(id);

            if (provider == null) return NotFound();

            return Ok(_mapper.Map<Business.Models.Provider, ProviderResponse>(provider));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProviderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<ProviderResponse>> Create([FromBody] CreateProviderRequest request)
        {
            var group = await _groupService.GetById(request.GroupId);

            if (group == null) return NotFound();

            var result = await _providerService.Create(_mapper.Map<CreateProviderRequest, Business.Models.Provider>(request));

            return CreatedAtRoute(nameof(GetProviderById), new { id = result.Id }, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> Update(UpdateProviderRequest request)
        {
            var group = await _providerService.GetById(request.Id);

            if (group == null) return NotFound();

            await _providerService.Update(_mapper.Map<UpdateProviderRequest, Business.Models.Provider>(request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> Delete(long id)
        {
            var group = await _providerService.GetById(id);

            if (group == null) return NotFound();

            await _providerService.Delete(id);

            return NoContent();
        }
    }
}
