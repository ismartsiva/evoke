using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CountryController> _logger;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var counties = await _unitOfWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryDTO>>(counties);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(GetCountries)}");
                return StatusCode(500, "Internal Error. Please Try Again");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id,new List<string> {"hotels"});
                var result = _mapper.Map<CountryDTO>(country);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(GetCountry)}");
                return StatusCode(500, "Internal Error. Please Try Again");
            }
        }
    }
}
