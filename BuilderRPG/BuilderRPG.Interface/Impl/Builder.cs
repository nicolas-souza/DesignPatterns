using DesignPatterns.BuilderRPG.Interface;

namespace DesignPatterns.BuilderRPG.Interface.Impl
{
    public class Builder : IBuilder
    {
        private Personagem _personagem = new();

        public void Build(string _nome)
        {
            _personagem.nome = _nome;
        }

        public void BuildMago() 
        {
            _personagem.classe.Add("Mago"); 
            _personagem.atributos.Add("AtaqueMagico", "20");
            _personagem.atributos.Add("DanoMagico", "5");

            
        }
        
        public void BuildBarbaro()
        {
            _personagem.classe.Add("Barbaro");
            _personagem.atributos.Add("AtaqueFisico", "20");
            _personagem.atributos.Add("DanoFisico", "10");

        }
        
        public void BuildLandino()
        {
            _personagem.classe.Add("Landino");
            _personagem.atributos.Add("AtaqueFurtivo", "20");
            _personagem.atributos.Add("DanoFurtivo", "2");

        }

        public Personagem GetPersonagem(string _nome, int dado)
        {
            this._personagem.nome = _nome;
            this._personagem.HP = dado*150;

            Personagem result = this._personagem;
            this.Reset();

            return result;
        }

        public void Reset()
        {
            this._personagem = new Personagem();
        }
    }
}


