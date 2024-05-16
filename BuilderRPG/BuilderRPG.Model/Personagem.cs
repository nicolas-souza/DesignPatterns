using System.Text;

namespace DesignPatterns.BuilderRPG;

public class Personagem
{
    public int HP;
	public string nome = string.Empty;
	public List<string> classe = [];
	public Dictionary<string, string> atributos = [];

	override public string ToString()
	{
		StringBuilder result = new StringBuilder();
		result.AppendLine($"Nome: {this.nome} HP: {this.HP}");

		String classeResult = "Classe: ";
		foreach (var item in this.classe)
		{
			classeResult+=item.ToString() + " ";
		}
		result.AppendLine(classeResult);

		result.AppendLine("Atributos: ");

		foreach (var item in this.atributos)
		{
			result.AppendLine("\t -" + item.Key.ToString() + ": " + item.Value.ToString());
		}

		return result.ToString();
	}
}
