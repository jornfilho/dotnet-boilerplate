namespace Boilerplate.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Tests
        {
            public const string GetAll = Base + "/tests";

            public const string Update = Base + "/tests/{testId}";

            public const string Delete = Base + "/tests/{testId}";

            public const string Get = Base + "/tests/{testId}";

            public const string Create = Base + "/tests";
        }
    }
}