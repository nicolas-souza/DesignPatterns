Seguindo os estudos sobre Design Patterns, hoje vou escrever um pouco sobre Builder! 

## Objetivo do padrão 

>[!info]
>Builder é um padrão criacional que nos auxilia na criação de objetos complexos, passo a passo, permitindo a produção de diferentes tipos e representações de um objeto usando um mesmo código de construção

## Qual problema ele resolve?


Imagine um objeto complexo com inúmeros campos, com objetos agregados, e que sua inicialização necessite da realização de inúmeros passos e interações. Poderíamos deixar que o cliente que usará nossa classe, fique responsável por implementar os passos, mas estaríamos assumindo um risco muito grande de que os passos não sejam respeitados, criando objetos com comportamentos errôneos.

Mas, Nicolas, eu poderia criar um objeto intermediário e passar ele na construção. Sim, você poderia resolver esse problema de inúmeras formas, mas ficaria intuitivo para outros dev's no futuro? Talvez sim. 

Não pense nos padrões como regras absolutas, padrões são acima de tudo sugestões de modelos já consolidados no mercado para elucidar problemas comuns. Cabe a cada desenvolvedor a responsabilidade de interpretar se é uma boa ideia ou não, o famoso: depende!

## Vamos usar um exemplo?!

Nos materiais que usei para estudar, os exemplos geralmente giram em torno de casas, carros... Isso por que é bem intuitivo entender que um mesmo objeto carro pode ser criado de inúmeras formas, manual, automático, com 2 ou 3 portas... Tentei fugir um pouco do óbvio, pode dar errado, então me contem nos comentários 🤞

Vamos pensar em um jogo de RPG, onde os jogadores podem montar o seu personagem. Cada personagem será construído de uma forma, com atributos e comportamentos diferentes um dos outros. Além disso, algo comum em alguns RPG's é a possibilidade de combinarmos tipos, por exemplo, posso criar um Mago Bárbaro e ter inúmeras combinações...

>[!warning]
>Farei inúmeras limitações, o objetivo aqui é explicar o padrão builder e não criar um jogo!

Para começar, vamos criar nossa classe personagem, será ela que terá n construções possíveis.

```cs
public class Personagem
{
	public int HP;
	public string nome;
	public List<string> classe; //bárbaro, mago...
	public Dictionary<string, string> atributos;	
	
}
```

Agora que já vimos nossa classe personagem, vamos construir nossa interface responsável por produzir tipos específicos de personagens.

```cs
public interface IBuilder
{
	void BuildMago(string _nome);
	
	void BuildBarbaro(string _nome);
	
	void BuildLandino(string _nome);
}
```


Agora podemos implementar o nosso ``IBuilder``. 

```cs 
public class Builder : IBuilder
{
	private Personagem _personagem = new Personagem();
	
	public void BuildMago() 
	{
		_personagem.classe.Add("Mago"); 
		atributos.Add("AtaqueMagico", "20");
		atributos.Add("DanoMagico", "5");
		
	}
	
	public void BuildBarbaro()
	{		
		_personagem.classe.Add("Barbaro");
		atributos.Add("AtaqueFisico", "20");
		atributos.Add("DanoFisico", "10");
	}
	
	public void BuildLandino()
	{
		_personagem.classe.Add("Landino");
		atributos.Add("AtaqueFurtivo", "20");
		atributos.Add("DanoFurtivo", "2");
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
```

Nesse ponto já poderíamos usar o builder para criar os nossos personagens, mas podemos também usar uma classe "Diretor", que no nosso caso será a classe Mestre. É dela (classe Mestre) o trabalho de realizar os passos necessários para que combinemos nossos Build de cada personagem, agregando propriedade e comportamentos.

```cs
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
```



Vamos ver como usaríamos estas classes?! 

```cs 

Console.WriteLine("Utilizando o Mestre ");

Console.WriteLine(mestre.BuildMagoBarbaro("Nicolas", 15).ToString());

Console.WriteLine(mestre.BuildMagoLandino("Maria Eduarda", 7).ToString());

  

Console.WriteLine("Utilizando o Builder ");

builder.BuildLandino();

Console.WriteLine(builder.GetPersonagem("Judith", 10));

```


Note que no último exemplo estou usando diretamente o Builder para construir um objeto simples

Olhando a implementação, já entendemos que podemos padronizar o objeto principal com diversas funcionalidades. Neste exemplo foquei nas propriedades (por ser mais fácil de implementar) mas poderíamos ter funções sendo implementadas de jeitos diferentes para cada objeto. Nosso personagem Mago poderia atacar com uma bola de fogo, nosso bárbaro ao atacar usaria uma clava, mas todos continuarão sendo Personagens do nosso RPG.



## Materiais de Estudo

Estamos chegando ao fim do nosso artigo e queria deixar alguns materiais que usei para estudar esse padrão de software: 

[Refactoring Guru](https://refactoring.guru/pt-br/design-patterns/builder)

[Dofactory](https://www.dofactory.com/net/builder-design-pattern)

