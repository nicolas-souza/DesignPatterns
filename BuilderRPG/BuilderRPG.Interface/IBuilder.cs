namespace DesignPatterns.BuilderRPG.Interface
{
    public interface IBuilder
    {
        void Build(string name);
        void BuildMago();
        
        void BuildBarbaro();
        
        void BuildLandino();
        Personagem GetPersonagem(string _nome, int dado);
    }

}

