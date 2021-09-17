using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KeyboardComponentCatalog.DataStores;
using KeyboardComponentCatalog.Models.Dto;
using KeyboardComponentCatalog.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KeyboardComponentCatalog.Controllers
{   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class KeyboardComponentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<KeyboardComponentController> _logger;
        private readonly IMapper _mapper;
        private readonly ICaseDataStore _caseDataStore;

        public KeyboardComponentController(
            IConfiguration configuration,
            ILogger<KeyboardComponentController> logger,
            IMapper mapper,
            ICaseDataStore caseDataStore)
        {
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
            _caseDataStore = caseDataStore;
        }

        [HttpGet("cases/all", Name = nameof(FetchAllKeyboardCases))]
        public async Task<ActionResult<FetchAllKeyboardCasesResponse>> FetchAllKeyboardCases()
        {
            _logger.LogInformation($"Request to fetch all available Keyboard Cases. Time: {DateTime.UtcNow}");

            var requestCases = await _caseDataStore.GetAllCases();

            var response = new FetchAllKeyboardCasesResponse
            {
                KeyboardCases = requestCases.Select(keyboardCase => _mapper.Map<CaseDto>(keyboardCase)).ToList()
            };
            
            return response;
        }
    }
}