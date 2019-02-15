namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao PosicaoAtual { get; set; }
        public Cor CorAtual { get; protected set; }
        public int QuantidadeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            PosicaoAtual = null;
            Tab = tab;
            CorAtual = cor;
            QuantidadeMovimentos = 0;
        }

        public void IncrementarMovimento()
        {
            QuantidadeMovimentos++;
        }

        protected bool PodeMover(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p == null || p.CorAtual != CorAtual;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
