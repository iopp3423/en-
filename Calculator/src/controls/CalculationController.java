package controls;


import java.text.DecimalFormat;

import Utility.Constants;
import view.PrintCalculator;

public class CalculationController{
	
	public CalculationController() {
		PrintCalculator printCalculator = new PrintCalculator();
		Calculator calculator = new Calculator(printCalculator);			
	}
}