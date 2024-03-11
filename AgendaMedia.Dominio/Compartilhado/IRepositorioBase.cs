using System;

namespace AgendaMedica.Dominio.Compartilhado
{
    public interface IRepositorioBase<TEntidade> where TEntidade : Entidade
    {
        void Editar(TEntidade registro);
        void Excluir(TEntidade registro);

        TEntidade SelecionarPorId(Guid id);
        Task<bool> InserirAsync(TEntidade registro);
        Task<TEntidade> SelecionarPorIdAsync(Guid id);
        Task<List<TEntidade>> SelecionarTodosAsync();
    }
}
