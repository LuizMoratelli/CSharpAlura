using System;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);
            //cima
            pos.DefinirValores(PosicaoAtual.Linha - 1, PosicaoAtual.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).CorAtual != CorAtual)
                {
                    break;
                }

                pos.Linha--;
            }

            //direita
            pos.DefinirValores(PosicaoAtual.Linha, PosicaoAtual.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).CorAtual != CorAtual)
                {
                    break;
                }

                pos.Coluna++;
            }

            //abaixo
            pos.DefinirValores(PosicaoAtual.Linha + 1, PosicaoAtual.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).CorAtual != CorAtual)
                {
                    break;
                }

                pos.Linha++;
            }

            //esquerda
            pos.DefinirValores(PosicaoAtual.Linha, PosicaoAtual.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).CorAtual != CorAtual)
                {
                    break;
                }

                pos.Coluna--;
            }

            return mat;
        }
    }
}
