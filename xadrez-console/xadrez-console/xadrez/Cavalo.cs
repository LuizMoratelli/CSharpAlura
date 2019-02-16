using System;
using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(PosicaoAtual.Linha - 1, PosicaoAtual.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(PosicaoAtual.Linha - 2, PosicaoAtual.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(PosicaoAtual.Linha - 2, PosicaoAtual.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(PosicaoAtual.Linha - 1, PosicaoAtual.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(PosicaoAtual.Linha + 1, PosicaoAtual.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(PosicaoAtual.Linha + 2, PosicaoAtual.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(PosicaoAtual.Linha + 2, PosicaoAtual.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(PosicaoAtual.Linha + 1, PosicaoAtual.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) mat[pos.Linha, pos.Coluna] = true;

            return mat;
        }
    }
}
