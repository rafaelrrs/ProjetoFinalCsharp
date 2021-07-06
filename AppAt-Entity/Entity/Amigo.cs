using System;
using System.Collections.Generic;

namespace AppAt_Entity
{
    public class Amigo
    {
        public Amigo()
        {
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Aniversario { get; set; }
		public void AniversariosDeHoje(List<Amigo> amigos)
		{
			List<Amigo> aniversariantesDoDia = new List<Amigo>();
			DateTime hoje = DateTime.Today;
			foreach (var amigo in amigos)
			{
				if (amigo.Aniversario.Day.Equals(hoje.Day) && amigo.Aniversario.Month.Equals(hoje.Month))
				{
					aniversariantesDoDia.Add(amigo);
				}
			}
			foreach (var deHoje in aniversariantesDoDia)
				Console.WriteLine($"Parabéns {deHoje.Nome} {deHoje.Sobrenome}");
		}

		public int ContagemAniversario(DateTime Aniversario)
		{
			var diasQuefaltam = Aniversario.AddYears(DateTime.Today.Year - Aniversario.Year);

			if (diasQuefaltam < DateTime.Today)
			{
				diasQuefaltam = diasQuefaltam.AddYears(1);
			}

			return (diasQuefaltam - DateTime.Today).Days;
		}
	}
}
