package start;

import controls.CalculationController;
import models.inputData;

public class StartCalculator {

	public static void main(String[] args) {
		inputData Data = new inputData();
		CalculationController calculationController = new CalculationController(Data);
	}

}
