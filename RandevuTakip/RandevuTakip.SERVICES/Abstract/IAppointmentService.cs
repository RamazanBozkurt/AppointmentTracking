using RandevuTakip.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuTakip.SERVICES.Abstract
{
    public interface IAppointmentService
    {
        bool CreateAppointment(Appointment appointment);
        List<Appointment> GetExpectedAppointments();
        List<Appointment> GetApprovedAppointments();
        Appointment GetAppointmentById(int id);
        void EditAppointment(Appointment appointment);
        List<Appointment> GetAllAppointments();
        IQueryable<Appointment> Search(string searchTerm);
        bool IsIdentificationNumberConfirmed(string identificationNumber);
    }
}
