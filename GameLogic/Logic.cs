using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
namespace GameLogic
{
    public class Logic
    {
        Random Random = new Random();
        int[] valor, nUsuario;
        List<int> lista;
        public string cargar() 
        {
            lista = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            int elementosEnLista = lista.Count();
            valor = new int[4];
            for (int i = 0; i < valor.Length; i++) 
            {
                int indice = Random.Next(0, elementosEnLista);
                valor[i] = lista[indice];
                elementosEnLista--;
                lista.RemoveAt(indice);
            }
            string txt = string.Join("", valor);
            return txt;
        }


        public void verificar(string cifras, ref int aci, ref int pos)
        {
            nUsuario = cifras.Select(x => int.Parse(x.ToString())).ToArray();
            for (int i = 0; i < valor.Length; i++)
            {
                for (int j = 0; j < nUsuario.Length; j++)
                {
                    if (valor[i] == nUsuario[j])
                    {
                        aci++;
                        if (i == j)
                        {
                            pos++;                            
                        }
                    }
                }

            }
        }


    }
}
