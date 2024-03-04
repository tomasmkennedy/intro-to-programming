using Alba;

namespace TodosApi.ContractTests.StatusResource;
public class GettingTheStatus
{
    [Fact]
    public async Task ReturnsOk()
    {
        var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/status");
            api.StatusCodeShouldBeOk();
        });
    }
}