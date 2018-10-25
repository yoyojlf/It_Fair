using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class Palabra
    {

        #region atributos
        public string ID_Palabra { get; set; }
        public string Palabra1 { get; set; }
        public byte[] Imagen { get; set; }
        public string Traduccion { get; set; }
        public string Sinonimo { get; set; }
        public string Antonimo { get; set; }
        public string Ejemplo { get; set; }
        public string ID_TipoPalabra { get; set; }

        #endregion

        #region Constructor

        public Palabra()
        {
            Init();
        }

        private void Init()
        {
            ID_Palabra = string.Empty;
            Palabra1 = string.Empty;
            Imagen = null;
            Traduccion = string.Empty;
            Sinonimo = string.Empty;
            Antonimo = string.Empty;
            Ejemplo = string.Empty;
            ID_TipoPalabra = string.Empty;

        }

        #endregion

        #region CRUD

        public bool Read()
        {
            Datos.IT_FairEntities Contexto = new Datos.IT_FairEntities();

            try
            {
                Datos.Palabra palabra = Contexto.Palabra.First(b => b.ID_Palabra == ID_Palabra);
                CommonBC.Syncronize(palabra, this);


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool Create()
        {
            Datos.IT_FairEntities Contexto = new Datos.IT_FairEntities();
            Datos.Palabra palabra = new Datos.Palabra();



            try
            {
                CommonBC.Syncronize(this, palabra);
                Contexto.Palabra.Add(palabra);
                Contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete()
        {
            Datos.IT_FairEntities Contexto = new Datos.IT_FairEntities();
            try
            {
                Datos.Palabra palabra = Contexto.Palabra.First(a => a.ID_Palabra == ID_Palabra);
                Contexto.Palabra.Remove(palabra);
                Contexto.SaveChanges();

                return true;




            }
            catch
            {
                return false;
            }
        }

        

        public bool Update()
        {

            Datos.IT_FairEntities Contexto = new Datos.IT_FairEntities();



            try
            {

                Datos.Palabra palabra = Contexto.Palabra.First(a => a.ID_Palabra == ID_Palabra);
                CommonBC.Syncronize(this, palabra);

                Contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region READ'S
        public List<Palabra> ReadAll()
        {
            Datos.IT_FairEntities Contexto = new Datos.IT_FairEntities();

            try
            {
                List<Datos.Palabra> ListaBD = Contexto.Palabra.ToList();

                List<Palabra> listaPalabra = new List<Palabra>();





                foreach (Datos.Palabra datos in ListaBD)
                {
                    Palabra palabra = new Palabra();
                    CommonBC.Syncronize(datos, palabra);
                    listaPalabra.Add(palabra);
                }

                return listaPalabra;
            }
            catch (Exception)
            {
                return new List<Palabra>();
            }
        }

        #endregion

    }
}
