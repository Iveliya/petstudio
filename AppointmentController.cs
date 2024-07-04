using Microsoft.EntityFrameworkCore;
using pets.Data;
using pets.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pets.Controller
{
    public class AppointmentController
    {
        PetsDbContext context = new PetsDbContext();
        //Dictionary<string, List<string>> allHour = new Dictionary<string, List<string>>();

        public async Task<Dictionary<string, List<string>>> AllHourProgram()
        {
            Dictionary<string, List<string>> allHour = new Dictionary<string, List<string>>();
            List<Appointment> appointments=await context.Appointments.ToListAsync();
            //List<string> hours = new List<string>();
            foreach (Appointment a in appointments)
            {
                var appointmentDate = a.Date.Date;
                int appointmentHour = a.Date.Hour;
                //Appointment appointment = appointments.FirstOrDefault(ap => ap.Date == data);
                if(appointmentHour>=8 && appointmentHour <= 16)
                {
                    //hours.Add(appointmentHour.ToString());
                    
                    if (allHour.ContainsKey(appointmentDate.ToString()))
                    {
                        List<string> hours = new List<string>();
                        foreach (var x in allHour[appointmentDate.ToString()])
                        {
                            hours.Add(x.ToString());
                        }
                        hours.Add(appointmentHour.ToString());
                        allHour[appointmentDate.ToString()] = hours;
                    }
                    else
                    {
                        List<string> hours1 = new List<string>();
                        string hour=appointmentHour.ToString();
                        hours1.Add(hour);
                        allHour[appointmentDate.ToString()] = hours1;
                        //allHour.Add(appointmentDate.ToString(),hours);
                        
                    }
                }
                
            }
            return allHour;
            
        }
        
        public async Task<Appointment> GetAppointment(int id)
        {
            var appointment = await context.Appointments.FindAsync(id);       
            return  appointment;
        }
        public async Task<List<string>> FreeHours(string date)
        {
            Dictionary<string, List<string>> reservedHour = await AllHourProgram();
            List<string> hours = new List<string>();
            if(reservedHour.ContainsKey(date.ToString()))
            {
                for (int i = 8; i <= 16; i++)
                {
                    if (!reservedHour[date.ToString()].Contains(i.ToString()))
                    {
                        hours.Add(i.ToString());
                    }
                }
            }
            else
            {
                for (int i = 8; i <= 16; i++)
                {
                    hours.Add(i.ToString());
                }
            }
            return hours;

        }

        public async Task<string> CreateAppointment(DateTime date,int dutarion,int animalId,int employeeId)
        {

            Appointment appointment = new Appointment();
            appointment.Date = date;
            appointment.Duration = dutarion;
            appointment.AnimalId= animalId;
            appointment.EmployeeId= employeeId;
            context.Appointments.Add(appointment);
            await context.SaveChangesAsync();
            return  "Completed!";
        }
        public async Task<bool> IsNullAppointment(int id)
        {
           bool isNull = true;
            var a = await context.Appointments.FindAsync(id);
            if (a != null)
            {
                isNull = false;
            }
            return isNull;

        }

        public async Task<string> UpdateAppointment(int id, DateTime date, int dutarion, int animalId, int employeeId)
        {
            var a = await context.Appointments.FindAsync(id);
            if (a != null)
            {
                a.Date = date;
                a.Duration = dutarion;
                a.AnimalId= animalId;
                a.EmployeeId= employeeId;
                await context.SaveChangesAsync();
                return "Completed!";
            }
            else
            {
                return  "Non-existent Client!";
            }
        }

        public async Task<string> DeleteAppointment(int id)
        {
            var appointment = await context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return "Non-existent Client!";
            }

            context.Appointments.Remove(appointment);
            await context.SaveChangesAsync();

            return "Completed!";
        }

        public async Task<List<Appointment>> AllAppointments()
        {
            return await context.Appointments.ToListAsync();
        }


    }
}
