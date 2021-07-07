using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskDAL
{
    public interface IAddressRepository
    {
        Task<IEnumerable<DTO_DropDown>> GetCity(int id);

        Task<IEnumerable<DTO_DropDown>> GetState(int id);

        Task<IEnumerable<DTO_DropDown>> GetCountry();
    }
}
