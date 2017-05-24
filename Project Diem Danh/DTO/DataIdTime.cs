using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Diem_Danh.DTO
{
    public class DataIdTime
    {
        private String id = String.Empty;

        public String ID
        {
            get { return id; }
             set { id = value; }
        }

        String timecurent = String.Empty;

        public String Timecurent
        {
            get { return timecurent; }
             set { timecurent = value; }
        }

        public DataIdTime()
        {

        }
        public DataIdTime(String id, String time)
        {
            this.ID = id;
            this.Timecurent = time;
        }
    }
}
