using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            this.tab = new Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdeMovimento();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            // #jogadaespecial roque pequeno
            if(p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tab.retirarPeca(origemT);
                T.incrementarQtdeMovimento();
                tab.colocarPeca(T, destinoT);
            }

            // #jogadaespecial roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Peca T = tab.retirarPeca(origemT);
                T.incrementarQtdeMovimento();
                tab.colocarPeca(T, destinoT);
            }
            return pecaCapturada;
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executarMovimento(origem, destino);
            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroExceptions("Voce não pode se colocar em Xeque!");
            }

            if (estaEmXeque(adversaria(jogadorAtual))){
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (testeXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudaJogador();
            }
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQtdeMovimento();
            if(pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);

            // #jogadaespecial roque pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tab.retirarPeca(destinoT);
                T.decrementarQtdeMovimento();
                tab.colocarPeca(T, origemT);
            }

            // #jogadaespecial roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Peca T = tab.retirarPeca(destinoT);
                T.decrementarQtdeMovimento();
                tab.colocarPeca(T, origemT);
            }
        }

        private void mudaJogador()
        {
            if(jogadorAtual == Cor.branca)
            {
                jogadorAtual = Cor.preta;
            }
            else
            {
                jogadorAtual = Cor.branca;
            }
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroExceptions("Não existe peça na posição de origem escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroExceptions("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentoPossiveis())
            {
                throw new TabuleiroExceptions("Não existe movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroExceptions("Posição de destino inválida");
            }
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
    
        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre(Cor.branca, tab));
            colocarNovaPeca('b', 1, new Cavalo(Cor.branca, tab));
            colocarNovaPeca('c', 1, new Bispo(Cor.branca, tab));
            colocarNovaPeca('d', 1, new Dama(Cor.branca, tab));
            colocarNovaPeca('e', 1, new Rei(Cor.branca, tab, this));
            colocarNovaPeca('f', 1, new Bispo(Cor.branca, tab));
            colocarNovaPeca('g', 1, new Cavalo(Cor.branca, tab));
            colocarNovaPeca('h', 1, new Torre(Cor.branca, tab));
            colocarNovaPeca('a', 2, new Peao(Cor.branca, tab));
            colocarNovaPeca('b', 2, new Peao(Cor.branca, tab));
            colocarNovaPeca('c', 2, new Peao(Cor.branca, tab));
            colocarNovaPeca('d', 2, new Peao(Cor.branca, tab));
            colocarNovaPeca('e', 2, new Peao(Cor.branca, tab));
            colocarNovaPeca('f', 2, new Peao(Cor.branca, tab));
            colocarNovaPeca('g', 2, new Peao(Cor.branca, tab));
            colocarNovaPeca('h', 2, new Peao(Cor.branca, tab));


            colocarNovaPeca('a', 8, new Torre(Cor.preta, tab));
            colocarNovaPeca('b', 8, new Cavalo(Cor.preta, tab));
            colocarNovaPeca('c', 8, new Bispo(Cor.preta, tab));
            colocarNovaPeca('d', 8, new Dama(Cor.preta, tab));
            colocarNovaPeca('e', 8, new Rei(Cor.preta, tab, this));
            colocarNovaPeca('f', 8, new Bispo(Cor.preta, tab));
            colocarNovaPeca('g', 8, new Cavalo(Cor.preta, tab));
            colocarNovaPeca('h', 8, new Torre(Cor.preta, tab));
            colocarNovaPeca('a', 7, new Peao(Cor.preta, tab));
            colocarNovaPeca('b', 7, new Peao(Cor.preta, tab));
            colocarNovaPeca('c', 7, new Peao(Cor.preta, tab));
            colocarNovaPeca('d', 7, new Peao(Cor.preta, tab));
            colocarNovaPeca('e', 7, new Peao(Cor.preta, tab));
            colocarNovaPeca('f', 7, new Peao(Cor.preta, tab));
            colocarNovaPeca('g', 7, new Peao(Cor.preta, tab));
            colocarNovaPeca('h', 7, new Peao(Cor.preta, tab));
        }

        private Cor adversaria(Cor cor)
        {
            if(cor == Cor.branca)
            {
                return Cor.preta;
            }
            return Cor.branca;
        }

        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if(R == null)
            {
                throw new TabuleiroExceptions("Não existe Rei");
            }
            foreach(Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentoPossiveis();
                if(mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequeMate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentoPossiveis();
                for(int i = 0; i < tab.linha; i++)
                {
                    for(int j = 0; j < tab.coluna; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executarMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
    }
}
