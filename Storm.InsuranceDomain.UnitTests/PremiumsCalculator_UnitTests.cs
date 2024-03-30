namespace Storm.InsuranceDomain.UnitTests;

// TDD: Test Driven Design

[TestClass]
public class PremiumsCalculator_UnitTests
{
    [TestMethod]
    [DataRow(80, 1000000000)]
    [DataRow(75, 400)]
    [DataRow(74, 300)]
    [DataRow(70, 300)]
    [DataRow(69, 200)]
    [DataRow(65, 200)]
    [DataRow(64, 100)]        
    [DataRow(18, 100)]
    public void AgeCalculationsPass(int age, int expectAmount)
    {
        var calculator = new PremiumsCalculator();

        decimal amountOfMoneyToChargeCustomer = calculator.CalculatePremium(age);

        Assert.AreEqual((decimal)expectAmount, amountOfMoneyToChargeCustomer);
    }

}