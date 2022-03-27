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
            using (var contex = new LN_DBEntities1())
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

        public void InsertXML(String xml, int indicador)
        {
            using (var contex = new LN_DBEntities1())
            {
                try
                {
                    contex.InsertTipoCambio(xml, indicador);
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

        public List<TipoCambio> getTipoCambioVenta_1DayByMonth()
        {
            List<TipoCambio> resultado = new List<TipoCambio>();
            using (var contex = new LN_DBEntities1())
            {
                try
                {
                    var datos = contex.get_CV_on_1Day_byMonth();

                    foreach (var item in datos.ToList())
                    {
                        resultado.Add(new TipoCambio
                        {
                            CODINDICADORINTERNO = item.COD_INDICADORINTERNO,
                            DESFECHA = item.DES_FECHA,
                            NUMVALOR = item.NUM_VALOR,

                        });
                    }

                    contex.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    contex.Dispose();
                    throw ex;
                }
            }
        }

        public List<TipoCambio> getTipoCambioVenta_15DayByMonth()
        {
            List<TipoCambio> resultado = new List<TipoCambio>();
            using (var contex = new LN_DBEntities1())
            {
                try
                {
                    var datos = contex.get_CV_on_15Day_byMonth();

                    foreach (var item in datos.ToList())
                    {
                        resultado.Add(new TipoCambio
                        {
                            CODINDICADORINTERNO = item.COD_INDICADORINTERNO,
                            DESFECHA = item.DES_FECHA,
                            NUMVALOR = item.NUM_VALOR,

                        });
                    }

                    contex.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    contex.Dispose();
                    throw ex;
                }
            }
        }

        public List<TipoCambio> getTipoCambioVenta_LastDayByMonth()
        {
            List<TipoCambio> resultado = new List<TipoCambio>();
            using (var contex = new LN_DBEntities1())
            {
                try
                {
                    var datos = contex.get_CV_on_LastDay_byMonth();

                    foreach (var item in datos.ToList())
                    {
                        resultado.Add(new TipoCambio
                        {
                            CODINDICADORINTERNO = item.COD_INDICADORINTERNO,
                            DESFECHA = item.DES_FECHA,
                            NUMVALOR = item.NUM_VALOR,

                        });
                    }

                    contex.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    contex.Dispose();
                    throw ex;
                }
            }
        }


        public List<Avg_ByMonth> getAvg_LastAndCurrentMonth()
        {
            List<Avg_ByMonth> resultado = new List<Avg_ByMonth>();
            using (var contex = new LN_DBEntities1())
            {
                try
                {
                    var datos = contex.getAvg_LastAndCurrentMonth();

                    foreach (var item in datos.ToList())
                    {
                        resultado.Add(new Avg_ByMonth
                        {
                            Mes = "",
                            AvgVenta = 0,
                            AvgCompra = 0

                        });
                        ;
                    }

                    contex.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    contex.Dispose();
                    throw ex;
                }
            }
        }


        public Data_ByDiff getData_ByDiff()
        {
            using (var contex = new LN_DBEntities1())
            {
                try
                {
                    var datos = contex.getData_ByDiff();
                    Data_ByDiff data_ByDiff = new Data_ByDiff();
                    foreach (var item in datos.ToList())
                    {
                        data_ByDiff.Min = (decimal)item.maximo;
                        data_ByDiff.Max = (decimal)item.minimo;
                        data_ByDiff.Avg = (decimal)item.promedio;
                    }

                    contex.Dispose();
                    return data_ByDiff;
                }
                catch (Exception ex)
                {
                    contex.Dispose();
                    throw ex;
                }
            }
        }


        public decimal get_CV_3HighestValue()
        {
            using (var contex = new LN_DBEntities1())
            {
                try
                {
                   decimal HighestValue = 0;
                    var datos = contex.get_CV_3HighestValue();
                    foreach (var item in datos.ToList())
                    {
                        HighestValue = (decimal)item;
                    }
                    contex.Dispose();

                    return HighestValue;
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