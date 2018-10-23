using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Negocio
{
    public class TipoPalabra
    {
        public string ID_TipoPalabra { get; set; }
        public string Descripcion { get; set; }
        public bool Read()
        {
            AccesoDatos.IT_FairEntities Contexto = new IT_FairEntities();
            try
            {
                AccesoDatos.TipoPalabra tipoPalabra = Contexto.TipoPalabra.First(t => t.ID_TipoPalabra == ID_TipoPalabra);
                CommonBC.Syncronize(tipoPalabra, this);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<TipoPalabra> ReadAll()
        {
            AccesoDatos.IT_FairEntities Contexto = new IT_FairEntities();
            try
            {
                List<AccesoDatos.TipoPalabra> ListaBD = Contexto.TipoPalabra.ToList<TipoPalabra>();
                //Lista Salida
                List<EstadoCivil> ListaBiblioteca = GenerarListaEstados(Contexto.TipoPalabra.ToList<TipoPalabra>());

                return ListaBiblioteca;
            }
            catch (Exception ex)
            {
                return new List<EstadoCivil>();
            }
        }

        private List<EstadoCivil> GenerarListaEstados(List<AccesoDato.EstadoCivil> listaBD)
        {
            List<EstadoCivil> ListaEstados = new List<EstadoCivil>();

            foreach (AccesoDato.EstadoCivil Datos in listaBD)
            {
                EstadoCivil estado = new EstadoCivil();
                CommonBC.Syncronize(Datos, estado);
                ListaEstados.Add(estado);
            }

            return ListaEstados;
        }

    }
}
