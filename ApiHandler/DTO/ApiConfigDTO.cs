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
        public List<RequestParamDto> RequestParams { get; set; }
        public List<ResponseMappingDto> ResponseMappings { get; set; }
    }
}
