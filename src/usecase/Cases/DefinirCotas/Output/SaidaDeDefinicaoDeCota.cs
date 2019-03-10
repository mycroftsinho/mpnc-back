using System.Collections.Generic;

namespace usecase.Cases.DefinirCotas.Output
{
    public class SaidaDeDefinicaoDeCota
    {
        public SaidaDeDefinicaoDeCota(bool situacao, ICollection<SaidaDeCota> cotas = null)
        {
            Situacao = situacao;
            Cotas = cotas;
        }

        public bool Situacao { get; private set; }

        public ICollection<SaidaDeCota> Cotas { get; private set; }
    }
}