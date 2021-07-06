using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAt_Entity.Repository
{
    public interface IRepositoryAmigo
    {
        void Create(Amigo amigo); 
        void Update(Amigo amigo, int id);
        void Delete(int idAmigo);
        Amigo GetAmigoById(int id);
        List<Amigo> GetName(string nome);
        List<Amigo> GetAll();
    }
}
