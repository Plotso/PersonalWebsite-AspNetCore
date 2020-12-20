namespace PersonalWebsite.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.ViewModels.Home;

    public static class ViewModelExtensions
    {
        public static Dictionary<string, IEnumerable<string>> GroupSkillsByType(this IEnumerable<SkillViewModel> skillViewModels)
        {
            var result = new Dictionary<string, IEnumerable<string>>();
            var skillsByType = skillViewModels.GroupBy(s => s.Type);
            foreach (var skillTypeGroup in skillsByType)
            {
                var skills = skillTypeGroup.Select(s => s.Name);
                result.Add(skillTypeGroup.Key, skills);
            }

            return result;
        }
    }
}