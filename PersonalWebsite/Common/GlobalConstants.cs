namespace PersonalWebsite.Common
{
    public static class GlobalConstants
    {
        /// <summary>
        /// If role is changed here, it has to manually be changed in the Authorize attributes if it's used
        /// </summary>
        public const string AdministratorRoleName = "Administrator";
        
        public const string DefaultUserRoleName = "User";
    }
}