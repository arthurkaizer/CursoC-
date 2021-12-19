namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; set; }
        public int qtdeMovimento {get; protected set;}
        public Tabuleiro tab { get; protected set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            this.posicao = null;
            this.cor = cor;
            this.qtdeMovimento = 0;
            this.tab = tab;
        }
        public void incrementarQtdeMovimento()
        {
            qtdeMovimento++;
        }

        public void decrementarQtdeMovimento()
        {
            qtdeMovimento--;
        }

        public bool existeMovimentoPossiveis()
        {
            bool[,] mat = movimentoPossiveis();
            for(int i = 0; i < tab.linha; i++)
            {
                for(int j = 0; j < tab.coluna; j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos)
        {
            return movimentoPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentoPossiveis();
    }
}
