using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik.Core.Services
{
    public interface IDatabaseService
    {
        SQLiteConnection Connection { get; } // implementacja po stronie platformowej 
    }
}
