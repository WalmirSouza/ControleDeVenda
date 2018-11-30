using System;
using System.ComponentModel.DataAnnotations;

namespace MPSC.PlenoSoft.PlenoControle.Dominio.Abstracao
{
	public interface IUniqueId
	{
		Int64 UId { get; set; }
	}

	public interface IEntidade<TId> where TId : IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable
	{
		TId Id { get; set; }

		void Validar();
	}

	public abstract class Entidade : IUniqueId, IEntidade<Int64>
	{
		[Display(Name = "Id")]
		public virtual Int64 Id { get; set; }
		Int64 IUniqueId.UId { get => Id; set => Id = value; }

		public void Validar() => EhValido();

		protected abstract Boolean EhValido();
	}
}