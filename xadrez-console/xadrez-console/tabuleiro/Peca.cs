namespace tabuleiro
{
    class Peca
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
    }
}
