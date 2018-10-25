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


        
    }
}
