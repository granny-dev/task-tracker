using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLibrary
{
    public class DatabaseInteraction
    {
        private readonly TaskTrackerDBEntities _db;

        public DatabaseInteraction(TaskTrackerDBEntities db)
        {
            _db = db;
        }

        public ObservableCollection<EmployeeTasks> EmployeeTasks { get; private set; }

        public Employees[] Employees { get; private set; }
        public EmployeeStatus[] EmployeeStatus { get; private set; }
        public EmployeePriority[] EmployeePriority { get; private set; }

        public void Load()
        {
            _db.EmployeeTasks.Load();
            EmployeeTasks = _db.EmployeeTasks.Local;

            Employees = _db.Employees.ToArray();
            EmployeeStatus = _db.EmployeeStatus.ToArray();
            EmployeePriority = _db.EmployeePriority.ToArray();
        }

        public void Save()
        {
            _db.SaveChanges();

        }

        public void Delete(object sender)
        {
            _db.EmployeeTasks.Remove((EmployeeTasks)sender);
            _db.SaveChanges();
        }
    }    

}
