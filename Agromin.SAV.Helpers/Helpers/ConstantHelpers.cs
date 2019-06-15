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


            public static string GetNameEstado(string Estado)
            {
                switch (Estado)
                {
                    case ACTIVO:
                        return "ACTIVO";
                    case INACTIVO:
                        return "INACTIVO";
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
                }
                return string.Empty;
            }
        }
    }
}
