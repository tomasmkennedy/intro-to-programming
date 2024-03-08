namespace TodosApi;

public record TodoCreateRequest
{
    public string Description { get; set; } = string.Empty;
}

public record TodoCreateResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public TodoStatus Status { get; set; } = TodoStatus.Incomplete;
}

public enum TodoStatus { Incomplete, Complete }

public record StatusResponse
{
    public DateTimeOffset CheckedAt { get; set; }
    public string MessageProcessingHandler { get; set; } = string.Empty;
    public string SupportTech { get; set; } = string.Empty;
}
