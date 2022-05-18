package models;

public class OperatorData {

	private String resultOperator = "";
	private String firstOperator= "";
	private String secondOperator= "";
	private String firstNumber = "0";
	private String secondNumber = "0";
	private String result = "";
	
	
	public void setResult(String result) { // = 저
		this.result = result;
	}
	
	public String getResult() {
		return result;
	}
	
	public void setResultOperator(String resultOperator) { // = 저
		this.resultOperator = resultOperator;
	}
	
	public String getResultOperator() {
		return resultOperator;
	}
	
	public void setFirstOperator(String firstOperator) { // 사칙연산 저
		this.firstOperator = firstOperator;
	}
	public String getFirstOperator() {
		return firstOperator;
	}
	
	public void setSecondOperator(String secondOperator) { // 사칙연산 저
		this.secondOperator = secondOperator;
	}
	public String getSecondOperator() {
		return secondOperator;
	}
	public void setFirstNumber(String number) {
		this.firstNumber = number;
	}
	public String getFirstNumber() {
		return firstNumber;
	}
	public void setSecondNumber(String secondNumber) {
		this.secondNumber = secondNumber;
	}
	public String getSecondNumber() {
		return secondNumber;
	}
	
}
