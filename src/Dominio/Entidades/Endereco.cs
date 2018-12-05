using MPSC.PlenoSoft.PlenoControle.Dominio.Abstracao;
using System;
using System.Text.RegularExpressions;

namespace MPSC.PlenoSoft.PlenoControle.Dominio.Entidades
{
	public class Endereco : Entidade
	{
		public string Logradouro { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string CEP { get; set; }

		protected override Boolean EhValido()
		{
			if (string.IsNullOrWhiteSpace(Logradouro))
				throw new ApplicationException("Logradouro Não Deve Ser Nulo ou Branco!");

			if (Logradouro.Length > 15)
				throw new ApplicationException("Logradouro deve entre de 1 a 15 Caracteres!");

			if (string.IsNullOrWhiteSpace(Numero))
				throw new ApplicationException("Número Não Deve Ser Nulo ou Branco!");

			if (Numero.Length > 15)
				throw new ApplicationException("Número deve ter entre de 1 e 15 Caracteres!");

			if (string.IsNullOrWhiteSpace(Bairro))
				throw new ApplicationException("Bairro Não Deve Ser Nulo ou Branco!");

            if (Bairro.Length > 15)
                throw new ApplicationException("Bairro deve ter entre de 1 e 15 Caracteres!");

            if (string.IsNullOrWhiteSpace(Cidade))
                throw new ApplicationException("Cidade Não Deve Ser Nulo ou Branco!");

            if (Cidade.Length > 15)
                throw new ApplicationException("Cidade deve ter entre de 1 e 15 Caracteres!");

            if (string.IsNullOrWhiteSpace(Estado))
                throw new ApplicationException("Estado Não Deve Ser Nulo ou Branco!");

            if (Estado.Length > 2)
                throw new ApplicationException("Estado deve ter 2 Caracteres!");

            if (Regex.Replace(Estado, "[0-9]", "").Length < 2)
                throw new ApplicationException("Estado só deve conter Letras!");

            if (string.IsNullOrWhiteSpace(CEP))
                throw new ApplicationException("CEP Não deve ser Nulo");

            if (CEP.Length < 8)
                throw new ApplicationException("CEP Não Pode Conter Menos de 8 digitos!");

            if (Regex.Replace(CEP, "[a-zA-Z]", "").Length < 8)
                throw new ApplicationException("CEP Não Pode Conter Letras!");


            return true;


		}
	}
}