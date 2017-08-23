using GigHub.Dto;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.api
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        public ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && dto.GigId == a.GigId))
            {
                return BadRequest("The attendance already exists");
            }

            var atendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(atendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
