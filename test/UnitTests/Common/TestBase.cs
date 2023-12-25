namespace DataStructures.UnitTests.Common;

public class TestBase
{
    private readonly Faker faker;

    public TestBase()
    {
        faker = new Faker();
    }

    protected int GetRandomNumber()
    {
        return faker.Random.Int(1, 1000);
    }
}