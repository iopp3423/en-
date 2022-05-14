package control;

import model.LogData;
import view.PrintCalculator;

public class CalculationController{
	
	LogData logData = new LogData();
	PrintCalculator printCalculator = new PrintCalculator();
	Calculator calculator = new Calculator(logData, printCalculator);	
}
