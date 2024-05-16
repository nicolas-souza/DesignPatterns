using DesignPatterns.BuilderRPG;
using DesignPatterns.BuilderRPG.Interface;
using DesignPatterns.BuilderRPG.Interface.Impl;

namespace BuilderRPG;

public class Mestre
{
    private IBuilder _builder;

    public Mestre(IBuilder builder)
    {
        _builder = builder;
    }



    public Personagem BuildMagoBarbaro(string _nome, int dado)
    {
        _builder.BuildMago();
        _builder.BuildBarbaro();

        return _builder.GetPersonagem(_nome, dado);
    }

    public Personagem BuildMagoLandino(string _nome, int dado)
    {
        _builder.BuildMago();
        _builder.BuildLandino();
        
        return _builder.GetPersonagem(_nome, dado);
    }
}
