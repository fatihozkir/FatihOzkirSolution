using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatihOzkirSolutions.DataAccess.Concrete.EntityFramework
{
    public class ContextSingleton
    {
        //I applied Singleton Design Pattern for Creating Database Context object
        private static ProjectContext _context;
        private static object _obj=new object();
        private ContextSingleton()
        {
            
        }

        public static ProjectContext CreateContext()
        {
            if (_context==null)
            {
                lock (_obj)
                {
                    if (_context==null)
                    {
                        _context=new ProjectContext();
                    }
                }
            }
            return _context;
        }
    }
}
