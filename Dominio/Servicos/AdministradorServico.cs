using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTO;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    // 1. Construtor definido corretamente com suas próprias chaves
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador? BuscaPorId(int id)
    {
        return _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();

        return administrador;
    }

    // 2. Método Login definido dentro da classe, com o tipo de retorno correto
    public Administrador? Login(LoginDTO loginDTO)
    {
        var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

        return adm;
    }

    public List<Administrador> Todos(int? pagina)
    {
        var query = _contexto.Administradores.AsQueryable();
        int itensPorPagina = 10;

        if (pagina != null)
        {

            query = query.Skip((pagina.Value - 1) * itensPorPagina).Take(itensPorPagina);
        }

        return query.ToList();
    }
}




// namespace MinimalApi.Dominio.Servicos;

// public class AdministradorServico : IAdministradorServico
// {

//     private readonly DbContexto _contexto;
//     public AdministradorServico(DbContexto contexto)
//     public List<Administrador> Login(LoginDTO loginDTO)
//     {
//         _contexto = contexto;
//     }
// }

// public Administrador? Login(LoginDTO loginDTO)
//     {
//         var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

//         return adm;

//     }