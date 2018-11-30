using Dapper;
using MPSC.PlenoSoft.PlenoControle.Dominio.Abstracao;
using System;
using System.Data;
using System.Linq;

namespace MPSC.PlenoSoft.PlenoControle.AplicacaoAplicacao.Abstracao
{
	public abstract class Repository<TEntidade> where TEntidade : Entidade
	{
		protected abstract String SqlSelectTodos { get; }
		protected abstract String SqlSelectPorId { get; }
		protected abstract String Cmd_Sql_Delete { get; }
		protected abstract String Cmd_Sql_Update { get; }
		protected abstract String Cmd_Sql_Insert { get; }

		protected abstract void PreSave(TEntidade entidade);

		protected virtual void OnSave(TEntidade entidade)
		{
			entidade.Validar();
			PreSave(entidade);
		}

		public virtual TEntidade Obter(Int64 id)
		{
			return Conexao.Ativa.QueryFirstOrDefault<TEntidade>(SqlSelectPorId, new { id });
		}

		public virtual TEntidade[] ObterTodos()
		{
			return Conexao.Ativa.Query<TEntidade>(SqlSelectTodos).ToArray();
		}

		public virtual void Incluir(IDbTransaction transacao, TEntidade entidade)
		{
			OnSave(entidade);
			entidade.Id = Conexao.Ativa.ExecuteScalar<Int64>(Cmd_Sql_Insert, entidade, transacao);
		}

		public virtual void Alterar(IDbTransaction transacao, TEntidade entidade)
		{
			OnSave(entidade);
			Conexao.Ativa.Execute(Cmd_Sql_Update, entidade, transacao);
		}

		public virtual void Excluir(IDbTransaction transacao, TEntidade entidade)
		{
			Conexao.Ativa.Execute(Cmd_Sql_Delete, entidade, transacao);
		}
	}
}