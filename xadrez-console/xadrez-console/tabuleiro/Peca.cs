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

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();

            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j]) return true;
                }
            }

            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        protected bool PodeMover(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p == null || p.CorAtual != CorAtual;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
