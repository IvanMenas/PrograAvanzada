using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ent_Semana3.Database;
using Ent_Semana3.Entities;

namespace Ent_Semana3.Models
{
    public class TipoCambioModel
    {
        public void Insert(TipoCambio objParam)
        {
            using (var contex = new LN_DBEntities())
            {
                try
                {
                    T_TIPOCAMBIO tipoCambio = new T_TIPOCAMBIO();

                    tipoCambio.COD_INDICADORINTERNO = objParam.CODINDICADORINTERNO;
                    tipoCambio.DES_FECHA = objParam.DESFECHA;
                    tipoCambio.NUM_VALOR = objParam.NUMVALOR;

                    contex.T_TIPOCAMBIO.Add(tipoCambio);
                    contex.SaveChanges();
                    contex.Dispose();
                }
                catch (Exception ex)
                {
                    contex.Dispose();
                    throw ex;
                }
            }
        }

        

    }
}