using Aplicacao.Dominio.Enum;

namespace Aplicacao.Dominio
{
    public class ContatoCliente
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public TipoDeContato TipoDeContato { get; set; }
    }
}
