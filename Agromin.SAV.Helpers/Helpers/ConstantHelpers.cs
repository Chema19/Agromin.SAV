using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agromin.SAV.Helpers.Helpers
{
    public static class ConstantHelpers
    {

        public static class ESTADO
        {
            public const string ACTIVO = "ACT";
            public const string INACTIVO = "INA";
            public const string ENTRADA = "ENT";
            public const string SALIDA = "SAL";
            public const string PREVENTA = "PRE";
            public const string NOENTREGADO = "NOE";
            public const string CANCELADO = "CAN";
            public const string ENTREGADO = "ETG";

            public static string GetNameEstado(string Estado)
            {
                switch (Estado)
                {
                    case ACTIVO:
                        return "ACTIVO";
                    case INACTIVO:
                        return "INACTIVO";
                    case ENTRADA:
                        return "ENTRADA";
                    case SALIDA:
                        return "SALIDA";
                    case PREVENTA:
                        return "PREVENTA";
                    case NOENTREGADO:
                        return "NOENTREGADO";
                    case CANCELADO:
                        return "CANCELADO";
                    case ENTREGADO:
                        return "ENTREGADO";
                }

                return string.Empty;
            }
            public static string GetLabelEstado(string Estado)
            {
                switch (Estado)
                {
                    case ACTIVO:
                        return "<label class='badge badge-success'>ACTIVO</label>";
                    case INACTIVO:
                        return "<label class='badge badge-danger'>INACTIVO</label>";
                    case ENTRADA:
                        return "<label class='badge badge-primary'>ENTRADA</label>";
                    case SALIDA:
                        return "<label class='badge badge-primary'>SALIDA</label>";
                    case PREVENTA:
                        return "<label class='badge badge-primary'>PREVENTA</label>";
                    case NOENTREGADO:
                        return "<label class='badge badge-primary'>NO ENTREGADO</label>";
                    case CANCELADO:
                        return "<label class='badge badge-primary'>CANCELADO</label>";
                    case ENTREGADO:
                        return "<label class='badge badge-primary'>ENTREGADO</label>";
                }
                return string.Empty;
            }
        }
    }
}
