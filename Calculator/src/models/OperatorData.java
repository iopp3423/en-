package models;

import java.math.BigDecimal;
import java.text.DecimalFormat;

public class OperatorData {

	
	private String result = "";
	private String temp = "";
	private String operator = "=";
	private String formula = "";
	
	public void setResult(String result) { // = 저
		this.result = result;
	}
	public String getResult() {
		return result;
	}
	public void setTemp(String temp) {
		this.temp = temp;
	}
	public String getTemp() {
		return temp;
	}
	public void setOperator(String operator) {
		this.operator = operator;
	}
	public String getOperator() {
		return operator;
	}
	public void setFormula(String formula) {
		this.formula = formula;
	}
	public String getFormula() {
		return formula;
	}
	public String patterns() {
		Double a = 123.45;
		double number = 123456.78;
		DecimalFormat df = new DecimalFormat("0.##");
		DecimalFormat numberFormat = new DecimalFormat("###,###.0"); //형변환 Decimal
		numberFormat.applyPattern("###,###.#######");
		
		BigDecimal leftNumber = new BigDecimal("123123.123");
		
		df.format(leftNumber);
		
		a = numberFormat.format(leftNumber);
		
		  DecimalFormat df2 = new DecimalFormat("0000,0000.00"); //만자리
		  System.out.println("0000,0000.00 : "+df2.format(number));
		//numberFormat.format(Integer.parseInt(number));
		//numberFormat.format(Double.parseDouble(number));
	}
	public void patt() {
		DecimalFormat format=new DecimalFormat();
		
		String patterns[]= {
				"0",
				"#",
				"0.0",
				"000.000",				//소수점
				"000,000,000.0",
				"000,000,000.000",
				"000,000,000.000000",	//숫자가 나타나지 않는 경우 나머지 빈자리를 0으로 채워줌
				"#,#,#,#.###",			//한글자씩 ,이 붙어서 나옴
				"###,###,###.#",
				"###,###,###.###",
				"###,###,###.######",
				"-###,###,###.######",	//숫자가 나타나지 않는 경우 출력하지 않음
				"###.##E0",				//지수 형식으로 출력
				"my number: ###.##%",	//my number라는 문자열이 합쳐짐
				"'#' ###,###.####",		//escape로 #을 문자화
				"'0' 000,000.00000000",	//escape로 0을 문자화
				"###,###.000000000"	//섞어서도 쓸 수 있음
		};
			
		double number=1234123123.1234;
			
		for(int i=0;i<patterns.length;i++) {
			format.applyPattern(patterns[i]);
			System.out.println("[pattern "+patterns[i]+"] "+format.format(number));
		}
	}
	
	
}
