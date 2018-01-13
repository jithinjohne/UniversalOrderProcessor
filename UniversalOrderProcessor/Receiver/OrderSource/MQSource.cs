using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSource
{
    /// <summary>
    /// Order coming through MQ queue
    /// </summary>
    public class MQSource : IMovable
    {
        public void Move()
        {
            // Todo: Read MQ queue and write data to a DB
        }
    }
}
