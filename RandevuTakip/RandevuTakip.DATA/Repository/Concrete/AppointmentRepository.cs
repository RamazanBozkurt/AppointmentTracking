using RandevuTakip.DATA.Context;
using RandevuTakip.DATA.Repository.Abstract;
using RandevuTakip.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuTakip.DATA.Repository.Concrete
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return true;
        }

        public void EditAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public List<Appointment> GetAllAppointments()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public List<Appointment> GetApprovedAppointments()
        {
            return _context.Appointments.Where(a => a.IsApproved == true).ToList();
        }

        public List<Appointment> GetExpectedAppointments()
        {
            return _context.Appointments.Where(a => a.IsApproved == false).ToList();
        }

        public IQueryable<Appointment> Search(string searchTerm)
        {
            //var response = from a in _context.Appointments select a;

            var response = _context.Appointments.Where(a => a.IsApproved == true);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                response = _context.Appointments.Where(a => a.UserName.ToLower().Contains(searchTerm.ToLower())
                                                 || a.UserSurname.ToLower().Contains(searchTerm.ToLower())
                                                 || a.IdentificationNumber.Contains(searchTerm)
                                                 || a.City.ToLower().Contains(searchTerm.ToLower())
                                                 || a.AppointmentDate.ToString().Contains(searchTerm.ToString()));
            }

            return response;
        }
    }
}
