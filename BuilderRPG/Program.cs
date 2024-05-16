
using BuilderRPG;
using DesignPatterns.BuilderRPG.Interface.Impl;

var builder = new Builder();

var mestre = new Mestre(builder);

Console.WriteLine("Utilizando o Mestre ");
Console.WriteLine(mestre.BuildMagoBarbaro("Nicolas", 15).ToString());
Console.WriteLine(mestre.BuildMagoLandino("Maria Eduarda", 7).ToString());

Console.WriteLine("Utilizando o Builder ");
builder.BuildLandino();
Console.WriteLine(builder.GetPersonagem("Judith", 10));

