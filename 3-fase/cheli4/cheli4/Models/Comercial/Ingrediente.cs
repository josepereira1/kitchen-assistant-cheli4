namespace cheli4.Models.Comercial
{
    public class Ingrediente
    {
        int id;
        string nome;
        string tipo;
        int calorias;

        public Ingrediente()
        {
            this.id = -1;
            this.nome = "nenhum";
            this.tipo = "t";
            this.calorias = 0;
        }
        public Ingrediente(int i,string n,string t,int c)
        {
            this.id = i;
            this.nome = n;
            this.tipo = t;
            this.calorias = c;
        }
        public Ingrediente(Ingrediente i)
        {
            this.id = i.id;
            this.nome = i.nome;
            this.tipo = i.tipo;
            this.calorias = i.calorias;
        }


        public override bool Equals(object o)
        {
            if ((o == null) || !this.GetType().Equals(o.GetType())) return false;
            Ingrediente i = (Ingrediente) o;
            return (id == i.id) && (nome == i.nome) && (tipo == i.tipo) && (calorias == i.calorias);
        }

        public override string ToString()
        {
            return System.String.Format("Ingrediente: {0},{1},{2},{3}",id,nome,tipo,calorias);
        }

    }
}
