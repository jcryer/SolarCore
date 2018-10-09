using SolarForms.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms
{
    class LineObject
    {
        public SolarObject Obj;
        public DateTime DelBy;

        public LineObject(SolarObject obj, DateTime delby)
        {
            Obj = obj;
            DelBy = delby;
        }
        public bool Delete()
        {
            if (DelBy < DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
