using RandevuTakip.DATA.Repository.Abstract;
using RandevuTakip.ENTITIES;
using RandevuTakip.SERVICES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuTakip.SERVICES.Concrete
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public bool CreateAppointment(Appointment appointment)
        {
            appointment.IsApproved = false;

            if(appointment.AppointmentDate >= DateTime.Now && IsIdentificationNumberConfirmed(appointment.IdentificationNumber) == true)
            {
                _repository.CreateAppointment(appointment);
                return true;
            }

            return false;
        }

        public void EditAppointment(Appointment appointment)
        {
            appointment.IsApproved = true;
            _repository.EditAppointment(appointment);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _repository.GetAllAppointments();
        }


        public Appointment GetAppointmentById(int id)
        {
            return _repository.GetAppointmentById(id);
        }

        public List<Appointment> GetApprovedAppointments()
        {
            return _repository.GetApprovedAppointments();
        }

        public List<Appointment> GetExpectedAppointments()
        {
            return _repository.GetExpectedAppointments();
        }

        public bool IsIdentificationNumberConfirmed(string identificationNumber)
        {
            bool returnvalue = false;
            if (identificationNumber.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(identificationNumber);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }

        public IQueryable<Appointment> Search(string searchTerm)
        {
            return _repository.Search(searchTerm);
        }
    }
}
