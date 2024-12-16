using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(HunterDto dto, Hunter domain);
        void UploadFilesToDatabase(RoomDto dto, Room domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
    }
}
