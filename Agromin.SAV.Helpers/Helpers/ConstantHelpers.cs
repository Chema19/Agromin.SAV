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
                }
                return string.Empty;
            }
        }
    }
}
