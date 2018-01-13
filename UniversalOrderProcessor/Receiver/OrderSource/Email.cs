using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSource
{
    /// <summary>
    /// Order source is email
    /// </summary>
    public class Email : IMovable
    {
        public void Move()
        {
            //Todo: Read email folder and write the contents to a DB
        }
    }
}
