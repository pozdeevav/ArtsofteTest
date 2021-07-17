using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IDatabaseRepository
    {
        public List<EmployeesModel> GetEmployees();

        public List<DepartamentsModel> GetDepartaments();

        public List<ProgrammingLanguagesModel> GetProgrammingLanguages();

        public List<EmployeesModel> GetDepartamentAndProgrammingLanguages();

        public EmployeesModel GetEmployee(int? id);

        public EmployeesModel DeleteEmployee(EmployeesModel model);

        public List<EmployeesModel> GetEmployeeDeparAndPL(int? id);

    }
}
