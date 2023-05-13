using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataSources
    {
        TaskTrackerDBEntities db = new TaskTrackerDBEntities();
        public List<Employees> Employees { get; set; }
        public List<EmployeeStatus> EmployeeStatuses { get; set; }
        public List<EmployeePriority> EmployeePriorities { get; set; }
        public List<EmployeeTasks> EmployeeTasks { get; set; }

        public DataSources()
        {
            Employees = db.Employees.Select(e => e).ToList();
            EmployeeStatuses = db.EmployeeStatus.Select(s => s).ToList();
            EmployeePriorities = db.EmployeePriority.Select(p => p).ToList();
            EmployeeTasks = db.EmployeeTasks.Select(t => t).ToList();

        }
            //public DataSourses()
            //{
            //    Employees = (List<Employees>)(from emp in db.Employees
            //                                  select new
            //                                  {
            //                                      Id = emp.Id,
            //                                      Name = emp.Name,
            //                                      Role = emp.Role,
            //                                      Password = emp.Password
            //                                  });

            //}


        }
    }
