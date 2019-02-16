using System;
using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override string ToString()
        {
            return "D";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //ne
            pos.DefinirValores(PosicaoAtual.Linha - 1, PosicaoAtual.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).CorAtual != CorAtual)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            //se
            pos.DefinirValores(PosicaoAtual.Linha + 1, PosicaoAtual.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).CorAtual != CorAtual)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            //so
            pos.DefinirValores(PosicaoAtual.Linha + 1, PosicaoAtual.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).CorAtual != CorAtual)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            //no
            pos.DefinirValores(PosicaoAtual.Linha - 1, PosicaoAtual.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).CorAtual != CorAtual)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

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
