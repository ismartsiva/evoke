using AutoMapper;
using HotelListing.data;
using HotelListing.IRepository;
using HotelListing.Models;
using HotelListing.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<HotelsController> _logger;
        private readonly IMapper _mapper;

        public HotelsController(UnitOfWork unitOfWork,ILogger<HotelsController> logger,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetallHotels()
        {
            try
            {
                var hotels = _unitOfWork.Hotels.GetAll();
                var Results = _mapper.Map<IList<hotelDTO>>(hotels);
                return Ok(Results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(GetallHotels)}");
                return StatusCode(500, "Internal Error. Please Try Again");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var Hotel = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Country" });
                var result = _mapper.Map<hotelDTO>(Hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(GetHotel)}");
                return StatusCode(500, "Internal Error. Please Try Again");
            }
        }


    }
}
