using Project_EF_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Interfaces
{
    public interface ISetting
    {
        Task<IEnumerable<Setting>> GetAllSettingsAsync();
        Task<Setting> GetSettingAsync(int id);
        Task AddSettingAsync(Setting setting);
        Task DeleteSettingAsync(Setting setting);
        Task EditSettingAsync(Setting setting);
        Task <IEnumerable<Setting>> GetSettingByEmailAsync(string email);
    }
}
