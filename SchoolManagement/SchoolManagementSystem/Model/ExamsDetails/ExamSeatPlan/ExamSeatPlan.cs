using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ExamSeatPlan
    {
        public int Id { set; get; }
        public int RoomId { set; get; }
        public int ExamRoutineId { set; get; }
        public int TeacherId { set; get; }
        //public virtual Room Room { set; get; }  //collection dya hoy ni
        //public virtual Teacher Teacher { set; get; }//collection dya hoy ni
        //public virtual ExamRoutine ExamRoutine { set; get; } //collection dya hoy ni
    }
}
