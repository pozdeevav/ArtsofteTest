using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {

        public DataBaseContext DataBaseContext;

        public DatabaseRepository(DataBaseContext dataBaseContext)
        {
            this.DataBaseContext = dataBaseContext;
        }

        public List<EmployeesModel> GetEmployees() //метод получения списка сотрудников
        {
            using (DataBaseContext)
            {
                var query = DataBaseContext.employees.FromSqlRaw("SELECT Employees.EmployeeId, Employees.FirstName, Employees.SecondName, Employees.Age, Departaments.DepartamentName AS Departament, " +
                    "ProgrammingLanguages.ProgrammingLanguage AS ProgrammingLanguageId FROM Employees, Departaments, ProgrammingLanguages WHERE Departaments.DepartamentId = Employees.Departament " +
                    "AND ProgrammingLanguages.ProgrammingLanguageId = Employees.ProgrammingLanguageId").ToList();
                return query;
            }
        }

        public List<DepartamentsModel> GetDepartaments() //метод получения отделов
        {
            using (DataBaseContext)
            {
                var query = DataBaseContext.departaments.FromSqlRaw("SELECT * FROM Departaments").ToList();
                return query;
            }
        }

        public List<ProgrammingLanguagesModel> GetProgrammingLanguages() //метод получения языков программирования
        {
            using (DataBaseContext)
            {
                var query = DataBaseContext.programmingLanguages.FromSqlRaw("SELECT * FROM ProgrammingLanguages").ToList();
                return query;
            }
        }

        public List<EmployeesModel> GetDepartamentAndProgrammingLanguages() //метод получения отделов и языков программирования
        {
            using (DataBaseContext)
            {
                var departaments = DataBaseContext.departaments.FromSqlRaw("SELECT * FROM Departaments").ToList();

                var programmingLangauages = DataBaseContext.programmingLanguages.FromSqlRaw("SELECT * FROM ProgrammingLanguages").ToList();

                var query = new List<EmployeesModel>();

                for (int i = 0; i < programmingLangauages.Count; i++)
                {
                    query.Add(new EmployeesModel
                    {
                        EmployeeId = programmingLangauages[i].ProgrammingLanguageId,
                        FirstName = null,
                        SecondName = null,
                        Age = 0,
                        Departament = null,
                        ProgrammingLanguageId = programmingLangauages[i].ProgrammingLanguage
                    });
                }

                for (int i = 0; i < departaments.Count; i++)
                {
                    query.Add(new EmployeesModel
                    {
                        EmployeeId = departaments[i].DepartamentId,
                        FirstName = null,
                        SecondName = null,
                        Age = 0,
                        Departament = departaments[i].DepartamentName,
                        ProgrammingLanguageId = null
                    });
                }
                return query;
            }
        }

        public EmployeesModel GetEmployee(int? id) //метод получения записи о сотруднике по ID
        {
            using(DataBaseContext)
            {
                var query = DataBaseContext.employees.FromSqlRaw("SELECT Employees.EmployeeId, Employees.FirstName, Employees.SecondName, Employees.Age, Departaments.DepartamentName AS Departament, " +
                    "ProgrammingLanguages.ProgrammingLanguage AS ProgrammingLanguageId FROM Employees, Departaments, ProgrammingLanguages WHERE Employees.Departament = DepartamentId " +
                    "AND Employees.ProgrammingLanguageId = ProgrammingLanguages.ProgrammingLanguageId AND Employees.EmployeeId = " + id).FirstOrDefault();

                return query;
            }
        }

        public EmployeesModel DeleteEmployee(EmployeesModel model)
        {
            using(DataBaseContext)
            {
                var query = DataBaseContext.employees.FromSqlRaw("DELETE FROM Employees WHERE EmployeeId = " + model.EmployeeId);
                return null;
            }
        }

        public List<EmployeesModel> GetEmployeeDeparAndPL(int? id) //метод получения отделов и языков программирования и записи о сотруднике
        {
            using (DataBaseContext)
            {
                var departaments = DataBaseContext.departaments.FromSqlRaw("SELECT * FROM Departaments").ToList();

                var programmingLangauages = DataBaseContext.programmingLanguages.FromSqlRaw("SELECT * FROM ProgrammingLanguages").ToList();

                var employee = DataBaseContext.employees.FromSqlRaw("SELECT Employees.EmployeeId, Employees.FirstName, Employees.SecondName, Employees.Age, Departaments.DepartamentName AS Departament, " +
                    "ProgrammingLanguages.ProgrammingLanguage AS ProgrammingLanguageId FROM Employees, Departaments, ProgrammingLanguages WHERE Employees.Departament = DepartamentId " +
                    "AND Employees.ProgrammingLanguageId = ProgrammingLanguages.ProgrammingLanguageId AND Employees.EmployeeId = " + id).FirstOrDefault();

                var query = new List<EmployeesModel>();

                query.Add(employee);

                for (int i = 0; i < programmingLangauages.Count; i++)
                {
                    query.Add(new EmployeesModel
                    {
                        EmployeeId = programmingLangauages[i].ProgrammingLanguageId,
                        FirstName = null,
                        SecondName = null,
                        Age = 0,
                        Departament = null,
                        ProgrammingLanguageId = programmingLangauages[i].ProgrammingLanguage
                    });
                }

                for (int i = 0; i < departaments.Count; i++)
                {
                    query.Add(new EmployeesModel
                    {
                        EmployeeId = departaments[i].DepartamentId,
                        FirstName = null,
                        SecondName = null,
                        Age = 0,
                        Departament = departaments[i].DepartamentName,
                        ProgrammingLanguageId = null
                    });

                }
                return query;
            }
        }
    }
}




