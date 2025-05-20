using System;
using System.Collections.Generic;
using System.Linq;
using VetClinicManagement.Models;

namespace VetClinicManagement.Data
{
    public static class SeedData
    {
        public static void Initialize(VetClinicContext context)
        {
            if (context.Animals.Any() || context.Veterinarios.Any() || context.Procedimentos.Any() || context.Atendimentos.Any())
            {
                // Dados já existem
                return;
            }

            var animais = new List<Animal>
            {
                new Animal { Nome = "Toby", Especie = "Cachorro", Raca = "Labrador", Idade = 5, Proprietario = "Ana" },
                new Animal { Nome = "Miau", Especie = "Gato", Raca = "Siames", Idade = 3, Proprietario = "Carlos" },
                new Animal { Nome = "Nina", Especie = "Cachorro", Raca = "Poodle", Idade = 2, Proprietario = "Fernanda" }
            };

            context.Animals.AddRange(animais);

            var veterinarios = new List<Veterinario>
            {
                new Veterinario { Nome = "Dr. João", Especialidade = "Cirurgia", Telefone = "1111-2222" },
                new Veterinario { Nome = "Dra. Maria", Especialidade = "Dermatologia", Telefone = "3333-4444" }
            };
            context.Veterinarios.AddRange(veterinarios);

            var procedimentos = new List<Procedimento>
            {
                new Procedimento { Nome = "Vacinação", Descricao = "Vacina antirrábica" },
                new Procedimento { Nome = "Consulta Geral", Descricao = "Consulta de rotina" },
                new Procedimento { Nome = "Cirurgia", Descricao = "Procedimento cirúrgico" }
            };
            context.Procedimentos.AddRange(procedimentos);

            context.SaveChanges();

            var atendimentos = new List<Atendimento>
            {
                new Atendimento
                {
                    AnimalId = animais[0].Id,
                    VeterinarioId = veterinarios[0].Id,
                    DataAtendimento = DateTime.Now.AddDays(-10),
                    AtendimentoProcedimentos = new List<AtendimentoProcedimento>
                    {
                        new AtendimentoProcedimento { ProcedimentoId = procedimentos[2].Id }
                    }
                },
                new Atendimento
                {
                    AnimalId = animais[1].Id,
                    VeterinarioId = veterinarios[1].Id,
                    DataAtendimento = DateTime.Now.AddDays(-5),
                    AtendimentoProcedimentos = new List<AtendimentoProcedimento>
                    {
                        new AtendimentoProcedimento { ProcedimentoId = procedimentos[0].Id },
                        new AtendimentoProcedimento { ProcedimentoId = procedimentos[1].Id }
                    }
                }
            };
            context.Atendimentos.AddRange(atendimentos);

            context.SaveChanges();
        }
    }
}
