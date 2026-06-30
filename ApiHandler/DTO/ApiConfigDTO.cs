namespace ApiHandler.DTO
{
    public class ApiConfigDTO
    {
        public string Name { get; set; } 
        public string Url { get; set; }
        public string Method { get; set; } 
        public string? AuthType { get; set; } 
        public string? AuthValue { get; set; }
        public string? AuthHeaderName { get; set; } 
        public ICollection<FieldMapping> FieldMappings { get; set; }
            = new List<FieldMapping>();
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
    public class ResponseMapping
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
}
