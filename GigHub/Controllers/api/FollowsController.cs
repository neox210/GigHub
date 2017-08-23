using GigHub.Dto;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.api
{
    [Authorize]
    public class FollowsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowsDto dto)
        {
            var followerId = User.Identity.GetUserId();

            if (_context.Follows.Any(a => a.ArtistId == dto.ArtistId && a.FollowerId == followerId))
            {
                return BadRequest("The attendance already exists");
            }

            var follow = new Follows
            {
                ArtistId = dto.ArtistId,
                FollowerId = followerId
            };
            _context.Follows.Add(follow);
            _context.SaveChanges();

            return Ok();
        }
    }
}
