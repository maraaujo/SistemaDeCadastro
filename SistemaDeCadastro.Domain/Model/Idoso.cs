﻿using SistemaDeCadastro.Domain.Model;


namespace SistemaDeCadastroIdososDomain.Model
{
    public class Idoso
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set;}
        public ICollection<Familia> Familias { get; set; }

        public ICollection<MedicamentoIdosoDoenca> MedicamentoIdosoDoencas { get; set; }
        public ICollection<IdosoDoenca> IdosoDoencas { get; set; }
        public ICollection<IdosoFuncionario> Funcionarios { get; set; }
        

    }
}