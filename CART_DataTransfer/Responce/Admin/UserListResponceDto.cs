using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Responce.Admin
{
    public class UserListResponceDto
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public IList<UserResponceDto> UserList_res
        {
            get;
            set;
        }
        public int RecordCount { get; set; }
    }
}
