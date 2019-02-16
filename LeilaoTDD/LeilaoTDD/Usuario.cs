﻿namespace LeilaoTDD
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Usuario(string nome) : this(0, nome)
        {

        }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
