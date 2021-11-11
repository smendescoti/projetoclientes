using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface genérica para definir os métodos base do dominio.
    /// </summary>
    /// <typeparam name="T">Tipo genérico que representa qualquer entidade do projeto</typeparam>
    public interface IBaseDomainService<T> where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(Guid id);
    }
}
