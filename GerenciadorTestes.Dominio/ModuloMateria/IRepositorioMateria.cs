using GerenciadorTestes.Dominio.Compartilhado;
using System.Collections.Generic;

namespace GerenciadorTestes.Dominio.ModuloMateria
{
    public interface IRepositorioMateria : IRepositorio<Materia>
    {  
        List<Materia> SelecionarTodoss();
    }
}