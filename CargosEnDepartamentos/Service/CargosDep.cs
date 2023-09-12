using CargosEnDepartamentos.Models;
using CargosEnDepartamentos.ViewModel;

namespace CargosEnDepartamentos.Service
{
    public class CargosDep : ICargoDep
    {
        CargosEnDepartamentosContext _context;
        public CargosDep(CargosEnDepartamentosContext context)
        {
            _context = context;
        }
        #region Departamentos
        public bool registrarDepartamentos(DepartamentosVM departamentosVM)
        {
            var existe = _context.Departamentos.Where(x => x.NombreDepartamento == departamentosVM.NombreDepartamento).Any();
            bool registrado = false;
            if (!existe)
            {
                using (var context  = _context.Database.BeginTransaction()) {
                    try
                    {
                        Departamento departamento = new Departamento
                        {
                            NombreDepartamento = departamentosVM.NombreDepartamento,
                            Estado = departamentosVM.Estado

                        };
                        _context.Departamentos.Add(departamento);
                        _context.SaveChanges();

                        context.Commit();

                        registrado = true;
                    }
                    catch (Exception)
                    {
                        context.Rollback();
                        registrado = true;
                    }
                }
            }
            return registrado;
        }

        public List<DepartamentosVM> GetAllDepartamentos()
        {
            List<DepartamentosVM> listdepartamentosVMs = new List<DepartamentosVM>();
            var departamentos = _context.Departamentos.ToList();
            foreach(var item in listdepartamentosVMs) {
                DepartamentosVM departament = new DepartamentosVM
                {
                    IdDepartamento = item.IdDepartamento,
                    NombreDepartamento = item.NombreDepartamento,
                    Estado = item.Estado,
                };
                listdepartamentosVMs.Add(departament);
            };
            return listdepartamentosVMs;
        }

        #endregion
    }
}
