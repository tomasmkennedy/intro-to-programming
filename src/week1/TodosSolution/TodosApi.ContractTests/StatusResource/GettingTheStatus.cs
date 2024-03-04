

namespace TodosApi.ContractTests.StatusResource;
public class GettingTheStatus
{
    [Fact]
    public async Task ReturnsOk()
    {
        // Given
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:1337");

        // When
        var response = await client.GetAsync("/status");

        // Then
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}
