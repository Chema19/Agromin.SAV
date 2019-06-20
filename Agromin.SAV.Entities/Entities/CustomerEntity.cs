using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agromin.SAV.Entities.Entities
{
    public class CustomerEntity
    {
        public Int32? CustomerId { set; get; }
        public String Names { set; get; }
        public String LastNames { set; get; }
        public String Credential { set; get; }
        public String Password { set; get; }
        public String Sex { set; get; }
        public String Identity_Document { set; get; }
        public String Email { set; get; }
        public DateTime? Birthdate { set; get; }
        public String Phone { set; get; }
        public Int32? DepartmentId { set; get; }
        public Int32? ProvinceId { set; get; }
        public Int32? DistrictId { set; get; }
        public Int32 LocalId { set; get; }
    }
}
