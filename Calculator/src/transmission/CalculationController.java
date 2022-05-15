package transmission;


import attach.Calculator;
import view.PrintCalculator;

public class CalculationController{
	

	PrintCalculator printCalculator = new PrintCalculator();
	//printCalculator.frame();
	Calculator calculator = new Calculator(printCalculator);	
}