﻿using MPSC.PlenoSoft.PlenoControle.Dominio.Abstracao;
using System;
using System.Text.RegularExpressions;

namespace MPSC.PlenoSoft.PlenoControle.Dominio.Entidades
{
	public class Cliente : Entidade
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string Localizacao { get; set; }

		protected override Boolean EhValido()
		{
			if (string.IsNullOrWhiteSpace(Nome))
				throw new ApplicationException("Nome não Pode ser Branco ou Nulo!");

			if (Nome.Length < 6)
				throw new ApplicationException("Nome Deve ter mais de 6 Cadacteres!");

			if (Regex.Replace(Nome, "[!@#$%¨&*()+_}^{`:><?/;.,~´=-]", "").Length != Nome.Length)
				throw new ApplicationException("Nome Não Deve Conter Cadacteres Especiais!");

			if (Regex.Replace(Nome, "[0-9]", "").Length != Nome.Length)
				throw new ApplicationException("Nome Não Deve Conter Numeros!");

			if (string.IsNullOrWhiteSpace(CPF))
				throw new ApplicationException("CPF não Deve ser Nulo!");

			if (Regex.Replace(CPF, "[0-9]", "").Length > 0)
				throw new ApplicationException("CPF deve conter apenas Numeros!");

			if (CPF.Length != 11)
				throw new ApplicationException("Quantidade de Dígitos de CPF deve Ser Igual a 11!");

            if (string.IsNullOrWhiteSpace(Localizacao))
                throw new ApplicationException("Localização não Deve Ser Nula!");

			return true;
		}
	}
}