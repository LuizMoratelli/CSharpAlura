using System;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p != null && p is Torre && p.CorAtual == CorAtual && p.QuantidadeMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);
            //cima
            pos.DefinirValores(PosicaoAtual.Linha - 1, PosicaoAtual.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //ne
            pos.DefinirValores(PosicaoAtual.Linha - 1, PosicaoAtual.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.DefinirValores(PosicaoAtual.Linha, PosicaoAtual.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //se
            pos.DefinirValores(PosicaoAtual.Linha + 1, PosicaoAtual.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo
            pos.DefinirValores(PosicaoAtual.Linha + 1, PosicaoAtual.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //so
            pos.DefinirValores(PosicaoAtual.Linha + 1, PosicaoAtual.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //esquerda
            pos.DefinirValores(PosicaoAtual.Linha, PosicaoAtual.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //no
            pos.DefinirValores(PosicaoAtual.Linha - 1, PosicaoAtual.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //#jogadaespecial roque
            if (QuantidadeMovimentos == 0 && !partida.xeque)
            {
                Console.WriteLine("Entrou");
                //Roque pequeno
                Posicao posicaoTorre1 = new Posicao(PosicaoAtual.Linha, PosicaoAtual.Coluna + 3);
                if (testeTorreParaRoque(posicaoTorre1))
                {
                    Posicao p1 = new Posicao(PosicaoAtual.Linha, PosicaoAtual.Coluna + 1);
                    Posicao p2 = new Posicao(PosicaoAtual.Linha, PosicaoAtual.Coluna + 2);

                    if (Tab.GetPeca(p1) == null && Tab.GetPeca(p2) == null)
                    {
                        mat[PosicaoAtual.Linha, PosicaoAtual.Coluna + 2] = true;
                    }
                }

                //Roque grande
                Posicao posicaoTorre2 = new Posicao(PosicaoAtual.Linha, PosicaoAtual.Coluna - 4);
                if (testeTorreParaRoque(posicaoTorre2))
                {
                    Posicao p1 = new Posicao(PosicaoAtual.Linha, PosicaoAtual.Coluna - 1);
                    Posicao p2 = new Posicao(PosicaoAtual.Linha, PosicaoAtual.Coluna - 2);
                    Posicao p3 = new Posicao(PosicaoAtual.Linha, PosicaoAtual.Coluna - 3);

                    if (Tab.GetPeca(p1) == null && Tab.GetPeca(p2) == null && Tab.GetPeca(p3) == null)
                    {
                        mat[PosicaoAtual.Linha, PosicaoAtual.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
