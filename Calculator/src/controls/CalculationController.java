package controls;


import java.text.DecimalFormat;

import Utility.Constants;
import view.PrintCalculator;

public class CalculationController{
	
	public CalculationController() {
		PrintCalculator printCalculator = new PrintCalculator();
		//Calculator calculator = new Calculator(printCalculator, data);	
		testClass calculatorr = new testClass(printCalculator);	

		/*
		DecimalFormat format=new DecimalFormat();
		
		
		// 소수점 뒤에 0이 출력되면 안됨
		
		// 나누기 할 때 뒤에 0 잘라야함
		// 16자리 넘어가면 E로 변환해야함
		
		String patterns[]= {
				"#####.######",
				"0",
				"#",
				"0.0",
				"000.000",				//소수점
				"000,000,000.0",
				"000,000,000.000",
				"000,000,000.000000",	//숫자가 나타나지 않는 경우 나머지 빈자리를 0으로 채워줌
				"#,#,#,#.###",			//한글자씩 ,이 붙어서 나옴
				"###,###,###.#",
	
				"-###,###,###.######",	//숫자가 나타나지 않는 경우 출력하지 않음
				"my number: ###.##%",	//my number라는 문자열이 합쳐짐
				"'#' ###,###.####",		//escape로 #을 문자화
				"'0' 000,000.00000000",	//escape로 0을 문자화
				"###,###.000000000",	//섞어서도 쓸 수 있음			
				
				"###.################",
				
				"###.###############",
				"###############E0"				//지수 형식으로 출력
		};
			
		String number1="0.0000000000000001";
		String number2="6.66666666666666666";
		String number3="33.37";
			
		for(int index=Constants.RESET;index<patterns.length;index++) {
			format.applyPattern(patterns[index]);
			System.out.println("[pattern "+patterns[index]+"] "+format.format(Double.parseDouble(number1)*9));
		}
		for(int index=Constants.RESET;index<patterns.length;index++) {
			format.applyPattern(patterns[index]);
			System.out.println("[pattern "+patterns[index]+"] "+format.format(Double.parseDouble(number2)));
		}
		for(int index=Constants.RESET;index<patterns.length;index++) {
			format.applyPattern(patterns[index]);
			System.out.println("[pattern "+patterns[index]+"] "+format.format(Double.parseDouble(number3)));
		}*/
	}
	
	

}