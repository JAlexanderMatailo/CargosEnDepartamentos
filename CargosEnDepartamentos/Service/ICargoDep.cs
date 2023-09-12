using CargosEnDepartamentos.ViewModel;

namespace CargosEnDepartamentos.Service
{
    public interface ICargoDep
    {
        bool registrarDepartamentos(DepartamentosVM departamentosVM);
        List<DepartamentosVM> GetAllDepartamentos();
    }
}
