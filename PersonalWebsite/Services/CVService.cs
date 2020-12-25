namespace PersonalWebsite.Services
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data;
    using Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Models.Data.CVModels;

    public class CVService : ICVService
    {
        private readonly IRepository<CV> _cvsRepository;
        private readonly IMapper _mapper;

        public CVService(IRepository<CV> cvsRepository, IMapper mapper)
        {
            _cvsRepository = cvsRepository;
            _mapper = mapper;
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
    }
}