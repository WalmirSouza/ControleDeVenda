using System;

namespace MPSC.PlenoSoft.PlenoControle.Dominio.Entidades
{
	public class Endereco
	{
		public int Id { get; set; }
		public string Logradouro { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string CEP { get; set; }

		public bool EhValido()
		{
			if (string.IsNullOrWhiteSpace(Logradouro))
				throw new ApplicationException("Logradouro Não Deve Ser Nulo ou Branco!");

			if (Logradouro.Length > 15)
				throw new ApplicationException("Logradouro deve entre de 1 a 15 Caracteres!");

			if (string.IsNullOrWhiteSpace(Numero))
				throw new ApplicationException("Número Não Deve Ser Nulo ou Branco!");

			if (Numero.Length > 15)
				throw new ApplicationException("Numero deve entre de 1 a 15 Caracteres!");

			if (string.IsNullOrWhiteSpace(Bairro))
				throw new ApplicationException("Bairro Não Deve Ser Nulo ou Branco!");


			return true;


		}
	}
}