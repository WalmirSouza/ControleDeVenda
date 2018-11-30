using MPSC.PlenoSoft.PlenoControle.Dominio.Abstracao;
using System;
using System.Data;

namespace MPSC.PlenoSoft.PlenoControle.AplicacaoAplicacao.Abstracao
{
	public class CasoDeUso
	{
		protected virtual void Proteger(Action<IDbTransaction> operacao)
		{
			var transacao = Conexao.Ativa.BeginTransaction();
			try
			{
				operacao?.Invoke(transacao);
				transacao.Commit();
			}
			catch (Exception)
			{
				transacao.Rollback();
				throw;
			}
			finally
			{
				transacao.Dispose();
			}
		}

		protected virtual TResult Proteger<TResult>(Func<IDbTransaction, TResult> operacao)
		{
			var transacao = Conexao.Ativa.BeginTransaction();
			try
			{
				var retorno = operacao.Invoke(transacao);
				transacao.Commit();
				return retorno;
			}
			catch (Exception)
			{
				transacao.Rollback();
				throw;
			}
			finally
			{
				transacao.Dispose();
			}
		}
	}

	public class CasoDeUso<TEntidade, TRepository> : CasoDeUso
		where TEntidade : Entidade
		where TRepository : Repository<TEntidade>, new()
	{
		protected TRepository Repository => new TRepository();

		public virtual TEntidade Obter(Int64 id)
		{
			return Repository.Obter(id);
		}

		public virtual TEntidade[] ObterTodos()
		{
			return Repository.ObterTodos();
		}

		public virtual void Incluir(TEntidade entidade)
		{
			Proteger(transacao =>
			{
				Repository.Incluir(transacao, entidade);
				Cache.Ativo.Incluir(entidade);
			});
		}

		public virtual void Alterar(TEntidade entidade)
		{
			Proteger(transacao =>
			{
				Repository.Alterar(transacao, entidade);
				Cache.Ativo.Alterar(entidade);
			});
		}

		public virtual void Excluir(TEntidade entidade)
		{
			Proteger(transacao =>
			{
				Repository.Excluir(transacao, entidade);
				Cache.Ativo.Excluir(entidade);
			});
		}
	}
}