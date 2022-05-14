package transmission;


import attach.Calculator;
import view.PrintCalculator;

public class CalculationController{
	

	PrintCalculator printCalculator = new PrintCalculator();
	Calculator calculator = new Calculator(printCalculator);	
}