using Microsoft.EntityFrameworkCore;
using Project_EF_Core.Data;
using Project_EF_Core.Helpers;
using Project_EF_Core.Interfaces;
using Project_EF_Core.Models;
using Project_EF_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Repository
{
    public class SettingRepository : ISetting
    {
        public async Task AddSettingAsync(Setting setting)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                await context.Settings.AddAsync(setting);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteSettingAsync(Setting setting)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Settings.Remove(setting);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditSettingAsync(Setting setting)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Settings.Update(setting);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Setting> GetSettingAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Settings.FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<Setting>> GetAllSettingsAsync()
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Settings.ToListAsync();
            }
        }

        public async Task<IEnumerable<Setting>> GetSettingByEmailAsync(string email)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Settings.Where(e => e.Email.Contains(email)).ToListAsync();
            }
        }
        
    }
}
