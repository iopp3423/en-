package controls;


import java.text.DecimalFormat;

import Utility.Constants;
import view.PrintCalculator;

public class CalculationController{
	
	public CalculationController() {
		PrintCalculator printCalculator = new PrintCalculator();
		//supportText supportClass = new supportText();
		Calculator calculator = new Calculator(printCalculator);			
	}
}