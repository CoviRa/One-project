using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL3
{
    using System;
    using System.Collections.Generic;
    //Создание и инициализация обьектов
    public partial class STUDENT
    {

        public int STUDENT_ID { get; set; }
        public string SURNAME { get; set; }
        public string NAME { get; set; }
        public Nullable<int> STIPEND { get; set; }
        public Nullable<int> KURS { get; set; }
        public string CITY { get; set; }
        public Nullable<System.DateTime> BIRTHDAY { get; set; }
        public int UNIV_ID { get; set; }
        public string UNIV_NAME { get; set; }
    }
}
