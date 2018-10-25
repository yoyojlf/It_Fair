using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class TipoPalabra
    {
        public string ID_TipoPalabra { get; set; }
        public string Descripcion { get; set; }


        public TipoPalabra()
        {
            Init();
        }

        private void Init()
        {
            ID_TipoPalabra = string.Empty;
            Descripcion = string.Empty;
        }

        #region Metodos
        public bool Read()
        {
            Datos.IT_FairEntities Contexto = new Datos.IT_FairEntities();



            try
            {

                Datos.TipoPalabra tipoPalabra = Contexto.TipoPalabra.First(a => a.ID_TipoPalabra == ID_TipoPalabra);
                CommonBC.Syncronize(tipoPalabra, this);


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //read all
        public List<TipoPalabra> ReadAll()
        {
            Datos.IT_FairEntities Contexto = new Datos.IT_FairEntities();
            try
            {
                List<Datos.TipoPalabra> ListaTipoBD = Contexto.TipoPalabra.ToList<Datos.TipoPalabra>();
                //Lista salida
                List<TipoPalabra> ListaTipoBB = GenerarListaSexos(ListaTipoBD);

                return ListaTipoBB;
            }
            catch (Exception ex)
            {
                return new List<TipoPalabra>();
            }
        }

        private List<TipoPalabra> GenerarListaSexos(List<Datos.TipoPalabra> listaTipoBD)
        {
            List<TipoPalabra> ListaBB = new List<TipoPalabra>();

            foreach (Datos.TipoPalabra Datos in listaTipoBD)
            {
                TipoPalabra Tipo = new TipoPalabra();
                CommonBC.Syncronize(Datos, Tipo);
                ListaBB.Add(Tipo);
            }

            return ListaBB;
        }

        #endregion


    }
}
