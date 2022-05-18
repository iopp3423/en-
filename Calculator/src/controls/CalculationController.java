package controls;


import models.inputData;
import view.PrintCalculator;

public class CalculationController{
	
	public CalculationController(inputData data) {
		PrintCalculator printCalculator = new PrintCalculator();
		Calculator calculator = new Calculator(printCalculator, data);	
		//testClass calculatorr = new testClass(printCalculator, data);	
		//data.dataProcess(calculator);
	}

}