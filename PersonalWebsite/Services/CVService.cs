namespace PersonalWebsite.Services
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class CVService : ICVService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CVService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public T GetFirstOrDefault<T>()
        {
            var cv = _dbContext.CVs.FirstOrDefault();
            return _mapper.Map<T>(cv);
        }
    }
}