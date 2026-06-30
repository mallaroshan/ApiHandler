namespace ApiHandler.DTO
{
    public class ApiConfigDTO
    {
        public string Name { get; set; } 
        public string Url { get; set; }
        public string Method { get; set; } // GET, POST, etc.
        public string AuthType { get; set; } // ApiKey, Bearer, Basic, None
        public string AuthValue { get; set; }
        public string? AuthHeaderName { get; set; } // e.g. "x-api-key"
        public ICollection<FieldMapping> FieldMappings { get; set; }
    }
    public class ApiConfiguration
    {
        public Guid Id { get; set; } = new Guid();

        public string Name { get; set; } = string.Empty;

        public string BaseUrl { get; set; } = string.Empty;

        public string Endpoint { get; set; } = string.Empty;

        public string HttpMethod { get; set; } = "POST";

        public string ContentType { get; set; } = "application/json";

        // None, Bearer, Basic, ApiKey
        public string AuthType { get; set; } = "None";

        public string? AuthValue { get; set; }

        // JSON
        public string? Headers { get; set; }

        // JSON payload/template
        public string? RequestBody { get; set; }

        public string TargetTable { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public ICollection<FieldMapping> FieldMappings { get; set; }
            = new List<FieldMapping>();
    }
    public class PipelineLog
    {
        public Guid Id { get; set; } = new Guid();

        public Guid PipelineId { get; set; }

        public Pipeline Pipeline { get; set; } = null!;

        public DateTime StartedOn { get; set; }

        public DateTime? CompletedOn { get; set; }

        public bool IsSuccess { get; set; }

        public string? Request { get; set; }

        public string? Response { get; set; }

        public string? ErrorMessage { get; set; }
    }
    public class Pipeline
    {
        public Guid Id { get; set; } = new Guid();


        public string Name { get; set; } = string.Empty;

        public Guid ApiConfigurationId { get; set; }

        public ApiConfiguration ApiConfiguration { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        // Hangfire Cron Expression
        public string? CronExpression { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
    public class FieldMapping
    {
        public Guid Id { get; set; } = new Guid();
        public Guid ApiConfigurationId { get; set; }

        public ApiConfiguration ApiConfiguration { get; set; } = null!;

        // Example:
        // customer.name
        // customer.address.city
        public string JsonPath { get; set; } = string.Empty;

        // Example:
        // CustomerName
        public string DatabaseColumn { get; set; } = string.Empty;

        public string DataType { get; set; } = "nvarchar";
    }

    public class SaveExternalApiDto
    {
        public string Name { get; set; } = string.Empty;

        public string BaseUrl { get; set; } = string.Empty;

        public string Endpoint { get; set; } = string.Empty;

        public HttpMethodType Method { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public List<ApiHeaderDto> Headers { get; set; } = [];

        public List<RequestParameterDto> RequestParameters { get; set; } = [];

        public List<ResponseParameterDto> ResponseParameters { get; set; } = [];
    }

    public class ApiHeaderDto
    {
        /// <summary>
        /// Header Name (e.g. x-api-key, Authorization, client-id)
        /// </summary>
        public string HeaderName { get; set; } = string.Empty;

        /// <summary>
        /// Header Value
        /// </summary>
        public string HeaderValue { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether this value should be encrypted/masked when displayed.
        /// </summary>
        public bool IsSecret { get; set; } = false;
    }

    public class RequestParameterDto
    {
        /// <summary>
        /// Parameter Name (e.g. PolicyNo)
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// JSON Path inside request payload (e.g. $.policyNo)
        /// </summary>
        public string JsonPath { get; set; } = string.Empty;

        /// <summary>
        /// Data Type (string, int, decimal, bool, datetime, array, object)
        /// </summary>
        public string DataType { get; set; } = "string";

        /// <summary>
        /// Whether this parameter is mandatory.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value if no value is supplied.
        /// </summary>
        public string? DefaultValue { get; set; }
    }

    public class ResponseParameterDto
    {
        /// <summary>
        /// Friendly name of the response field.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// JSON Path from the external API response.
        /// Example: $.data.policyNo
        /// </summary>
        public string JsonPath { get; set; } = string.Empty;

        /// <summary>
        /// Expected data type.
        /// </summary>
        public string DataType { get; set; } = "string";
    }




}
