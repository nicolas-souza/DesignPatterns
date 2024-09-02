// Interface for payment
public interface IPayment
{
    void MakePayment(decimal amount);
    void CancelPayment();
}

// Concrete class for credit card payment
public class CreditCardPayment : IPayment
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine($"Payment made with credit card for {amount}");
    }

    public void CancelPayment()
    {
        Console.WriteLine("Payment cancelled");
    }
}

// Concrete class for PayPal payment
public class PayPalPayment : IPayment
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine($"Payment made with PayPal for {amount}");
    }

    public void CancelPayment()
    {
        Console.WriteLine("Payment cancelled");
    }
}

// Interface for payment plan
public interface IPaymentPlan
{
    decimal CalculateFee(decimal amount);
    bool CheckLimit(decimal amount);
}

// Concrete class for basic payment plan
public class BasicPaymentPlan : IPaymentPlan
{
    public decimal CalculateFee(decimal amount)
    {
        return amount * 0.05m;
    }

    public bool CheckLimit(decimal amount)
    {
        return amount <= 1000m;
    }
}

// Concrete class for premium payment plan
public class PremiumPaymentPlan : IPaymentPlan
{
    public decimal CalculateFee(decimal amount)
    {
        return amount * 0.03m;
    }

    public bool CheckLimit(decimal amount)
    {
        return amount <= 5000m;
    }
}

// Class for payment
public class Payment
{
    public IPayment PaymentType { get; set; }
    public IPaymentPlan PaymentPlan { get; set; }

    public Payment(IPayment paymentType, IPaymentPlan paymentPlan)
    {
        PaymentType = paymentType;
        PaymentPlan = paymentPlan;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a credit card payment
        IPayment creditCardPayment = new CreditCardPayment();

        // Create a basic payment plan
        IPaymentPlan basicPaymentPlan = new BasicPaymentPlan();

        // Create a payment object with the credit card payment and basic payment plan
        Payment payment = new Payment(creditCardPayment, basicPaymentPlan);

        // Make a payment of $500
        decimal amount = 500m;
        if (payment.PaymentPlan.CheckLimit(amount))
        {
            decimal fee = payment.PaymentPlan.CalculateFee(amount);
            Console.WriteLine($"Fee: {fee}");
            payment.PaymentType.MakePayment(amount);
        }
        else
        {
            Console.WriteLine("Payment exceeds limit");
        }

        // Create a PayPal payment
        IPayment payPalPayment = new PayPalPayment();

        // Create a premium payment plan
        IPaymentPlan premiumPaymentPlan = new PremiumPaymentPlan();

        // Create a payment object with the PayPal payment and premium payment plan
        Payment payment2 = new Payment(payPalPayment, premiumPaymentPlan);

        // Make a payment of $2000
        decimal amount2 = 2000m;
        if (payment2.PaymentPlan.CheckLimit(amount2))
        {
            decimal fee2 = payment2.PaymentPlan.CalculateFee(amount2);
            Console.WriteLine($"Fee: {fee2}");
            payment2.PaymentType.MakePayment(amount2);
        }
        else
        {
            Console.WriteLine("Payment exceeds limit");
        }
    }
}