using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using BigSchool.DTOs;

namespace BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbConText;
        public AttendancesController()
        {
            _dbConText = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (
                _dbConText.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exist!");

            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId

            };
            _dbConText.Attendances.Add(attendance);
            _dbConText.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendance = _dbConText.Attendances.SingleOrDefault(a => a.AttendeeId == userId && a.CourseId == id);
            if (attendance == null)
            {
                return NotFound();
            }
            _dbConText.Attendances.Remove(attendance);
            _dbConText.SaveChanges();
            return Ok(id);
        }
    }

}

