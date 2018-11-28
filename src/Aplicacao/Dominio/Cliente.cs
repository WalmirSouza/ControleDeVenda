using System;
using System.Text.RegularExpressions;

namespace Aplicacao.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Localizacao { get; set; }

        public bool EhValido()
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                throw new ApplicationException("Nome não Pode ser Branco ou Nulo!");
            }
            else if (Nome.Length < 6)
            {
                throw new ApplicationException("Nome Deve ter mais de 6 Cadacteres!");
            }
            else if (Regex.Replace(Nome,"[!@#$%¨&*()+_}^{`:><?/;.,~´=-]", "").Length != Nome.Length)
            {
                throw new ApplicationException("Nome Não Deve Conter Cadacteres Especiais!");
            }
            else if (Regex.Replace(Nome, "[0-9]", "").Length != Nome.Length)
            {
                throw new ApplicationException("Nome Não Deve Conter Numeros!");
            }
            else if(string.IsNullOrWhiteSpace(CPF))
            {
                throw new ApplicationException("CPF não Deve ser Nulo!");
            }
            else if (Regex.Replace(CPF, "[0-9]","").Length > 0 )
            {
                throw new ApplicationException("CPF deve conter apenas Numeros!");
            }
            else if (CPF.Length != 11)
            {
                throw new ApplicationException("Quantidade de Dígitos de CPF deve Ser Igual a 11!");
            }

            return true;


        }
    }
}
