
namespace Storm.InsuranceDomain;

public record InsurancePremium(int MinAge, decimal Amount) { }

public class PremiumsCalculator
{
    public InsurancePremium[] Premiums =
    [
        new InsurancePremium (80, 1000000000 ),
        new InsurancePremium (75, 400 ),
        new InsurancePremium (70, 300 ),
        new InsurancePremium (65, 200 ),
        new InsurancePremium(MinAge: 18, Amount : 100 ),
    ];

    public decimal CalculatePremium(int age)
    {
        return Premiums.First(v => age >= v.MinAge).Amount;
    }
}
