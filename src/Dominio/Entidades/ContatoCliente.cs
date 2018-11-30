using MPSC.PlenoSoft.PlenoControle.Dominio.Abstracao;
using System;

namespace MPSC.PlenoSoft.PlenoControle.Dominio.Entidades
{
	public class ContatoCliente : Entidade
	{
		public string Valor { get; set; }
		public TipoDeContato TipoDeContato { get; set; }

		protected override Boolean EhValido()
		{
			return true;
		}
	}
}