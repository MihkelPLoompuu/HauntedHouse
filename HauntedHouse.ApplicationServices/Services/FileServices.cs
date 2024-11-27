using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly HauntedHouseContext _context;

        public FileServices
            (
                IHostEnvironment webHost,
                HauntedHouseContext context
            )
        {
            _webHost = webHost;
            _context = context;
        }
        public void UploadFilesToDatabase(HunterDto dto, Hunter domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            HunterID = domain.ID
                        };

                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FileToDatabase.Add(files);

                    }
                }
            }
        }

        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var imageID = await _context.FileToDatabase
                .FirstOrDefaultAsync(x => x.ID == dto.ID);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imageID.ImageData;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FileToDatabase.Remove(imageID);
            await _context.SaveChangesAsync();

            return null;

        }
    }
}
