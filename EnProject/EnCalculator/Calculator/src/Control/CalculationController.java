package Control;
import Model.CalculationData;
import Model.LogData;
import View.PrintCalculator;

public class CalculationController {
	
	CalculationData calculationData = new CalculationData();
	LogData logData = new LogData();
	PrintCalculator printCalculator = new PrintCalculator();
	Calculator calculator = new Calculator(calculationData, logData);
	
	public void CallCalculoter()
	{
		printCalculator.GetCalculator();
	}
	
}
