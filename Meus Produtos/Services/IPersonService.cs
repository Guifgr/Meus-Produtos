using Meus_Produtos.Models;
using System.Collections.Generic;

namespace Meus_Produtos.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long Id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long Id);
    }
}
