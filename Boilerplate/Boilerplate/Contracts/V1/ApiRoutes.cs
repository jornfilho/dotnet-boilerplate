namespace Boilerplate.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Tests
        {
            private const string ThisBase = Base + "/tests";
            
            public const string GetAll = ThisBase;

            public const string Update = ThisBase + "/{testId}";

            public const string Delete = ThisBase + "/{testId}";

            public const string Get = ThisBase + "/{testId}";

            public const string Create = ThisBase;
        }
        
        public static class TestsMsSql
        {
            private const string ThisBase = Base + "/tests_mssql";
            
            public const string GetAll = ThisBase;

            public const string Update = ThisBase + "/{testId}";

            public const string Delete = ThisBase + "/{testId}";

            public const string Get = ThisBase + "/{testId}";

            public const string Create = ThisBase;
        }
        
        public static class TestsMySql
        {
            private const string ThisBase = Base + "/tests_mysql";
            
            public const string GetAll = ThisBase;

            public const string Update = ThisBase + "/{testId}";

            public const string Delete = ThisBase + "/{testId}";

            public const string Get = ThisBase + "/{testId}";

            public const string Create = ThisBase;
        }
    }
}