namespace tabuleiro
{
    class Peca
    {
        public Posicao PosicaoAtual { get; set; }
        public Cor CorAtual { get; protected set; }
        public int quantidadeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            PosicaoAtual = null;
            Tab = tab;
            CorAtual = cor;
            quantidadeMovimentos = 0;
        }

        public override string ToString()
        {
            return "a";
        }
    }
}
