using MPSC.PlenoSoft.PlenoControle.AplicacaoAplicacao.Abstracao;
using MPSC.PlenoSoft.PlenoControle.Dominio.Entidades;
using System;

namespace MPSC.PlenoSoft.PlenoControle.AplicacaoAplicacao.Repositorios.Cadastros
{
	public class ClienteRepository : Repository<Cliente>
	{
		protected override String SqlSelectTodos => @"Select * From Cliente;";
		protected override String SqlSelectPorId => @"Select * From Cliente Where (Id = @id);";
		protected override String Cmd_Sql_Delete => @"Delete From Cliente Where (Id = @id);";
		protected override String Cmd_Sql_Update => @"Update Cliente Set Nome = @nome, CPF = @cpf, Localizacao = @localizacao Where (Id = @id);";
		protected override String Cmd_Sql_Insert => @"Insert Into Cliente (Nome, CPF, Localizacao) Values (@nome, @cpf, @localizacao); Select Scope_Identity() As Id;";

		protected override void PreSave(Cliente cliente) { }
	}
}