namespace PersonalWebsite.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Repositories;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Data.CVModels;
    using Models.InputModels;

    public class CVService : ICVService
    {
        private readonly IRepository<CV> _cvsRepository;
        private readonly IMapper _mapper;
        private readonly IFileManagementService _fileManagementService;

        public CVService(IRepository<CV> cvsRepository, IMapper mapper, IFileManagementService fileManagementService)
        {
            _cvsRepository = cvsRepository;
            _mapper = mapper;
            _fileManagementService = fileManagementService;
        }
        
        public T GetFirstOrDefault<T>()
        {
            var cv = _cvsRepository.All().FirstOrDefault();
            return _mapper.Map<T>(cv);
        }

        public int GetId()
        {
            var cv = _cvsRepository.All().FirstOrDefault();
            return cv?.Id ?? 1;
        }

        public async Task Edit(CVModifyInputModel modifiedModel)
        {
            var cv = _cvsRepository.All().FirstOrDefault();
            if (cv != null)
            {
                cv.Name = modifiedModel.Name;
                cv.Position = modifiedModel.Position;
                cv.ShortPresentation = modifiedModel.ShortPresentation;
                cv.Phone = modifiedModel.Phone;
                cv.Email = modifiedModel.Email;
                cv.Location = modifiedModel.Location;

                if (modifiedModel.NewCVPicture != null)
                {
                    var fileName = modifiedModel.NewCVPicture.FileName;
                    var uniqueFileName = Guid.NewGuid() + fileName;

                    await _fileManagementService.SaveImageAsync("profilePictures", uniqueFileName, modifiedModel.NewCVPicture);
                    cv.ProfileImageFileName = uniqueFileName;
                }
                
                _cvsRepository.Update(cv);
                await _cvsRepository.SaveChangesAsync();
            }
        }
    }
}