using System.Reflection.PortableExecutable;

namespace ApiHandler.DTO
{
    public class Entity
    {
    }

    public class ExternalApi
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string BaseUrl { get; set; } = string.Empty;

        public string Endpoint { get; set; } = string.Empty;

        public HttpMethodType Method { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public string ContentType { get; set; } = "application/json";

        public int TimeoutInSeconds { get; set; } = 60;

        public bool IsActive { get; set; }

        public ICollection<ApiHeader> Headers { get; set; } = new List<ApiHeader>();

        public ICollection<RequestParameter> RequestParameters { get; set; } = new List<RequestParameter>();

        public ICollection<ResponseParameter> ResponseParameters { get; set; } = new List<ResponseParameter>();
    }

    public enum AuthenticationType
    {
        None = 0,
        ApiKey = 1,
        BearerToken = 2,
        Basic = 3,
        OAuth2ClientCredential = 4
    }

    public enum HttpMethodType
    {
        GET,
        POST,
        PUT,
        DELETE,
        PATCH
    }

    public enum ParameterDataType
    {
        String,
        Integer,
        Decimal,
        Boolean,
        DateTime,
        Array,
        Object
    }

    public class ApiHeader
    {
        public Guid Id { get; set; }

        public Guid ExternalApiId { get; set; }

        public string HeaderName { get; set; } = string.Empty;

        public string HeaderValue { get; set; } = string.Empty;

        public bool IsSecret { get; set; }

        public ExternalApi ExternalApi { get; set; } = default!;
    }

    public class RequestParameter
    {
        public Guid Id { get; set; }

        public Guid ExternalApiId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string JsonPath { get; set; } = string.Empty;

        public string DataType { get; set; } = "string";

        public bool IsRequired { get; set; }

        public string? DefaultValue { get; set; }

        public ExternalApi ExternalApi { get; set; } = default!;
    }

    public class ResponseParameter
    {
        public Guid Id { get; set; }

        public Guid ExternalApiId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string JsonPath { get; set; } = string.Empty;

        public string DataType { get; set; } = "string";

        public ExternalApi ExternalApi { get; set; } = default!;
    }

    public class ApiAuthentication
    {
        public Guid Id { get; set; }

        public Guid ExternalApiId { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        // API Key
        public string? ApiKeyHeaderName { get; set; }
        public string? ApiKey { get; set; }

        // Bearer Token
        public string? BearerToken { get; set; }

        // Basic Authentication
        public string? Username { get; set; }
        public string? Password { get; set; }

        // OAuth2 Client Credentials
        public string? TokenUrl { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Scope { get; set; }

        public ExternalApi ExternalApi { get; set; } = default!;
    }
}
