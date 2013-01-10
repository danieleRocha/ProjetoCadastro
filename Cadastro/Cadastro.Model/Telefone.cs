using System;
using System.Globalization;

namespace Cadastro.Model
{
    public class Telefone
    {
        public Guid IdPessoa { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }

        public string IdTelefone
        {
            get
            {
                return DDD.ToString(CultureInfo.InvariantCulture) + Numero.ToString(CultureInfo.InvariantCulture);
            }
        }

        public Telefone(Guid IdPessoa, int DDD, int Numero)
        {
            this.IdPessoa = IdPessoa;
            this.DDD = DDD;
            this.Numero = Numero;
        }
    }
}