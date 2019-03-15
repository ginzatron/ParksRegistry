using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// returns list of parks
        /// </summary>
        /// <returns></returns>
        IList<Park> GetAllParks();

        /// <summary>
        /// gets individual park from four letter park code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Park GetParkByCode(string code);
    }
}
