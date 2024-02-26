using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
        where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(Guid id);
    }
}
