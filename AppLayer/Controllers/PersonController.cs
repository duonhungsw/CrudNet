using BusinessLayer.Model;
using DataLayer.Repository.IRopesitory;
using Microsoft.AspNetCore.Mvc;

namespace ZAppLayer.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository _personRepository;
        private readonly IRoomRepository _roomRepository;

        public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository, IRoomRepository roomRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
            _roomRepository = roomRepository;
        }
        [Route("/persons")]

        public async Task<IActionResult> viewPerson()
        {
      
            return View();
        }
        public IActionResult Index()
        {
            List<Person> persons = _personRepository.GetAll();
            return View(persons);
        }
    }
}
