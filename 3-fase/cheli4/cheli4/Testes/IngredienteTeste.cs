using System;
using cheli4.Models.Comercial;

namespace cheli4.Testes
{
    public class IngredienteTeste
    {
        public void MainIngredienteTeste()
        {
            Ingrediente i = new Ingrediente();
            Ingrediente i2 = new Ingrediente();
            string s = i2.ToString();
            Console.WriteLine(s + " + " + i.Equals(i2));
        }
    }
}
