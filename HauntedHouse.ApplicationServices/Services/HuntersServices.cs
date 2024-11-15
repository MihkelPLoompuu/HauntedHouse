using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.ApplicationServices.Services
{
    public class HuntersServices : IHuntersServices
    {
        private readonly HunterContext _context;
        private readonly IFileServices _fileServices;

        public HuntersServices(HunterContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Hunter> DetailsAsync(Guid id)
        {
            var result = await _context.Hunters
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
        public async Task<Hunter> Create(HunterDto dto)
        {
            Hunter hunter = new Hunter();

            hunter.ID = Guid.NewGuid();
            hunter.HunterHealth = 100;
            hunter.HunterXP = 0;
            hunter.HunterXPNextLevel = 100;
            hunter.HunterLevel = 0;
            hunter.HunterStatus = Core.Domain.HunterStatus.Alive;

            //set by user
            hunter.HunterName = dto.HunterName;
            hunter.PrimaryAttackName = dto.PrimaryAttackName;
            hunter.PrimaryAttackPower = dto.PrimaryAttackPower;
            hunter.SecondaryAttackName = dto.SecondaryAttackName;
            hunter.SecondaryAttackPower = dto.SecondaryAttackPower;
            hunter.SpecialAttackName = dto.SpecialAttackName;
            hunter.SpecialAttackPower = dto.SpecialAttackPower;

            //set for db
            hunter.CreatedAt = DateTime.Now;
            hunter.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, hunter);
            }

            await _context.Hunters.AddAsync(hunter);
            await _context.SaveChangesAsync();

            return hunter;
        }

        public async Task<Hunter> Update(HunterDto dto)
        {
            Hunter hunter = new Hunter();

            // set by service
            hunter.ID = dto.ID;
            hunter.HunterHealth = dto.HunterHealth;
            hunter.HunterXP = dto.HunterXP;
            hunter.HunterXPNextLevel = dto.HunterXPNextLevel;
            hunter.HunterLevel = dto.HunterLevel;
            hunter.HunterStatus = (Core.Domain.HunterStatus)dto.HunterStatus;

            //set by user
            hunter.HunterName = dto.HunterName;
            hunter.PrimaryAttackName = dto.PrimaryAttackName;
            hunter.PrimaryAttackPower = dto.PrimaryAttackPower;
            hunter.SecondaryAttackName = dto.SecondaryAttackName;
            hunter.SecondaryAttackPower = dto.SecondaryAttackPower;
            hunter.SpecialAttackName = dto.SpecialAttackName;
            hunter.SpecialAttackPower = dto.SpecialAttackPower;

            //set for db
            hunter.CreatedAt = dto.CreatedAt;
            hunter.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, hunter);
            }
            _context.Hunters.Update(hunter);
            await _context.SaveChangesAsync();

            return hunter;
        }

        public async Task<Hunter> Delete(Guid id)
        {
            var result = await _context.Hunters
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Hunters.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
